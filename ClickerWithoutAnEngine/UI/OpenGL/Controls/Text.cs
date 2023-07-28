using System.Numerics;
using OpenGL;

namespace ClickerWithoutAnEngine.UI.OpenGL
{
    public class Text : UIElement
    {
        public enum FontSize
        {
            _12pt = 0,
            _14pt = 1,
            _16pt = 2,
            _24pt = 3,
            _32pt = 4,
            _48pt = 5
        }

        public static BMFont FontFromSize(FontSize font)
        {
            return font switch
            {
                FontSize._12pt => BMFont.LoadFont("Fonts/font12.fnt"),
                FontSize._14pt => BMFont.LoadFont("Fonts/font14.fnt"),
                FontSize._16pt => BMFont.LoadFont("Fonts/font16.fnt"),
                FontSize._24pt => BMFont.LoadFont("Fonts/font24.fnt"),
                FontSize._32pt => BMFont.LoadFont("Fonts/font32.fnt"),
                FontSize._48pt => BMFont.LoadFont("Fonts/font48.fnt"),
                _ => BMFont.LoadFont("Fonts/font12.fnt"),
            };
        }

        private string text;
        private BMFont bitmapFont;
        private readonly BMFont.Justification justification;

        public Vector3 Color { get; set; }

        public BMFont.Justification Justification
        {
            get => justification;
            init
            {
                if (justification == value) 
                    return;
                
                justification = value;
                bitmapFont.CreateString(VAO, text, justification);
            }
        }

        private VAO<Vector3, Vector2> VAO;
        public Point Padding { get; set; }
        public Point TextSize { get; private set; }

        public string String
        {
            get => text;
            set
            {
                if (text == value || value == null)
                    return;

                if (text == null || text.Length != value.Length)
                {
                    VAO.Dispose();
                    VAO = bitmapFont.CreateString(Program, value, Justification);
                    VAO.DisposeChildren = true;
                }
                else
                {
                    bitmapFont.CreateString(VAO, value, Justification);
                }

                text = value;
                TextSize = new Point(bitmapFont.GetWidth(text), bitmapFont.Height);
            }
        }

        public Text(ShaderProgram program, BMFont font, string text, BMFont.Justification justification = BMFont.Justification.Left)
            : this(program, font, text, new Vector3(1, 1, 1), justification) { }

        public Text(FontSize font, string text, BMFont.Justification justification = BMFont.Justification.Left)
            : this(Shaders.FontShader, FontFromSize(font), text, Vector3.One, justification) { }

        public Text(FontSize font, string text, Vector3 color, BMFont.Justification justification = BMFont.Justification.Left)
            : this(Shaders.FontShader, FontFromSize(font), text, color, justification) { }

        public Text(ShaderProgram program, BMFont font, string text, Vector3 color, BMFont.Justification justification = BMFont.Justification.Left)
        {
            bitmapFont = font;
            Program = program;
            Justification = justification;
            Color = color;
            String = text;
            Position = new Point(0, 0);
        }

        /// <summary>
        /// Updates the current VAO with a new font.
        /// Will use the current 'String' if it exists, otherwise will leave VAO as null.
        /// </summary>
        /// <param name="font">The new font size to use with this Text.</param>
        public void UpdateFontSize(FontSize font)
        {
            bitmapFont = FontFromSize(font);

            if (string.IsNullOrEmpty(String))
                return;

            if (VAO == null)
            {
                VAO = bitmapFont.CreateString(Program, String, Justification);
                VAO.DisposeChildren = true;
            }
            else
            {
                bitmapFont.CreateString(VAO, String, Justification);
            }

            TextSize = new Point(bitmapFont.GetWidth(text), bitmapFont.Height);
        }

        public void DrawWithCharacterCount(int count)
        {
            var vertexCount = System.Math.Min(count * 6, VAO.VertexCount);

            Gl.ActiveTexture(TextureUnit.Texture0);
            Gl.BindTexture(bitmapFont.FontTexture);
            Gl.Enable(EnableCap.Blend);
            
            Program.Use();
            Program["position"].SetValue(new Vector2(CorrectedPosition.X + Padding.X, CorrectedPosition.Y + Padding.Y));
            Program["color"].SetValue(Color);
            VAO.BindAttributes(Program);
            
            Gl.DrawElements(BeginMode.Triangles, vertexCount, DrawElementsType.UnsignedInt, IntPtr.Zero);
            Gl.Disable(EnableCap.Blend);
        }

        public override void Draw()
        {
            base.Draw();

            Gl.ActiveTexture(TextureUnit.Texture0);
            Gl.BindTexture(bitmapFont.FontTexture);

            var yOffset = 0;
            if (Size.Y > TextSize.Y)
            {
                yOffset = (Size.Y - TextSize.Y) / 2;
            }

            Gl.Enable(EnableCap.Blend);
            Program.Use();
            
            Program["position"].SetValue(Justification == BMFont.Justification.Center
                ? new Vector2(CorrectedPosition.X + Padding.X + Size.X / 2, CorrectedPosition.Y + Padding.Y + yOffset)
                : new Vector2(CorrectedPosition.X + Padding.X, CorrectedPosition.Y + Padding.Y + yOffset));

            Program["color"].SetValue(Color);
            VAO.Draw();
            Gl.Disable(EnableCap.Blend);
        }

        protected override void Dispose(bool disposing)
        {
            if (VAO != null)
            {
                VAO.Dispose();
                VAO = null!;
            }

            base.Dispose(true);
        }
    }
}
