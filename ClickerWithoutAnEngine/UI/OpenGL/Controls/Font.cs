using System.Numerics;
using OpenGL;

namespace ClickerWithoutAnEngine.UI.OpenGL
{
    /// <summary>
    /// The BMFont class can be used to load both the texture and data files associated with
    /// the free BMFont tool (http://www.angelcode.com/products/bmfont/)
    /// </summary>
    public class BMFont
    {
        private static readonly Dictionary<string, BMFont> loadedFonts = new();

        public static BMFont LoadFont(string file)
        {
            if (loadedFonts.ContainsKey(file) && loadedFonts[file] != null) 
                return loadedFonts[file];
            
            BMFont font;
             font = new BMFont(file); 

            loadedFonts.Add(file, font);
            return loadedFonts[file];
        }

        public static void Dispose()
        {
            foreach (var font in loadedFonts)
                font.Value.FontTexture.Dispose();

            loadedFonts.Clear();
        }

        /// <summary>
        /// Stores the ID, height, width and UV information for a single bitmap character
        /// as exported by the BMFont tool.
        /// </summary>
        private struct Character
        {
            public readonly char id;
            public readonly float x1;
            public readonly float y1;
            public readonly float x2;
            public readonly float y2;
            public readonly float width;
            public readonly float height;
            public readonly float xOffset;
            public readonly float yOffset;
            public readonly float xAdvance;

            public Character(char _id, float _x1, float _y1, float _x2, float _y2, float _w, float _h, float _xOffset, float _yOffset, float _xAdvance)
            {
                id = _id;
                x1 = _x1;
                y1 = _y1;
                x2 = _x2;
                y2 = _y2;
                width = _w;
                height = _h;
                xOffset = _xOffset;
                yOffset = _yOffset;
                xAdvance = _xAdvance;
            }
        }

        /// <summary>
        /// Text justification to be applied when creating the VAO representing some text.
        /// </summary>
        public enum Justification
        {
            Left,
            Center,
            Right
        }

        /// <summary>
        /// The font texture associated with this bitmap font.
        /// </summary>
        public Texture FontTexture { get; } = null!;

        private readonly Dictionary<char, Character> characters = new();

        /// <summary>
        /// The height (in pixels) of this bitmap font.
        /// </summary>
        public int Height { get; }

        private readonly Dictionary<char, Dictionary<char, int>> kerning = new();

        /// <summary>
        /// Loads both a font descriptor table and the associated texture as exported by BMFont.
        /// </summary>
        /// <param name="descriptorPath">The path to the font descriptor table.</param>
        public BMFont(string descriptorPath)
        {
            var directory = new FileInfo(descriptorPath).DirectoryName;
            using var stream = new StreamReader(descriptorPath);
            
            while (!stream.EndOfStream)
            {
                var line = stream.ReadLine();
                if (line!.StartsWith("page"))
                {
                    var split = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var element in split)
                    {
                        if (!element.Contains('=')) 
                            continue;
                            
                        var code = element[..element.IndexOf('=')];
                        var contents = element[(element.IndexOf('=') + 1)..];

                        if (code == "id" && contents != "0") 
                            throw new Exception("Currently we only support loading one texture at a time.");
                            
                        if (code == "file") 
                            FontTexture = new Texture(directory + "\\" + contents.Trim(new[] { '"' }));
                    }
                }
                else if (line.StartsWith("char "))
                {
                    var split = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var id = 0;
                    float x1 = 0, y1 = 0, x2 = 0, y2 = 0, w = 0, h = 0, xo = 0, yo = 0, xa = 0;

                    foreach (var element in split)
                    {
                        if (!element.Contains('='))
                            continue;
                        
                        var code = element[..element.IndexOf('=')];
                        var value = int.Parse(element[(element.IndexOf('=') + 1)..]);

                        switch (code)
                        {
                            case "id":
                                id = value;
                                break;
                            case "x":
                                x1 = (float)value / FontTexture.Size.Width;
                                break;
                            case "y":
                                y1 = 1 - (float)value / FontTexture.Size.Height;
                                break;
                            case "width":
                                w = value;
                                x2 = x1 + w / FontTexture.Size.Width;
                                break;
                            case "height":
                                h = value;
                                y2 = y1 - h / FontTexture.Size.Height;
                                Height = System.Math.Max(Height, value);
                                break;
                            case "xoffset":
                                xo = value;
                                break;
                            case "yoffset":
                                yo = value;
                                break;
                            case "xadvance":
                                xa = value;
                                break;
                        }
                    }

                    var c = new Character((char)id, x1, y1, x2, y2, w, h, xo, yo, xa);
                    characters.TryAdd(c.id, c);
                }
                else if (line.StartsWith("kerning"))
                {
                    var split = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    char first = ' ', second = ' ';
                    var amount = 0;

                    foreach (var element in split)
                    {
                        if (!element.Contains('=')) 
                            continue;
                        
                        var code = element[..element.IndexOf('=')];
                        var value = int.Parse(element[(element.IndexOf('=') + 1)..]);

                        switch (code)
                        {
                            case "first":
                                first = (char)value;
                                break;
                            case "second":
                                second = (char)value;
                                break;
                            case "amount":
                                amount = value;
                                break;
                        }
                    }

                    if (!kerning.ContainsKey(first)) 
                        kerning.Add(first, new Dictionary<char, int>());
                    
                    kerning[first][second] = amount;
                }
            }
        }

