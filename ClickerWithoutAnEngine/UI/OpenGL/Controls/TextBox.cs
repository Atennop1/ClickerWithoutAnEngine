using System.Numerics;
using OpenGL;
using OpenGL.Platform;
using static System.Threading.Thread;

namespace ClickerWithoutAnEngine.UI.OpenGL
{
    public class TextBox : UIElement
    {
        /// <summary>
        /// A simple class for storing information about the contents and color
        /// of each line in the text box.  Internal use only.
        /// </summary>
        private class TextBoxEntry
        {
            public readonly Vector3 Color;
            public readonly string Text;
            public readonly bool NewLine;
            public int Position;
            public readonly BMFont Font;

            public TextBoxEntry(Vector3 color, string text, BMFont font, bool newLine = true, int position = 0)
            {
                Color = color;
                Text = text;
                NewLine = newLine;
                Position = position;
                Font = font;
            }
        }

        #region Variables
        private readonly List<TextBoxEntry> text = new();
        private readonly List<List<TextBoxEntry>> lines = new();
        private readonly List<Text> vaos = new();
        private VAO selectedVAO;

        private bool dirty;
        private int currentLine;
        #endregion

        /// <summary>
        /// The maximum number of lines of text that can be drawn into 
        /// this TextBox given the height and font size.
        /// </summary>
        public int MaximumLines { get; private set; }

        /// <summary>
        /// The total number of lines of text after formatting (this is how
        /// big the text box would have to be to show all of the text contained within).
        /// </summary>
        public int LineCount => lines.Count;

        /// <summary>
        /// The current line number of the first line of text in this text box.
        /// This value will normally be zero unless the text box has been scrolled.
        /// </summary>
        public int CurrentLine
        {
            get => currentLine;
            set
            {
                currentLine = value;
                dirty = true;
            }
        }

        private readonly BMFont font;

        /// <summary>
        /// The font being used by this text box.
        /// </summary>
        public BMFont Font
        {
            get => font;
            init
            {
                font = value;
                MaximumLines = (int)System.Math.Round(Size.Y / (font.Height * 1.2 + 1));
            }
        }

        /// <summary>
        /// Gets the contents of the currently selected line.
        /// </summary>
        public string SelectedLineText
        {
            get
            {
                var line = (selectedLine == -1 ? -1 : selectedLine);
                if (line < 0 || line >= lines.Count)
                    return "";

                return lines[line].Count == 0 ? "" : lines[line][0].Text;
            }
        }

        private int selectedLine;

        public int SelectedLine
        {
            get => selectedLine;
            set
            {
                selectedLine = value;
                OnSelectionChanged.Invoke(this, new MouseEventArgs());
            }
        }

        public Vector4 SelectedColor { get; set; }

        public OnMouse OnSelectionChanged { get; set; }

        public bool AllowSelection { get; set; }

        private static Texture scrollbarTexture = null!;

        private int scrollBarDown = -1;
        private bool allowScrollBar, scrollBarMouseDown;
        private Button scrollBar;

        public Button ScrollBar => scrollBar;

        /// <summary>
        /// Sets whether a scrollbar will be attached to this text box.
        /// </summary>
        public bool AllowScrollBar
        {
            get => allowScrollBar;
            set
            {
                allowScrollBar = value;
                if (Parent == null)
                    return;

                if (scrollBar == null)
                    return;

                if (allowScrollBar && LineCount > MaximumLines)
                {
                    Parent.AddElement(scrollBar);
                    return;
                }

                Parent.RemoveElement(scrollBar);
            }
        }

        /// <summary>
        /// Updates the position of the scrollbar.
        /// </summary>
        public void UpdateScrollBar()
        {
            if (LineCount <= MaximumLines || Parent == null || scrollBar == null)
                return;

            scrollBar.RelativeTo = Corner.BottomLeft;
            var percent = (float)CurrentLine / (LineCount - MaximumLines);
            
            var y = Size.Y - scrollBar.Size.Y;
            y -= (int)System.Math.Round(percent * (Size.Y - scrollBar.Size.Y));

            scrollBar.RelativeTo = Corner.BottomLeft;
            scrollBar.Position = CorrectedPosition - Parent.CorrectedPosition + new Point(Size.X, y);
            scrollBar.OnResize();
        }

