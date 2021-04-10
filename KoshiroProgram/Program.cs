using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace KoshiroProgram
{
    internal class Program
    {
        private static float s;

        private static List<Line> lines = new List<Line>();

        private static void Main(string[] args)
        {
            /* func sample. coast creation */
            while (s < 1 || s >= 2)
            {
                input("ration 1 to 2", ref s);
            }
            s = (s - 1) / 10 + 1;
            s = (float)Math.Sqrt(s * (s - 1));
            float x0 = 100, x1 = 412, y0 = 0, y1 = 0;
            fractal(x0, x1, y0, y1, 1);
            line(100, 50, 412, 50, 255, 65535);

            saveAndOpenImage();
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
            r = rnd() + rnd() + rnd() - 2;
            x2 = (float)((x0 + x1) / 2.0 + s * (y1 - y0) * r);
            y2 = (float)((y0 + y1) / 2.0 + s * (x0 - x1) * r);
            sp = sp + 1;
            fractal(x0, x2, y0, y2, sp);
            fractal(x2, x1, y2, y1, sp);
        }

        /// <summary>
        /// X-Basic提供的輸入變數方法，キーボードから入力されるデータを、指定したデータ型の変数へ代入します。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="variable"></param>
        private static void input<T>(string text, ref T variable)
        {
            Console.WriteLine(text);
            var input = Console.ReadLine();
            variable = (T)Convert.ChangeType(input, typeof(T));
        }

        /// <summary>
        /// X-Basic提供的亂數方法，0以上1未満の実数型乱数を返します。
        /// </summary>
        /// <returns></returns>
        private static float rnd()
        {
            return (float)((new Random()).NextDouble());
        }

        /// <summary>
        /// X-Basic提供的劃線方法，グラフィック画面上に直線を引きます。
        /// </summary>
        /// <param name="x0">始点Ｘ座標</param>
        /// <param name="y0">始点Ｙ座標</param>
        /// <param name="x1">終点Ｘ座標</param>
        /// <param name="y1">終点Ｙ座標</param>
        /// <param name="p">パレットコード（色）</param>
        /// <param name="ls">0～65535の値をとり、これを16ビットのビットパターンとみなし、実線(&HFFFF)や点線(&HAAAA)などを指定する事ができます。</param>
        private static void line(float x0,
            float y0,
            float x1,
            float y1,
            int p,
            int ls)
        {
            var line = new Line()
            {
                Start = new PointF(x0, y0),
                End = new PointF(x1, y1)
            };
            lines.Add(line);
        }

        private static void saveAndOpenImage()
        {
            var xMax = 512;
            var yMax = 200;

            //Declare the Bitmap, Graphics, and Pen in a using block so
            //they are all disposed properly when finished.
            using (var bmp = new Bitmap(xMax, yMax))
            using (var graphics = Graphics.FromImage(bmp))
            using (var pen = new Pen(Color.White, 2))
            {
                // 背景
                graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, xMax, yMax));

                // 畫線
                foreach (Line line in lines)
                {
                    graphics.DrawLine(pen, line.Start, line.End);
                }

                // 儲存圖片
                var currentDirectory = Directory.GetCurrentDirectory();
                var path = Path.Combine(currentDirectory, "coast.jpeg");
                bmp.Save(path, ImageFormat.Jpeg);

                // 打開圖片
                var iExplorePath = @"C:\Program Files\Internet Explorer\iexplore.exe";
                if (File.Exists(iExplorePath))
                {
                    Process.Start(iExplorePath, path);
                }
            }
        }
    }
}