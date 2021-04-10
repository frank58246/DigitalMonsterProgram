## 專案內容
數碼寶貝第一季第十集，光子郎的電腦程式<br/>
![光子郎的電腦](/Image/snap.png) <br/>
C#版本<br/>
```
        private static float s;

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
        
        private static void fractal(float x0, float x1, float y0, float y1, int sp)
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
```
輸出<br/>
![輸出](/Image/coast.jpeg) 


## 參考來源
[怎样评价《数码宝贝》第一部中的泉光子郎的编程水平？](https://www.zhihu.com/question/30290082) 
<br/>
[X-BASIC リファレンス](http://ww3.enjoy.ne.jp/~zoomark/ip/xb/xb_frm.html)