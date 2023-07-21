using System.Drawing;

namespace ClickerWithoutAnEngine.Tools
{
    public static class BitmapExtensions
    {
        public static void ChangeColor(this Bitmap bitmap, Color newColor)
        {
            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    var currentColor = bitmap.GetPixel(x, y);
                    
                    var finalColor = Color.FromArgb(red: MixARGBComponent(currentColor.R, newColor.R), 
                                                    green: MixARGBComponent(currentColor.G, newColor.G), 
                                                    blue: MixARGBComponent(currentColor.B,  newColor.B),
                                                    alpha: MixARGBComponent(currentColor.A, newColor.A));
                    
                    bitmap.SetPixel(x, y, finalColor);
                }
            }
        }

        private static int MixARGBComponent(int first, int second)
        {
            var result = first - 168 + second;
            
            if (result < 0)
                result = 0;

            if (result > 255)
                result = 255;

            return result;
        }
    }
}