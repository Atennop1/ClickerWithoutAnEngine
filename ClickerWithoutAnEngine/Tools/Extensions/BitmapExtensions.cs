using System.Drawing;

namespace ClickerWithoutAnEngine.Tools
{
    public static class BitmapExtensions
    {
        public static void SwitchColor(this Bitmap bitmap, Color newColor)
        {
            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    var currentColor = bitmap.GetPixel(x, y);
                    bitmap.SetPixel(x, y, currentColor.A > 150 ? newColor : currentColor);
                }
            }
        }
    }
}