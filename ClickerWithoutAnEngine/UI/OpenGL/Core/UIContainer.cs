using OpenGL;

namespace ClickerWithoutAnEngine.UI.OpenGL
{
    public class UIContainer : UIElement
    {
        private readonly List<UIElement> elements;

        public new string Name
        {
            get => base.Name;
            set
            {
                base.Name = value;
                foreach (var pElement in elements) pElement.Name = base.Name + pElement.GetType();
            }
        }

        public List<UIElement> Elements 
            => elements;

        protected UIContainer()
            : this(new Point(0, 0), UserInterface.UIWindow.Size, "Container" + UserInterface.GetUniqueElementID())
        {
            RelativeTo = Corner.Fill;
        }

        public UIContainer(Point Size, string Name)
            : this(new Point(0, 0), Size, Name) { }

        public UIContainer(Point Position, Point Size, string Name)
        {
            elements = new List<UIElement>();
            this.Name = Name;
            RelativeTo = Corner.TopLeft;
            this.Position = Position;
            this.Size = Size;
        }

        public void AddElement(UIElement Element)
        {
            if (string.IsNullOrEmpty(Element.Name))
                Element.Name = Element.ToString() + UserInterface.GetUniqueElementID();

            if (UserInterface.Elements.ContainsKey(Element.Name))
                return;
            
            UserInterface.Elements.Add(Element.Name, Element);
            Element.Parent = this;
            elements.Add(Element);

            if (this == UserInterface.UIWindow) 
                Element.OnResize();
        }

        public void RemoveElement(UIElement Element)
        {
            if (Element.Name != null && UserInterface.Elements.ContainsKey(Element.Name)) 
                UserInterface.Elements.Remove(Element.Name);

            if (!elements.Contains(Element))
            {
                foreach (var element in elements.Where(element => element.GetType() == typeof(UIContainer) || element.GetType().BaseType == typeof(UIContainer)))
                    ((UIContainer)element).RemoveElement(Element);
            }
            else
            {
                elements.Remove(Element);
            }
        }

        public UIElement PickChildren(Point Location)
        {
            if (Pick(Location) == false) 
                return null!;

            for (var i = elements.Count - 1; i >= 0; i--)
            {
                if (!elements[i].Pick(Location)) 
                    continue;
                
                if (elements[i].GetType() == typeof(UIContainer) || elements[i].GetType().BaseType == typeof(UIContainer))
                    return ((UIContainer)elements[i]).PickChildren(Location);
                
                return elements[i];
            }

            return this;
        }

        public virtual void Close() => 
            Dispose();

        private void DrawContainerOnly() => 
            base.Draw();

        public void ClearElements()
        {
            foreach (var element in elements) 
                element.Dispose();
            
            elements.Clear();
        }

        protected override void Dispose(bool disposing)
        {
            while (elements.Count > 0) 
                elements[0].Dispose();

            base.Dispose(disposing);
        }

        public override void Update()
        {
            foreach (var element in elements)
                element.Update();
        }

        public override void Invalidate()
        {
            foreach (var element in elements)
                element.Invalidate();
        }

        public override void Draw()
        {
            DrawContainerOnly();
            
            foreach (var element in elements.Where(element => element.Visible)) 
                element.Draw();
        }

        public override void OnResize()
        {
            if (this != UserInterface.UIWindow && Parent == null) 
                return;

            base.OnResize();
            
            foreach (var element in elements)
                element.OnResize();
        }

        public override void DoInvoke()
        {
            base.DoInvoke();
            
            foreach (var element in elements)
                element.DoInvoke();
        }
    }
}
