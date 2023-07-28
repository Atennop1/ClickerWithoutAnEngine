using System.Numerics;
using OpenGL;
using OpenGL.Platform;

namespace ClickerWithoutAnEngine.UI.OpenGL
{
    public static class UserInterface
    {
        public static UIContainer UIWindow = null!;

        private static uint uniqueID;

        public static Dictionary<string, UIElement> Elements = null!;

        public static Matrix4 UIProjectionMatrix;

        public static UIElement Selection = null!;

        public static bool Visible { get; set; }

        public static int Width { get; private set; }

        public static int Height { get; private set; }

        public static int MainThreadID { get; private set; }

        public static void InitUI(int width, int height)
        {
            if (!Shaders.Init()) 
                return;
            
            Elements = new Dictionary<string, UIElement>();

            UIWindow = new UIContainer(new Point(0, 0), new Point(Width, Height), "TopLevel");
            UIWindow.RelativeTo = Corner.BottomLeft;
            Elements.Add("Screen", UIWindow);

            UIProjectionMatrix = Matrix4.CreateTranslation(new Vector3(-Width / 2, -Height / 2, 0)) * Matrix4.CreateOrthographic(Width, Height, 0, 1000);
            Visible = true;

            MainThreadID = Thread.CurrentThread.ManagedThreadId;
            OnResize(width, height);
        }

        public static void AddElement(UIElement Element) 
            => UIWindow.AddElement(Element);

        public static void RemoveElement(UIElement Element) 
            => UIWindow.RemoveElement(Element);

        public static void ClearElements() 
            => UIWindow.ClearElements();

        public static UIElement GetElement(string name)
        {
            Elements.TryGetValue(name, out var element);
            return element!;
        }

        public static void Draw()
        {
            if (!Visible || UIWindow == null) 
                return;

            var depthTest = Gl.GetBoolean(GetPName.DepthTest);
            var blending = Gl.GetBoolean(GetPName.Blend);
            
            if (depthTest)
            {
                Gl.Disable(EnableCap.DepthTest);
                Gl.DepthMask(false);
            }

            UIWindow.Draw();

            if (depthTest)
            {
                Gl.DepthMask(true);
                Gl.Enable(EnableCap.DepthTest);
            }
            
            if (blending) 
                Gl.Enable(EnableCap.Blend);
        }

        public static uint GetUniqueElementID() => 
            uniqueID++;

        private static void Update(float delta) => 
            UIWindow.Update();

        public static void OnResize(int width, int height)
        {
            Width = width;
            Height = height;

            UIProjectionMatrix = Matrix4.CreateTranslation(new Vector3(-Width / 2, -Height / 2, 0)) * Matrix4.CreateOrthographic(Width, Height, 0, 1000);
            Shaders.UpdateUIProjectionMatrix(UIProjectionMatrix);

            if (UIWindow == null) 
                return;
            
            UIWindow.Size = new Point(Width, Height);
            UIWindow.OnResize();
        }

        public static bool Pick(Point Location)
        {
            if (UIWindow == null) 
                return false;

            if ((Selection = UIWindow.PickChildren(new Point(Location.X, Height - Location.Y))) == null) 
                return false;
            
            return Selection != UIWindow;

        }

        public static void Dispose()
        {
            UIWindow.Dispose();
            UIWindow = null!;

            Elements.Clear();
            Shaders.Dispose();
        }

        private static UIElement currentSelection = null!, activeSelection = null!;
        private static Click mousePosition, leftMousePosition;

        /// <summary>
        /// The current mouse state (position and button press).
        /// </summary>
        public static Click MousePosition
        {
            get => mousePosition;
            set { leftMousePosition = mousePosition; mousePosition = value; }
        }

        /// <summary>
        /// The previous state of the mouse (position and button press).
        /// </summary>
        public static Click LastMousePosition
        {
            get => leftMousePosition;
            set => leftMousePosition = value;
        }

        /// <summary>
        /// The current object that has focus (the last object clicked).
        /// </summary>
        public static IMouseInput Focus { get; set; } = null!;

        public static bool OnMouseMove(int x, int y)
        {
            var lastSelection = currentSelection;
            MousePosition = new Click(x, y, false, false, false, false);
            var position = new Point(MousePosition.X, MousePosition.Y);

            if (currentSelection is { OnMouseMove: not null }) 
                currentSelection.OnMouseMove(null!, new MouseEventArgs(MousePosition, LastMousePosition));

            currentSelection = (Pick(position) ? Selection : null)!;

            if (currentSelection == lastSelection) 
                return currentSelection != null;
            
            if (lastSelection is { OnMouseLeave: not null }) 
                lastSelection.OnMouseLeave(null!, new MouseEventArgs(MousePosition, LastMousePosition));
            
            if (currentSelection is { OnMouseEnter: not null }) 
                currentSelection.OnMouseEnter(null!, new MouseEventArgs(MousePosition, LastMousePosition));

            return currentSelection != null;
        }

        public static bool OnMouseClick(int button, int state, int x, int y)
        {
            MousePosition = new Click(x, y, (MouseButton)button, (MouseState)state);

            if (MousePosition.State == MouseState.Down)
            {
                if (Focus != null && currentSelection != Focus && Focus.OnLoseFocus != null) 
                    Focus.OnLoseFocus(null!, currentSelection);
                
                Focus = currentSelection;
            }

            if (activeSelection != null && MousePosition.State == MouseState.Up)
            {
                activeSelection.OnMouseUp.Invoke(null!, new MouseEventArgs(MousePosition, LastMousePosition));
                activeSelection = null!;
            }
            else if (currentSelection != null && !(currentSelection is UIContainer))
            {
                if (MousePosition.State == MouseState.Down)
                {
                    currentSelection.OnMouseDown.Invoke(null!, new MouseEventArgs(MousePosition, LastMousePosition));
                    activeSelection = currentSelection;
                }
                else
                {
                    currentSelection.OnMouseUp.Invoke(null!, new MouseEventArgs(MousePosition, LastMousePosition));
                    activeSelection = null!;
                }

                currentSelection.OnMouseClick.Invoke(null!, new MouseEventArgs(MousePosition, LastMousePosition));
            }

            return activeSelection != null;
        }
    }
}
