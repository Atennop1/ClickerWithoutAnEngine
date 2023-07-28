using System.Collections;
using System.Numerics;
using OpenGL;
using OpenGL.Platform;

namespace ClickerWithoutAnEngine.UI.OpenGL
{
    public interface IMouseInput
    {
        OnMouse OnMouseClick { get; set; }
        OnMouse OnMouseEnter { get; set; }
        OnMouse OnMouseLeave { get; set; }
        OnMouse OnMouseDown { get; set; }
        OnMouse OnMouseUp { get; set; }
        OnMouse OnMouseMove { get; set; }
        OnMouse OnMouseRepeat { get; set; }

        OnFocus OnLoseFocus { get; }
    }

    public enum Corner
    {
        BottomLeft,
        BottomRight,
        TopLeft,
        TopRight,
        Bottom,
        Top,
        Fill,
        Center
    };

    public struct Invokable
    {
        public readonly OnInvoke Method;
        public readonly object Parameter;

        public Invokable(OnInvoke Method, object arg)
        {
            this.Method = Method;
            Parameter = arg;
        }
    }

    public delegate void OnChanged(object sender, EventArgs e);

    public delegate void OnInvoke(object arg);

    public delegate void OnMouse(object sender, MouseEventArgs e);

    public delegate void OnFocus(object sender, IMouseInput newFocus);

    public interface IUserInterface : IDisposable
    {
        float Alpha { get; set; }
        Point Position { get; set; }
        Point Size { get; set; }
        Point MinSize { get; set; }
        Point MaxSize { get; set; }
        Corner RelativeTo { get; set; }
        UIContainer Parent { get; set; }
        ShaderProgram Program { get; }
        string Name { get; set; }

        void Draw();
        void OnResize();
        void Update();
        void Invalidate();
        void Invoke(OnInvoke Method, object arg);
    }

    public abstract class UIElement : IUserInterface, IMouseInput
    {
        public float Alpha { get; set; }
        public Point Position { get; set; }

        private Point u_size;
        