        /// <summary>
        /// Gets the width (in pixels) of a single character of text using the loaded font.
        /// </summary>
        /// <param name="c">The character to measure the width of.</param>
        /// <returns>The width (in pixels) of the provided character.</returns>
        public int GetWidth(char c) 
            => (int)characters[characters.ContainsKey(c) ? c : ' '].xAdvance + 1;

        /// <summary>
        /// Gets the width (in pixels) of a string of text using the current loaded font.
        /// </summary>
        /// <param name="text">The string of text to measure the width of.</param>
        /// <returns>The width (in pixels) of the provided text.</returns>
        public int GetWidth(string text) 
            => text.Sum(character => (int)characters[characters.ContainsKey(character) ? character : ' '].xAdvance + 1);

        private static int maxStringLength = 200;
        private static Vector3[] vertices = new Vector3[maxStringLength * 4];
        private static Vector2[] uvs = new Vector2[maxStringLength * 4];
        private static int[] indices = new int[maxStringLength * 6];

        private void CreateStringInternal(string text, Justification justification, float scale)
        {
            var xPos = justification switch
            {
                Justification.Right => -GetWidth(text),
                Justification.Center => -GetWidth(text) / 2,
                _ => 0
            };

            var scalingFactor = Vector3.One * scale;

            for (var i = 0; i < text.Length; i++)
            {
                var ch = characters[characters.ContainsKey(text[i]) ? text[i] : ' '];
                var offset = Height - ch.yOffset;
                xPos += 1;

                vertices[i * 4 + 0] = scalingFactor * new Vector3(xPos, offset, 0);
                vertices[i * 4 + 1] = scalingFactor * new Vector3(xPos, offset - ch.height, 0);
                vertices[i * 4 + 2] = scalingFactor * new Vector3(xPos + ch.width, offset, 0);
                vertices[i * 4 + 3] = scalingFactor * new Vector3(xPos + ch.width, offset - ch.height, 0);
                xPos += (int)ch.xAdvance;
                
                if (text[i] == '_') 
                    xPos += 3;

                uvs[i * 4 + 0] = new Vector2(ch.x1, ch.y1);
                uvs[i * 4 + 1] = new Vector2(ch.x1, ch.y2);
                uvs[i * 4 + 2] = new Vector2(ch.x2, ch.y1);
                uvs[i * 4 + 3] = new Vector2(ch.x2, ch.y2);

                indices[i * 6 + 0] = i * 4 + 2;
                indices[i * 6 + 1] = i * 4 + 0;
                indices[i * 6 + 2] = i * 4 + 1;
                indices[i * 6 + 3] = i * 4 + 3;
                indices[i * 6 + 4] = i * 4 + 2;
                indices[i * 6 + 5] = i * 4 + 1;
            }
        }

        /// <summary>
        /// Creates a string over top of an old string VAO of the same length.
        /// Does not overwrite the indices, since those should be consistent
        /// across VAOs of the same length when describing text.
        /// </summary>
        /// <param name="vao">The current vao object.</param>
        /// <param name="text">The text to use when overwriting the old VAO.</param>
        /// <param name="justification">The justification of the text.</param>
        /// <param name="scale">The scaling of the text.</param>
        public void CreateString(VAO<Vector3, Vector2> vao, string text, Justification justification = Justification.Left, float scale = 1f)
        {
            if (vao == null || vao.vaoID == 0)
                return;

            if (vao.VertexCount != text.Length * 6)
                throw new InvalidOperationException("Text length did not match the length of the current vertex array object.");

            CreateStringInternal(text, justification, scale);

            Gl.BufferSubData(vao.vbos[0].vboID, BufferTarget.ArrayBuffer, vertices, text.Length * 4);
            Gl.BufferSubData(vao.vbos[1].vboID, BufferTarget.ArrayBuffer, uvs, text.Length * 4);
        }

        /// <summary>
        /// Creates a new VAO object with a specified string.
        /// </summary>
        /// <param name="program">The shader program to use with this text (FontShader or Font3DShader).</param>
        /// <param name="text">The text to use when overwriting the old VAO.</param>
        /// <param name="justification">The justification of the text.</param>
        /// <param name="scale">The scaling of the text.</param>
        /// <returns>The VAO which contains vertex, UV and index information.</returns>
        public VAO<Vector3, Vector2> CreateString(ShaderProgram program, string text, Justification justification = Justification.Left, float scale = 1f)
        {
            if (text.Length > maxStringLength)
            {
                maxStringLength = (int)System.Math.Min(int.MaxValue, (text.Length * 1.5));

                vertices = new Vector3[maxStringLength * 4];
                uvs = new Vector2[maxStringLength * 4];
                indices = new int[maxStringLength * 6];
            }

            CreateStringInternal(text, justification, scale);

            return new VAO<Vector3, Vector2>(program, 
                new VBO<Vector3>(vertices, text.Length * 4), 
                new VBO<Vector2>(uvs, text.Length * 4), 
                new[] { "in_position", "in_uv" }, 
                new VBO<int>(indices, text.Length * 6, BufferTarget.ElementArrayBuffer));
        }
    }
}