        public Point Padding { get; }

        public TextBox(BMFont font, Texture scrollTexture)
        {
            Font = font;
            SelectedColor = new Vector4(0.3f, 0.9f, 0.3f, 1f);

            OnMouseDown = (_, eventArgs) =>
            {
                var y = (CorrectedPosition.Y + Size.Y) - (UserInterface.Height - eventArgs.Location.Y);
                SelectedLine = currentLine + (int)(y / (Font.Height * 1.2));
            };

            if (scrollbarTexture == null) 
                scrollbarTexture = scrollTexture;

            scrollBar = new Button(scrollbarTexture);
            scrollBar.BackgroundColor = new Vector4(0, 0, 0, 0);
            scrollBar.Size = new Point(scrollBar.Size.X, scrollBar.Size.Y / 2);

            scrollBar.OnMouseUp = (_, _) => scrollBarMouseDown = false;
            scrollBar.OnMouseDown = (_, eventArgs) =>
            {
                scrollBarMouseDown = eventArgs.Button == MouseButton.Left;
                scrollBarDown = eventArgs.Location.Y;
            };
            
            scrollBar.OnMouseMove = (_, eventArgs) =>
            {
                if (!scrollBarMouseDown)
                    return;

                var dy = scrollBarDown - eventArgs.Location.Y;
                var yMin = CorrectedPosition.Y - Parent.CorrectedPosition.Y;
                var yMax = yMin + Size.Y - ScrollBar.Size.Y;
                var y = System.Math.Min(yMax, System.Math.Max(yMin, scrollBar.Position.Y + dy));

                if (y == scrollBar.Position.Y)
                    return;

                scrollBarDown = eventArgs.Location.Y;
                scrollBar.Position = new Point(scrollBar.Position.X, y);
                scrollBar.OnResize();

                var percent = (yMax - y) / ((double)Size.Y - scrollBar.Size.Y);
                CurrentLine = (int)System.Math.Round((LineCount - MaximumLines) * percent);
            };
            
            scrollBar.OnLoseFocus = (o, e) => OnLoseFocus.Invoke(o, e);
            OnMouseMove = (sender, eventArgs) => scrollBar.OnMouseMove(sender, eventArgs);
        }

        private void ParseText()
        {
            MaximumLines = (int)System.Math.Round(Size.Y / (Font.Height * 1.2 + 1));
            lines.Clear();

            List<TextBoxEntry> line = new();
            var xPos = 0;

            foreach (var character in text)
            {
                if (character == null || character.Text == null)
                    continue;

                var w = character.Font.GetWidth(character.Text);

                if (xPos + w + Padding.X * 2 <= Size.X)
                {
                    line.Add(character);
                    character.Position = xPos;
                    xPos += w;

                    if (!character.NewLine) 
                        continue;
                    
                    lines.Add(line);
                    line = new List<TextBoxEntry>();
                    xPos = 0;
                }
                else
                {
                    var remaining = character.Text;

                    while (remaining.Length > 0)
                    {
                        int maximumLength, currentWidth = xPos + Padding.X * 2;

                        for (maximumLength = 0; maximumLength < remaining.Length; maximumLength++)
                        {
                            currentWidth += character.Font.GetWidth(remaining[maximumLength]);
                            if (currentWidth <= Size.X) 
                                continue;
                            
                            maximumLength--;
                            break;
                        }

                        if (maximumLength <= 0)
                            return;

                        var actualBreakPoint = maximumLength;

                        if (remaining.Length > maximumLength)
                        {
                            for (; actualBreakPoint > 0; actualBreakPoint--)
                                if (remaining[actualBreakPoint] == ' ' || remaining[actualBreakPoint] == '\t')
                                    break;

                            if (actualBreakPoint == 0) 
                                actualBreakPoint = maximumLength;
                        }

                        if (actualBreakPoint == -1)
                        {
                            line.Add(new TextBoxEntry(character.Color, remaining, character.Font, true, xPos));
                            remaining = string.Empty;
                        }
                        else if (actualBreakPoint != maximumLength || line.Count == 0)
                        {
                            line.Add(new TextBoxEntry(character.Color, remaining.Substring(0, actualBreakPoint), character.Font, true, xPos));
                            remaining = remaining.Substring(actualBreakPoint).TrimStart();
                        }

                        if (line.Count == 0) 
                            continue;
                        
                        lines.Add(line);
                        line = new List<TextBoxEntry>();
                        xPos = 0;
                    }
                }
            }

            if (line.Count != 0) 
                lines.Add(line);

            dirty = true;
        }

