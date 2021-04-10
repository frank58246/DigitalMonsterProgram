using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleApp3
{
    internal class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            int xMax, yMax;
            xMax = 512;
            yMax = 512;

            //Create a list of lines to draw.
            var lines = new List<Line>
    {
        new Line
        {
            Start = new Point(5, 5),
            End =  new Point(50, 50)
        },
        new Line
        {
            Start = new Point(100, 20),
            End =  new Point(50, 90)
        },
        new Line
        {
            Start = new Point(35, 75),
            End =  new Point(500, 400)
        },
    };

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