        public Point Size
        {
            get => u_size;
            set
            {
                if (MaxSize.X == 0 || MaxSize.Y == 0) MaxSize = new Point(1000000, 1000000);
                u_size = Point.Max(MinSize, Point.Min(MaxSize, value));
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (uiQuad != null)
            {
                uiQuad.DisposeChildren = true;
                uiQuad.Dispose();
                uiQuad = null!;
            }

            UserInterface.RemoveElement(this);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Point MinSize { get; set; }

        public Point MaxSize { get; set; }

        public Point CorrectedPosition { get; set; }

        public Corner RelativeTo { get; set; }

        public string Name { get; set; } = null!;

        public OnMouse OnMouseClick { get; set; } = null!;

        public OnMouse OnMouseEnter { get; set; } = null!;

        public OnMouse OnMouseLeave { get; set; } = null!;

        public OnMouse OnMouseDown { get; set; } = null!;

        public OnMouse OnMouseUp { get; set; } = null!;

        public OnMouse OnMouseMove { get; set; } = null!;

        public OnMouse OnMouseRepeat { get; set; } = null!;

        public OnFocus OnLoseFocus { get; set; } = null!;

        public UIContainer Parent { get; set; } = null!;

        public bool DisablePicking { get; set; } = false;

        public ShaderProgram Program { get; protected init; } = null!;

        public bool Visible = true;

        public virtual void Draw()
        {
            DoInvoke();

            if (BackgroundTexture != null) DrawQuadTextured();
            else DrawQuadColored();
        }

        public virtual void OnResize()
        {
            if (Parent == null)
            {
                CorrectedPosition = RelativeTo switch
                {
                    Corner.BottomLeft => Position,
                    Corner.TopLeft => new Point(Position.X, Position.Y),
                    Corner.BottomRight => new Point(UserInterface.Width - Position.X - Size.X, Position.Y),
                    Corner.TopRight => new Point(UserInterface.Width - Position.X - Size.X, -Position.Y - Size.Y),
                    Corner.Bottom => new Point(UserInterface.Width / 2 - Size.X / 2 + Position.X, Position.Y),
                    Corner.Top => new Point(UserInterface.Width / 2 - Size.X / 2 + Position.X, -Position.Y - Size.Y),
                    Corner.Center => new Point(UserInterface.Width / 2 - Size.X / 2 + Position.X, UserInterface.Height / 2 - Size.Y / 2 + Position.Y),
                    _ => CorrectedPosition
                };
            }
            else
            {
                switch (RelativeTo)
                {
                    case Corner.BottomLeft:
                        CorrectedPosition = Position;
                        break;
                    case Corner.TopLeft:
                        CorrectedPosition = new Point(Position.X, Parent.Size.Y - Position.Y - Size.Y);
                        break;
                    case Corner.BottomRight:
                        CorrectedPosition = new Point(Parent.Size.X - Position.X - Size.X, Position.Y);
                        break;
                    case Corner.TopRight:
                        CorrectedPosition = new Point(Parent.Size.X - Position.X - Size.X, Parent.Size.Y - Position.Y - Size.Y);
                        break;
                    case Corner.Bottom:
                        CorrectedPosition = new Point(Parent.Size.X / 2 - Size.X / 2 + Position.X, Position.Y);
                        break;
                    case Corner.Top:
                        CorrectedPosition = new Point(Parent.Size.X / 2 - Size.X / 2 + Position.X, Parent.Size.Y - Position.Y - Size.Y);
                        break;
                    case Corner.Fill:
                        CorrectedPosition = new Point(0, 0);
                        Size = Parent.Size;
                        break;
                    case Corner.Center:
                        CorrectedPosition = new Point(Parent.Size.X / 2 - Size.X / 2 + Position.X, Parent.Size.Y / 2 - Size.Y / 2 + Position.Y);
                        break;
                }

                CorrectedPosition += Parent.CorrectedPosition;
            }

            if (BackgroundColor != Vector4.Zero || BackgroundTexture != null)
            {
                if (uiQuad != null)
                {
                    uiQuad.DisposeChildren = true;
                    uiQuad.Dispose();
                }
                uiQuad = Geometry.CreateQuad(Shaders.SolidUIShader, Vector2.Zero, new Vector2(Size.X, Size.Y), Vector2.Zero, new Vector2(1, 1));
            }

            Invalidate();
        }

        public virtual void Update() { }

        public virtual bool Pick(Point Location)
        {
            if (DisablePicking) 
                return false;
            
            return Location.X >= CorrectedPosition.X && Location.X <= CorrectedPosition.X + Size.X &&
                   Location.Y >= CorrectedPosition.Y && Location.Y <= CorrectedPosition.Y + Size.Y;
        }

        public virtual void Invalidate() { }

        private Queue InvokeQueue = null!;

        /// <summary>
        /// Adds a method to the invoke queue, which will be called by the thread that owns this object.
        /// </summary>
        /// <param name="Method">Since argument method to call.</param>
        /// <param name="arg">Argument for the method.</param>
        public void Invoke(OnInvoke Method, object arg)
        {
            if (InvokeQueue == null)
                InvokeQueue = new Queue();
            
            Queue.Synchronized(InvokeQueue).Enqueue(new Invokable(Method, arg));
        }

        /// <summary>
        /// Calls all the methods that have been invoked by pulling them off the thread-safe queue.
        /// </summary>
        public virtual void DoInvoke()
        {
            if (InvokeQueue == null || InvokeQueue.Count == 0) return;

            for (var i = 0; i < Queue.Synchronized(InvokeQueue).Count; i++)
            {
                var pInvoke = (Invokable)Queue.Synchronized(InvokeQueue).Dequeue()!;
                pInvoke.Method(pInvoke.Parameter);
            }
        }

        public static bool Intersects(Point Position, Point Size, Point Location)
        {
            return (Location.X >= Position.X && Location.X <= Position.X + Size.X &&
                Location.Y >= Position.Y && Location.Y <= Position.Y + Size.Y);
        }

        private VAO uiQuad = null!;

        public Texture BackgroundTexture { get; set; } = null!;

        public Vector4 BackgroundColor { get; set; }

        public void DrawQuadTextured()
        {
            if (BackgroundTexture == null) 
                return;
            
            if (uiQuad == null)
                uiQuad = Geometry.CreateQuad(Shaders.SolidUIShader, Vector2.Zero, new Vector2(Size.X, Size.Y), Vector2.Zero, new Vector2(1, 1));

            Gl.Enable(EnableCap.Blend);
            Gl.ActiveTexture(TextureUnit.Texture0);
            Gl.BindTexture(BackgroundTexture);

            Shaders.TexturedUIShader.Use();
            Shaders.TexturedUIShader["position"].SetValue(new Vector3(CorrectedPosition.X, CorrectedPosition.Y, 0));
            uiQuad.DrawProgram(Shaders.TexturedUIShader);

            Gl.Disable(EnableCap.Blend);
        }

        public void DrawQuadColored()
        {
            if (BackgroundColor == Vector4.Zero) 
                return;

            DrawQuadColored(BackgroundColor);
        }

        public void DrawQuadColored(Vector4 color)
        {
            if (uiQuad == null) 
                uiQuad = Geometry.CreateQuad(Shaders.SolidUIShader, Vector2.Zero, new Vector2(Size.X, Size.Y), Vector2.Zero, new Vector2(1, 1));

            Gl.Enable(EnableCap.Blend);

            Shaders.SolidUIShader.Use();
            Shaders.SolidUIShader["position"].SetValue(new Vector3(CorrectedPosition.X, CorrectedPosition.Y, 0));
            Shaders.SolidUIShader["color"].SetValue(color);
            uiQuad.Draw();

            Gl.Disable(EnableCap.Blend);
        }
    }
}
