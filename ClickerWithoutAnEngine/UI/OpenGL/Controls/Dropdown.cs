using OpenGL;

namespace ClickerWithoutAnEngine.UI.OpenGL
{
    public class Dropdown : UIContainer
    {
        private readonly string[] items;
        private readonly Button dropDownToggle;
        private readonly TextBox dropDownBox;
        
        private bool dropDownVisible;
        private Text text = null!;
        private BMFont font = null!;

        /// <summary>
        /// Returns a clone of the items as they are in the drop down
        /// box at this time.  This is not modifiable!
        /// </summary>
        /// <returns></returns>
        public string[] GetItems() 
            => (string[])items.Clone();

        /// <summary>
        /// Gets or sets the selected lin of the drop down text box.
        /// </summary>
        public int SelectedLine
        {
            get => dropDownBox.SelectedLine;
            set 
            {
                dropDownBox.CurrentLine = System.Math.Max(0, System.Math.Min(dropDownBox.LineCount - 4, value));
                dropDownBox.SelectedLine = value; 
            }
        }

        /// <summary>
        /// Gets the selected line text from the drop down text box.
        /// </summary>
        public string SelectedLineText 
            => dropDownBox.SelectedLineText;

        /// <summary>
        /// The font to use when rendering the descriptive text for this checkbox.
        /// Will rebuild the string VAO when modified.
        /// </summary>
        public BMFont Font
        {
            get => font;
            set
            {
                text.Dispose();
                font = value;
                
                text = new Text(Shaders.FontShader, font, dropDownBox.SelectedLineText);
                text.RelativeTo = Corner.TopLeft;
                text.Position = new Point(0, text.TextSize.Y);
            }
        }

        /// <summary>
        /// A list box with a text box as the drop down text, a button for the toggle,
        /// and some text to display the currently selected line.
        /// </summary>
        /// <param name="dropDownIcon">The icon to use to the right of the text for displaying the text box.</param>
        /// <param name="scrollTexture">The icon to use for the scroll bar.</param>
        /// <param name="font">The font to use for both the text box and the text.</param>
        /// <param name="items">The items to place in the text box.</param>
        /// <param name="selectedLine">The default selected line for the text box.</param>
        public Dropdown(Texture dropDownIcon, Texture scrollTexture, BMFont font, string[] items, int selectedLine = 0)
        {
            this.items = items;

            dropDownToggle = new Button(dropDownIcon);
            dropDownToggle.RelativeTo = Corner.TopRight;
            dropDownToggle.Position = new Point(0, (Size.Y - dropDownToggle.Size.Y)/ 2);
            AddElement(dropDownToggle);

            dropDownBox = new TextBox(font, scrollTexture);
            foreach (var item in items) dropDownBox.WriteLine(item);
            dropDownBox.CurrentLine = 0;
            dropDownBox.AllowSelection = true;

            dropDownToggle.OnMouseClick = (_, _) =>
            {
                dropDownVisible = !dropDownVisible;

                if (dropDownVisible)
                {
                    Parent.AddElement(dropDownBox);
                    dropDownBox.AllowScrollBar = (items.Length > 4);
                }
                else
                {
                    Parent.RemoveElement(dropDownBox);
                    dropDownBox.AllowScrollBar = false;
                }
            };

            dropDownBox.OnSelectionChanged = (_, _) => text.String = dropDownBox.SelectedLineText;

            dropDownToggle.OnLoseFocus = OnLoseFocusInternal;
            dropDownBox.OnLoseFocus = OnLoseFocusInternal;
            OnLoseFocus = OnLoseFocusInternal;

            Font = font;
            SelectedLine = selectedLine;
            AddElement(text);
        }

        /// <summary>
        /// Called the the control loses focus by the user clicking elsewhere.
        /// This takes care of hiding the drop down box.
        /// </summary>
        private void OnLoseFocusInternal(object sender, IMouseInput newFocus)
        {
            if (newFocus == dropDownToggle || newFocus == dropDownBox || newFocus == dropDownBox.ScrollBar) 
                return;
            
            if (dropDownVisible) 
                Parent.RemoveElement(dropDownBox);

            dropDownBox.AllowScrollBar = false;
            dropDownToggle.Enabled = false;
            dropDownVisible = false;
        }

        public override void Invalidate()
        {
            base.Invalidate();
            var numLines = System.Math.Min(items.Length, 4);
            
            dropDownBox.RelativeTo = RelativeTo;
            dropDownBox.Size = new Point(Size.X - 8, (int)System.Math.Round(font.Height * numLines * 1.2));
            dropDownBox.Position = new Point(Position.X, Position.Y + Size.Y);

            if (dropDownBox.RelativeTo == Corner.Center)
                dropDownBox.Position = new Point(dropDownBox.Position.X, (-Size.Y - dropDownBox.Size.Y) / 2);

            dropDownToggle.Position = new Point(0, (Size.Y - dropDownToggle.Size.Y) / 2);
        }
    }
}