        private void BuildVAOs()
        {
            for (var i = 0; i < vaos.Count; i++)
            {
                vaos[i].Dispose();
                vaos[i] = null!;
            }
            
            vaos.Clear();

            if (lines.Count > MaximumLines && allowScrollBar && scrollBar != null)
            {
                if (scrollBar.Name == null || !UserInterface.Elements.ContainsKey(scrollBar.Name))
                    Parent.AddElement(scrollBar);
            }
            else if (Parent != null && scrollBar != null)
            {
                Parent.RemoveElement(scrollBar);
            }

            for (var i = CurrentLine; i <= MaximumLines + CurrentLine; i++)
            {
                if (i >= lines.Count || i < 0)
                    break;

                if (lines[i].Count == 0)
                    continue;

                var current = lines[i][0];
                var contents = "";

                for (var j = 0; j < lines[i].Count; j++)
                {
                    if (current.Color != lines[i][j].Color || current.Font != lines[i][j].Font)
                    {
                        if (contents.Length != 0) 
                            BuildVAO(current, contents);

                        current = lines[i][j];
                        contents = lines[i][j].Text;
                    }
                    else
                    {
                        contents += lines[i][j].Text;
                    }
                }

                if (contents.Length != 0) 
                    BuildVAO(current, contents);
            }

            CalculateVisibilityTime();
            dirty = false;
        }

        private void CalculateVisibilityTime()
        {
            totalCharacters = 0;

            foreach (var vao in vaos)
                totalCharacters += vao.String.Length;

            visibilityTime = TimePerCharacter * totalCharacters;
        }

        private void BuildVAO(TextBoxEntry entry, string text1)
        {
            var temp = new Text(Shaders.FontShader, entry.Font, text1, entry.Color);
            temp.Padding = new Point(entry.Position, 0);
            vaos.Add(temp);
        }

        public override void OnResize()
        {
            base.OnResize();
            UpdateScrollBar();

            if (selectedVAO != null)
            {
                selectedVAO.DisposeChildren = true;
                selectedVAO.Dispose();
            }
            
            var vertex = new VBO<Vector3>(new Vector3[] { new(0, 0, 0), new(Size.X, 0, 0), new(Size.X, Font.Height * 1.2f, 0), new(0, Font.Height * 1.2f, 0) });
            var elements = new VBO<int>(new[] { 0, 1, 3, 1, 2, 3 }, BufferTarget.ElementArrayBuffer);
            selectedVAO = new VAO(Shaders.SolidUIShader, vertex, elements);

            ParseText();
        }

        public int VisibleCharacters { get; private set; }

        private float visibilityTime;
        private float currentTime;

        public float TimePerCharacter { get; set; }

        private int totalCharacters;

        public OnMouse OnTextVisible { get; set; }

        public bool TextIsVisible 
        {
            get => VisibleCharacters == 0;
            set => currentTime = value ? visibilityTime : 0;
        }

