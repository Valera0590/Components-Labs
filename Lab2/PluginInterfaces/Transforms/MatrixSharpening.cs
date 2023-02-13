using PluginInterface;
using System;
using System.Drawing;

namespace Transforms
{
    [Version(1, 3)]
    public class MatrixSharpening : IPlugin
    {
        public string Name
        {
            get
            {
                return "Матричный фильтр улучшения чёткости";
            }
        }

        public string Author
        {
            get
            {
                return "Valeriy K";
            }
        }

        public void Transform(Bitmap bitmap)
        {
            const int N = 3;
            //int[,] f = new int[N, N] {
            //    {-1, -1, -1},
            //    {-1, 9, -1},
            //    {-1, -1, -1}};
            int[,] f = new int[N, N] {
                { 0, -1, 0},
                { 0, 3, 0},
                { 0, -1, 0}};
            //int[,] f = new int[N, N] {
            //    { -2, -1, 0},
            //    { -1, 1, 1},
            //    { 0, 1, 2}};

            for (int x = 0; x < bitmap.Width; ++x)
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    int r=0,g=0,b=0, alphaCurrent = bitmap.GetPixel(x, y).A;
                    for (int i = 0; i < N; ++i)
                        for (int j = 0; j < N; ++j)
                        {
                            if (x + i - 1 > -1 && x + i - 1 < bitmap.Width && y + j - 1 > -1 && y + j - 1 < bitmap.Height)
                            {
                                r += f[i, j] * bitmap.GetPixel(x + i - 1, y + j - 1).R;
                                g += f[i, j] * bitmap.GetPixel(x + i - 1, y + j - 1).G;
                                b += f[i, j] * bitmap.GetPixel(x + i - 1, y + j - 1).B;
                            }
                            else
                            {
                                r += f[i, j] * bitmap.GetPixel(x, y).R;
                                g += f[i, j] * bitmap.GetPixel(x, y).G;
                                b += f[i, j] * bitmap.GetPixel(x, y).B;
                            }
                        }
                    if (r < 0) r = 0;
                    if (r >= 256) r = 255;
                    if (g < 0) g = 0;
                    if (g >= 256) g = 255;
                    if (b < 0) b = 0;
                    if (b >= 256) b = 255;
                    bitmap.SetPixel(x, y, Color.FromArgb(alphaCurrent, r, g, b));
                }
        }
    }
}
