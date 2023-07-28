using System.Numerics;
using OpenGL;

namespace ClickerWithoutAnEngine.UI.OpenGL
{
    public class Button : UIElement
    {
        public bool Enabled { get; set; }
        public Vector4 EnabledColor { get; }
        
        private Text text;
        private BMFont font;
        private string textString;

        public BMFont Font
        {
            get => font;
            set
            {
                text.Dispose();
                font = value;
                
                if (!string.IsNullOrEmpty(textString))
                {
                    text = new Text(Shaders.FontShader, font, textString, BMFont.Justification.Center);
                }
            }
        }

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

                    text = new Text(Shaders.FontShader, font, textString, BMFont.Justification.Center);
                    text.Size = Size;
                }
                else
                {
                    text.String = textString;
                }
            }
        }
        
        public Button(Texture texture)
        {
            BackgroundColor = Vector4.Zero;
            EnabledColor = Vector4.Zero;
            BackgroundTexture = texture;

            RelativeTo = Corner.TopLeft;
            Size = new Point(texture.Size.Width, texture.Size.Height);
        }

        public Button(int width, int height)
        {
            BackgroundColor = new Vector4(0.3f, 0.3f, 0.3f, 1f);
            EnabledColor = new Vector4(0.3f, 0.9f, 0.3f, 1f);

            RelativeTo = Corner.TopLeft;
            Size = new Point(width, height);
        }

        public override void OnResize()
        {
            if (text != null)
            {
                text.Size = Size;
            }

            base.OnResize();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            text.Dispose();
        }

        public override void Draw()
        {
            DrawQuadColored(Enabled ? EnabledColor : BackgroundColor);
            
            if (BackgroundTexture != null)
            {
                DrawQuadTextured();
            }

            if (text == null)
            {
                return;
            }

            text.CorrectedPosition = CorrectedPosition;
            text.Draw();
        }
    }
}