        public override void Draw()
        {
            base.Draw();

            if (CurrentLine < 0)
                return;

            if (dirty) 
                BuildVAOs();

            if (TimePerCharacter > 0 && currentTime < visibilityTime)
            {
                VisibleCharacters = (int)System.Math.Max(1, (currentTime / visibilityTime * totalCharacters));
            }
            else
            {
                OnTextVisible.Invoke(this, new MouseEventArgs(new Point(0, 0)));
                VisibleCharacters = 0;
            }

            var characterCount = 0;

            for (int i = 0, v = 0; i < lines.Count - CurrentLine && v < vaos.Count; i++)
            {
                if (AllowSelection && (currentLine + i) == SelectedLine && selectedVAO != null)
                {
                    Shaders.SolidUIShader.Use();
                    Shaders.SolidUIShader["position"].SetValue(new Vector3(CorrectedPosition.X, CorrectedPosition.Y - (1.2f * (i + 1) * Font.Height - Size.Y), 0));
                    Shaders.SolidUIShader["color"].SetValue(SelectedColor);

                    selectedVAO.Draw();
                }

                for (var j = 0; j < lines[i + CurrentLine].Count; j++)
                {
                    if (v >= vaos.Count)
                        break;

                    vaos[v].CorrectedPosition = new Point(CorrectedPosition.X + Padding.X, (int)(CorrectedPosition.Y - (1.2 * (i + 1) * Font.Height - Size.Y)));

                    if (VisibleCharacters <= 0 || characterCount + vaos[v].String.Length <= VisibleCharacters)
                    {
                        vaos[v].Draw();
                        characterCount += vaos[v].String.Length;
                    }
                    else
                    {
                        vaos[v].DrawWithCharacterCount(VisibleCharacters - characterCount);
                        characterCount = VisibleCharacters;
                    }

                    v++;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (scrollBar != null)
            {
                scrollBar.Dispose();
                scrollBar = null!;
            }

            if (selectedVAO != null)
            {
                selectedVAO.DisposeChildren = true;
                selectedVAO.Dispose();
                selectedVAO = null!;
            }

            if (scrollbarTexture != null)
            {
                scrollbarTexture.Dispose();
                scrollbarTexture = null!;
            }

            foreach (var vao in vaos) 
                vao.Dispose();
            
            vaos.Clear();
        }

        public void ScrollToEnd()
        {
            if (Environment.CurrentManagedThreadId != UserInterface.MainThreadID)
                throw new InvalidOperationException("An attempt was made to modify a UI element off the main thread.");

            ParseText();
            if (LineCount > MaximumLines) 
                CurrentLine = LineCount - MaximumLines;

            UpdateScrollBar();
        }

        public void Write(string message)
        {
            if (Environment.CurrentManagedThreadId != UserInterface.MainThreadID)
                throw new InvalidOperationException("An attempt was made to modify a UI element off the main thread.");

            Write(Vector3.One, message);
            totalCharacters += message.Length;
        }

        public void Write(Vector3 color, string message)
        {
            if (Environment.CurrentManagedThreadId != UserInterface.MainThreadID)
                throw new InvalidOperationException("An attempt was made to modify a UI element off the main thread.");

            text.Add(new TextBoxEntry(color, message, Font, false));
        }

        public void WriteLine(string message)
        {
            if (Environment.CurrentManagedThreadId == UserInterface.MainThreadID)
            {
                WriteLineSafe(message);
            }
            else
            {
                Invoke(WriteLineSafe, message);
            }
        }

        public void WriteLine(Vector3 color, string message)
        {
            if (Environment.CurrentManagedThreadId != UserInterface.MainThreadID)
                throw new InvalidOperationException("An attempt was made to modify a UI element off the main thread.");

            text.Add(new TextBoxEntry(color, message, Font));
            ScrollToEnd();
        }

        public void Write(Vector3 color, string message, BMFont customFont)
        {
            if (Environment.CurrentManagedThreadId != UserInterface.MainThreadID)
                throw new InvalidOperationException("An attempt was made to modify a UI element off the main thread.");

            text.Add(new TextBoxEntry(color, message, customFont, false));
        }

        public void WriteLine(Vector3 color, string message, BMFont customFont)
        {
            if (CurrentThread.ManagedThreadId != UserInterface.MainThreadID)
                throw new InvalidOperationException("An attempt was made to modify a UI element off the main thread.");

            text.Add(new TextBoxEntry(color, message, customFont));
            ScrollToEnd();
        }

        private void WriteLineSafe(object message) 
            => WriteLine(Vector3.One, (string)message);

        public void Clear()
        {
            text.Clear();
            dirty = true;

            currentTime = 0f;
            totalCharacters = 0;
            visibilityTime = 0f;
        }
    }
}
