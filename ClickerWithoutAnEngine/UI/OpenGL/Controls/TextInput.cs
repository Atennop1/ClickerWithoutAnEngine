using OpenGL;
using OpenGL.Platform;
using static System.String;

namespace ClickerWithoutAnEngine.UI.OpenGL
{
    public class TextInput : UIContainer
    {
        private readonly Text text;
        private bool hasFocus;

        /// <summary>
        /// CarriageReturn callback delegate prototype.
        /// </summary>
        /// <param name="entry">The TextEntry that received the carriage return signal.</param>
        /// <param name="text">The text contained in the TextEntry when the carriage return signal was received.</param>
        public delegate void OnTextEvent(TextInput entry, string text);

        /// <summary>
        /// Event is called when the carriage return button (Enter on most keyboards) is pressed.
        /// </summary>
        public OnTextEvent OnCarriageReturn { get; set; }

        /// <summary>
        /// Event is called when any text is entered or deleted.
        /// </summary>
        public OnTextEvent OnTextEntry { get; set; }

        /// <summary>
        /// The contents of the TextEntry.
        /// </summary>
        public string String 
            => text.String;

        public TextInput(BMFont font, string s = "")
            : base(new Point(0, 0), new Point(200, font.Height), "TextEntry" + UserInterface.GetUniqueElementID())
        {
            text = new Text(Shaders.FontShader, font, s);
            text.RelativeTo = Corner.Fill;
            text.Padding = new Point(5, 0);

            OnMouseClick = (o, e) => text.OnMouseClick(o, e);

            text.OnMouseClick = (_, _) =>
            {
                if (hasFocus)
                    return;

                hasFocus = true;
                Input.PushKeyBindings();

                Input.SubscribeAll(new Event((key, state) =>
                {
                    if (!state || text.TextSize.X > Size.X - 16)
                        return;

                    text.String += key;
                    OnTextEntry?.Invoke(this, String);
                }));

                Input.Subscribe((char)8, new Event(() =>
                {
                    if (text.String.Length == 0)
                        return;
                    
                    text.String = text.String.Substring(0, text.String.Length - 1);
                    OnTextEntry?.Invoke(this, String);
                }));

                Input.Subscribe((char)13, new Event(() => OnCarriageReturn?.Invoke(this, String)));
                Input.Subscribe((char)27, new Event(() => text.OnLoseFocus(null!, null!)));

                text.OnLoseFocus = (_, _) =>
                {
                    if (!hasFocus)
                        return;

                    hasFocus = false;
                    Input.PopKeyBindings();
                }; 
            };

            AddElement(text);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (hasFocus) 
                hasFocus = false;
        }

        public void Clear() 
            => text.String = Empty;
    }
}
