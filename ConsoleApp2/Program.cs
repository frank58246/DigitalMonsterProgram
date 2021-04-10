using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleApp2
{
    internal class Program
    {
        private static float s = 0;

        private static List<Line> lines = new List<Line>();

        private static void Main(string[] args)
        {
            //while (s < 1 || s >= 2)
            //{
            //Console.WriteLine("ration 1 to 2");
            //s = float.Parse(Console.ReadLine());
            //}
            s = 1.9f;
            s = (s - 1) / 10 + 1;
            s = (float)Math.Sqrt(s * (s - 1));
            float x0 = 100, x1 = 412, y0 = 0, y1 = 0;
            fractal(x0, x1, y0, y1, 1);
            line(100, 50, 412, 50, 255, 65535);
            Console.ReadLine();
        }

        private static void fractal(float x0,
            float x1,
            float y0,
            float y1,
            int sp)
        {
            float l, r, x2, y2;
            l = (float)Math.Sqrt(((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0)));
            if (l < 2 || sp >= 9)
            {
                line(x0, y0 / 3 + 50, x1, y1 / 3 + 50, 255, 65535);
                return;
            }
            r = (float)(new Random()).NextDouble();
            x2 = (float)((x0 + x1) / 2.0 + s * (y1 - y0) * r);
            y2 = (float)((y0 + y1) / 2.0 + s * (x0 - x1) * r);
            sp = sp + 1;
            fractal(x0, x2, y0, y2, sp);
            fractal(x2, x1, y2, y1, sp);
        }

        private static void line(float x0,
            float x1,
            float y0,
            float y1,
            int start,
            int end)
        {
            var text = $"{x0:f5},{x1:f5},{y0:f5},{y1:f5}";
            var line = new Line()
            {
                Start = new Point(x0, y0),
            }
            Console.WriteLine(text);
        }

        public void SaveImage()
        {
            var xMax = 512;
            var yMax = 512;

            //Declare the Bitmap, Graphics, and Pen in a using block so
            //they are all disposed properly when finished.
            using (var bmp = new Bitmap(xMax, yMax))
            using (var graphics = Graphics.FromImage(bmp))
            using (var pen = new Pen(Color.White, 2))
            {
                graphics.FillRectangle(Brushes.Green, new Rectangle(0, 0, xMax, yMax));

                foreach (Line line in lines)
                {
                    graphics.DrawLine(pen, line.Start, line.End);
                }

                bmp.Save(@"d:\test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            Console.ReadKey();
        }
    }
}