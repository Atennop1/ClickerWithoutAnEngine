using System.Numerics;
using OpenGL;
using OpenGL.Platform;

namespace ClickerWithoutAnEngine.UI.OpenGL
{
    public class Slider : UIContainer
    {
        private readonly Button sliderButton;
        
        private int min, max, value;
        private bool sliderMouseDown;

        /// <summary>
        /// The minimum value that the slider can return.
        /// </summary>
        public int Minimum
        {
            get => min;
            set
            {
                if (value < 0 || value >= max)
                    throw new ArgumentOutOfRangeException(nameof(Minimum));

                min = value;
                if (Value < min) 
                    Value = min;
            }
        }

        /// <summary>
        /// The maximum value that the slider can return.
        /// </summary>
        public int Maximum
        {
            get => max;
            set
            {
                if (value < 0 || value <= min)
                    throw new ArgumentOutOfRangeException(nameof(Maximum));

                max = value;
                if (Value > max) 
                    Value = max;
            }
        }

        /// <summary>
        /// The current value of the slider (rounded to the closest integer).
        /// </summary>
        public int Value
        {
            get => value;
            set
            {
                if (value < min || value > max)
                    throw new ArgumentOutOfRangeException(nameof(Value));

                if (value != this.value && OnValueChanged != null) 
                    OnValueChanged(this, new MouseEventArgs());

                this.value = value;
                var x = (value - min) * (Size.X - sliderButton.Size.X) / (max - min);
                
                sliderButton.Position = new Point(x, 0);
                sliderButton.OnResize();
            }
        }

        /// <summary>
        /// Locks the slider to the steps defined by Minimum and Maximum.
        /// This, for example, will cause the slider to 'jump' to the next valid value.
        /// </summary>
        public bool LockToSteps { get; set; }

        /// <summary>
        /// An event that is fired when the value of the slider changes.
        /// </summary>
        public OnMouse OnValueChanged { get; set; }

        /// <summary>
        /// Creates a slider with a given texture, minimum, maximum and default values.
        /// </summary>
        /// <param name="sliderTexture">The texture to apply to the slider.  This also defines the slider size.</param>
        /// <param name="min">The minimum value of the slider.</param>
        /// <param name="max">The maximum value of the slider.</param>
        /// <param name="value">The default value of the slider.</param>
        public Slider(Texture sliderTexture, int min = 0, int max = 10, int value = 0)
            : base(new Point(0, 0), new Point(200, sliderTexture.Size.Height), "Slider" + UserInterface.GetUniqueElementID())
        {
            this.min = min;
            this.max = max;
            this.value = value;

            sliderButton = new Button(sliderTexture);
            sliderButton.BackgroundColor = new Vector4(0, 0, 0, 0);

            sliderButton.OnMouseUp = (_, _) => sliderMouseDown = false;
            sliderButton.OnMouseDown = (_, eventArgs) => sliderMouseDown = eventArgs.Button == MouseButton.Left;
            
            sliderButton.OnMouseMove = (sender, eventArgs) => OnMouseMove(sender, eventArgs);
            OnMouseMove = (_, eventArgs) =>
            {
                if (!sliderMouseDown)
                    return;

                if (eventArgs.Location.X < CorrectedPosition.X)
                {
                    sliderButton.Position = new Point(0, 0);
                    Value = Minimum;
                }
                else if (eventArgs.Location.X > CorrectedPosition.X + Size.X)
                {
                    sliderButton.Position = new Point(Size.X - sliderButton.Size.X, 0);
                    Value = Maximum;
                }
                else
                {
                    var x = eventArgs.Location.X - CorrectedPosition.X - (sliderButton.Size.X / 2);
                    var percent = System.Math.Max(0, (double)x / (Size.X - sliderButton.Size.X));

                    x = LockToSteps
                        ? (int)(System.Math.Round(percent * (Maximum - Minimum)) * (Size.X - sliderButton.Size.X) / (Maximum - Minimum))
                        : System.Math.Max(0, System.Math.Min(Size.X - sliderButton.Size.X, x));

                    if (x == sliderButton.Position.X)
                        return;

                    sliderButton.Position = new Point(x, 0);
                    var clampedValue = System.Math.Max(Minimum, System.Math.Min(Maximum, (int)System.Math.Round((Maximum - Minimum) * percent) + Minimum));

                    if (this.value != clampedValue)
                    {
                        this.value = clampedValue;
                        OnValueChanged?.Invoke(this, new MouseEventArgs());
                    }
                }
                sliderButton.OnResize();
            };

            sliderButton.RelativeTo = Corner.BottomLeft;
            sliderButton.Position = new Point(value * (Size.X - sliderButton.Size.X) / (max - min), 0);
            AddElement(sliderButton);
        }
    }
}
