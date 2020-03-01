using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageConverter.Classes
{
    public class ASCIIConverter
    {
        public string OriginalImage = @"C:\Users\Student\Desktop\clock.jpg";

        public string saveLocation = @"C:\Users\Student\Desktop\ConvertedImage.txt";

        public string pixels = " .,-+*wKB#&%";

        public ASCIIConverter(string originalImage)
        {
            this.OriginalImage = originalImage;
        }

        public void Convert(string saveLocation)
        {
            Bitmap bmp = new Bitmap(OriginalImage);
            using (StreamWriter sw = new StreamWriter(saveLocation))
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color oldPixel = bmp.GetPixel(x, y);
                        var brightness = BrightnessCalc.Brightness(oldPixel);
                        var idx = brightness / 255 * (pixels.Length - 1);
                        var pixelChar = pixels[pixels.Length - (int)Math.Round(idx) - 1];

                        //bmp.SetPixel(x, y, Color.FromArgb(oldPixel.R, oldPixel.G, 20));
                        //bmp.SetPixel(x, y, Color.FromArgb(oldPixel.R, Color.FromKnownColor(KnownColor.Gray)));
                        
                        sw.Write(pixelChar);
                        sw.Write(pixelChar);
                    }
                    sw.WriteLine();
                }
                bmp.Save(Path.Combine(@"C:\Users\Student\Desktop", "output.jpg"));
            }
        
            
        }
    }
}
