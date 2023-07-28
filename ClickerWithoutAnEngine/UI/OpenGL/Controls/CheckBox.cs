using System.Numerics;
using OpenGL;
using OpenGL.Platform;

namespace ClickerWithoutAnEngine.UI.OpenGL
{
    public class CheckBox : UIContainer
    {
        private Text text = null!;
        private BMFont font = null!;
        private string textString = null!;

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
                
                if (!string.IsNullOrEmpty(textString))
                {
                    Text = textString;
                }
            }
        }

        /// <summary>
        /// The descriptive text to use for this checkbox (placed to the right of the checkbox).
        /// Will rebuild the string VAO when modified.
        /// </summary>
        public string Text
        {
            get => textString;
            set
            {
                textString = value;
                
                if (text == null)
                {
                    if (font == null)
                    {
                        return;
                    }

                    text = new Text(Shaders.FontShader, font, textString);
                    text.Size = new Point(0, Size.Y);
                    text.RelativeTo = Corner.BottomLeft;
                    text.Position = new Point(UncheckedTexture.Size.Width + 6, Size.Y / 2 - text.TextSize.Y / 2);

                    AddElement(text);
                }
                else
                {
                    text.String = textString;
                }
            }
        }

        /// <summary>
        /// An event that is fired when the checkbox changes state.
        /// </summary>
        public OnMouse OnCheckedChanged { get; set; } = null!;

        private readonly Button checkBox;
        private bool isChecked;

        /// <summary>
        /// Texture to use when the checkbox is unchecked.
        /// Should be the same size as CheckedTexture as well as the CheckBox.Size property.
        /// </summary>
        public Texture UncheckedTexture { get; set; }

        /// <summary>
        /// Texture to use when the checkbox is checked.
        /// Should be the same size as UncheckedTexture as well as the CheckBox.Size property.
        /// </summary>
        public Texture CheckedTexture { get; set; }

        /// <summary>
        /// True if the checkbox is currently checked.
        /// False if the checkbox is unchecked.
        /// </summary>
        public bool Checked
        {
            get => isChecked;
            set
            {
                isChecked = value;
                OnCheckedChanged.Invoke(this, new MouseEventArgs());

                checkBox.BackgroundTexture = isChecked ? CheckedTexture : UncheckedTexture;
            }
        }

        /// <summary>
        /// Creates a simple checkbox user interface element which can be used
        /// for setting/modifying the state of a boolean value.
        /// This can be useful in preferences as well as other places in the user interface.
        /// </summary>
        /// <param name="uncheckedTexture">A texture to use when the checkbox is unchecked.  Should be the same size as checkedTexture.</param>
        /// <param name="checkedTexture">A texture to use when the checkbox is checked.  Should be the same size as uncheckedTexture.</param>
        /// <param name="font">A BMFont to use when rendering the descriptive text of this checkbox.</param>
        /// <param name="text">The descriptive text to render to the right of this checkbox.</param>
        public CheckBox(Texture uncheckedTexture, Texture checkedTexture, BMFont font, string text)
            : base(new Point(0, 0), new Point(uncheckedTexture.Size.Width, uncheckedTexture.Size.Height), "CheckBox" + UserInterface.GetUniqueElementID())
        {
            UncheckedTexture = uncheckedTexture;
            CheckedTexture = checkedTexture;

            checkBox = new Button(UncheckedTexture);
            checkBox.BackgroundColor = new Vector4(0, 0, 0, 0);
            checkBox.RelativeTo = Corner.BottomLeft;
            checkBox.Size = new Point(uncheckedTexture.Size.Width, uncheckedTexture.Size.Height);
            AddElement(checkBox);

            Font = font;
            Text = text;

            checkBox.OnMouseClick = (_, _) => Checked = !Checked;
        }
    }
}
