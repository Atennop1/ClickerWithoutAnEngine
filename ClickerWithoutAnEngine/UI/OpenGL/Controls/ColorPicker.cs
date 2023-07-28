using System.Numerics;
using OpenGL;
using OpenGL.Platform;

namespace ClickerWithoutAnEngine.UI.OpenGL
{
    public class ColorGradient : UIElement
    {
        private readonly VAO gradientQuad;
        private float selX, selY = 1.0f, h = 1.0f;
        private bool mouseDown;

        public float Hue
        {
            get => h;
            set
            {
                h = value;
                Program.Use();
                Program["hue"].SetValue(new HSLColor(value, 1, 0.5f).ToVector());
                UpdateColor();
            }
        }
        
        public Vector3 Color { get; set; }

        public OnMouse OnColorChange { get; set; }

        public ColorGradient()
        {
            var colorGradient = UserInterface.GetElement("ColorGradient");
            
            if (colorGradient != null)
            {
                throw new Exception("Only one color picker can currently exist at once.  This is a limitation I intend to remove soon.");
            }

            Program = Shaders.GradientShader;

            Program.Use();
            Program["hue"].SetValue(new Vector3(h, 0, 0));
            Program["sel"].SetValue(new Vector2(selX, selY));
            gradientQuad = Geometry.CreateQuad(this.Program, Vector2.Zero, new Vector2(150, 150));

            RelativeTo = Corner.TopLeft;
            Position = new Point(30, 50);
            Size = new Point(150, 150);
            Name = "ColorGradient";

            OnMouseDown = (_, eventArgs) =>
            {
                mouseDown = (eventArgs.Button == MouseButton.Left);
                UpdateMousePosition(eventArgs.Location.X, eventArgs.Location.Y);
            };
            
            OnMouseUp = (_, eventArgs) => mouseDown = eventArgs.Button != MouseButton.Left && mouseDown;
            OnMouseLeave = (_, _) => mouseDown = false;
            OnMouseMove = (_, eventArgs) => UpdateMousePosition(eventArgs.Location.X, eventArgs.Location.Y);

            UpdateColor();
        }

        private void UpdateMousePosition(int x, int y)
        {
            if (!mouseDown)
            {
                return;
            }

            selX = System.Math.Min(1, (float)(x - CorrectedPosition.X) / Size.X);
            selY = System.Math.Min(1, (float)((UserInterface.Height - y) - CorrectedPosition.Y) / Size.Y);

            Program.Use();
            Program["sel"].SetValue(new Vector2(selX, selY));

            UpdateColor();
        }

        private void UpdateColor()
        {
            var color = new HSLColor(h, 1, 0.5f).ToVector();
            var blend1 = color * selX + Vector3.One * (1 - selX);

            Color = blend1 * selY;
            OnColorChange.Invoke(this, new MouseEventArgs());
        }

        public override void Draw()
        {
            Program.Use();
            gradientQuad.Draw();
        }

        public override void OnResize()
        {
            base.OnResize();

            Program.Use();
            Program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(CorrectedPosition.X, CorrectedPosition.Y, 0)));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            gradientQuad.DisposeChildren = true;
            gradientQuad.Dispose();
        }
    }

    public class HueGradient : UIElement
    {
        private readonly VAO hueQuad;
        private bool mouseDown;

        public HueGradient()
        {
            Program = Shaders.HueShader;

            Program.Use();
            Program["hue"].SetValue(0f);
            hueQuad = Geometry.CreateQuad(Program, Vector2.Zero, new Vector2(26, 150));

            RelativeTo = Corner.TopLeft;
            Position = new Point(185, 50);
            Size = new Point(26, 150);
            Name = "HueGradient";

            OnMouseDown = (_, eventArgs) =>
            {
                mouseDown = eventArgs.Button == MouseButton.Left;
                UpdateMousePosition(eventArgs.Location.X, eventArgs.Location.Y);
            };
            
            OnMouseUp = (_, eventArgs) => mouseDown = eventArgs.Button != MouseButton.Left && mouseDown;
            OnMouseLeave = (_, _) => mouseDown = false;
            OnMouseMove = (_, eventArgs) => UpdateMousePosition(eventArgs.Location.X, eventArgs.Location.Y);
        }

        private void UpdateMousePosition(int x, int y)
        {
            if (!mouseDown)
            {
                return;
            }

            var hue = ((UserInterface.Height - y) - CorrectedPosition.Y) / (float)Size.Y;
            Program.Use();
            Program["hue"].SetValue((float)((UserInterface.Height - y) - CorrectedPosition.Y));

            var colorGradient = UserInterface.GetElement("ColorGradient");
            if (colorGradient != null)
            {
                ((ColorGradient)colorGradient).Hue = hue;
            }
        }

        public override void Draw()
        {
            Gl.Enable(EnableCap.Blend);

            Program.Use();
            hueQuad.Draw();

            Gl.Disable(EnableCap.Blend);
        }

        public override void OnResize()
        {
            base.OnResize();

            Program.Use();
            Program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(CorrectedPosition.X, CorrectedPosition.Y, 0)));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            hueQuad.DisposeChildren = true;
            hueQuad.Dispose();
        }
    }

    public class HSLColor
    {
        public float H { get; }

        public float S { get; }

        public float L { get; }

        public HSLColor(float h, float s, float l)
        {
            H = h;
            S = s;
            L = l;
        }

        public HSLColor(Vector3 c)
        {
            var r = c.X;
            var g = c.Y;
            var b = c.Z;

            var _Min = System.Math.Min(System.Math.Min(r, g), b);
            var _Max = System.Math.Max(System.Math.Max(r, g), b);
            var _Delta = _Max - _Min;

            H = 0;
            S = 0;
            L = (_Max + _Min) / 2.0f;

            if (_Delta != 0)
            {
                S = L < 0.5f ? _Delta / (_Max + _Min) : _Delta / (2.0f - _Max - _Min);

                if (r == _Max)
                {
                    H = (g - b) / _Delta;
                }
                else if (g == _Max)
                {
                    H = 2f + (b - r) / _Delta;
                }
                else if (b == _Max)
                {
                    H = 4f + (r - g) / _Delta;
                }
            }

            H *= 60f;
            
            if (H < 0)
            {
                H += 360;
            }

            H /= 360f;
        }

        public HSLColor(System.Drawing.Color c)
            : this(c.R / 255f, c.G / 255f, c.B / 255f) { }

        public Vector3 ToVector()
        {
            float r, g, b;

            if (S == 0)
            {
                r = g = b = L;
            }
            else
            {
                var q = (L < 0.5f ? L * (1 + S) : L + S - L * S);
                var p = 2 * L - q;
                
                r = HUE2RGB(p, q, H + 1 / 3.0f);
                g = HUE2RGB(p, q, H);
                b = HUE2RGB(p, q, H - 1 / 3.0f);
            }

            return new Vector3(r, g, b);
        }

        private static float HUE2RGB(float p, float q, float t)
        {
            if (t < 0)
            {
                t += 1;
            }

            if (t > 1)
            {
                t -= 1;
            }

            if (t < 1 / 6.0)
            {
                return p + (q - p) * 6 * t;
            }

            if (t < 1 / 2.0)
            {
                return q;
            }

            if (t < 2 / 3.0)
            {
                return p + (q - p) * (2 / 3.0f - t) * 6;
            }

            return p;
        }
    }
}
