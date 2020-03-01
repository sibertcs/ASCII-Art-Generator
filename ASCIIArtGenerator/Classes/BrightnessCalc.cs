using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ImageConverter
{
    class BrightnessCalc
    {
        public static double Brightness(Color c)
        {
            return (double)Math.Sqrt(
               c.R * c.R * .241 +
               c.G * c.G * .691 +
               c.B * c.B * .068);
        }
    }
}
