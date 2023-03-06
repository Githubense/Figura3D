using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Figuras3D
{
    public class CNQAEC //Cosas Nuevas Que Aprendimos En Clase (y se supone que tenemos que implementar entonces aqui estan)
    {
        public Bitmap bitmap;
        public float Width, Height;
        public byte[] bits;
        Graphics g;
        int pixelFormatSize, stride;

        public CNQAEC(Size tamaño) 
        { 
            Init(tamaño.Width,tamaño .Height);
        }

        public void DrawPixel(int x, int y, Color c)
        {
            int res = (int)((x * pixelFormatSize) + (y * stride));

            bits[res + 0] = c.B;
            bits[res + 1] = c.G;
            bits[res + 2] = c.R;
            bits[res + 3] = c.A;

        }

        public void Init (int width, int height)
        {
            PixelFormat format;
            GCHandle handle;
            IntPtr bitPtr;
            int padding;

            format = PixelFormat.Format32bppArgb;

            Width = width;
            Height = height;
            pixelFormatSize = Image.GetPixelFormatSize(format) / 8;
            stride = width * pixelFormatSize;
            padding = (stride % 4);
            stride += padding == 0 ? 0 : 4 - padding;
            bits = new byte[stride * height];
            handle = GCHandle.Alloc(bits, GCHandleType.Pinned);
            bitPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0);
            bitmap = new Bitmap(width, height, stride, format, bitPtr);

            g = Graphics.FromImage(bitmap);
        }

        public void FastClear()
        {
            unsafe
            {
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* bits = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        bits[x + 0] = 0; //(byte) Blue;
                        bits[x + 1] = 0; //(byte) Green;
                        bits[x + 2] = 0; //(byte) Red;
                        bits[x + 3] = 0; //(byte) Alpha
                    }
                });
                bitmap.UnlockBits(bitmapData);
            }
        }

        public void Swap(ref Point p1, ref Point p2)
        {
            Point temp = p1;

            p1 = p2;
            p2 = temp;
        }

        public double[] Interpolate(int i0, double d0, int i1, double d1)
        {
            if (i0 == i1) return new double[] { d0 };
            double[] values = new double[i1 - i0 + 1];
            double a = (d1 - d0) / (i1 - i0);
            double d = d0;

            for (int i = i0; i < i1; i++)
            {
                values[i - i0] = d;
                d += a;
            }
            return values;
        }

        public void DrawLine(Point p1, Point p2, Color c)
        {

            if (Math.Abs(p2.X - p1.X) > Math.Abs(p2.Y - p1.Y))
            {
                if (p1.X > p2.X) Swap(ref p1, ref p2);
                Double[] ys = Interpolate(p1.X, p1.Y, p2.X, p2.Y);
                for (int x = p1.X; x <= p2.X; x++)
                {
                    DrawPixel(x, (int)ys[x - p1.X], c);
                }
            }
            else
            {
                if (p1.Y > p2.Y) Swap(ref p1, ref p2);
                Double[] xs = Interpolate(p1.Y, p1.X, p2.Y, p2.X);
                for (int y = p1.Y; y <= p2.Y; y++)
                {
                    DrawPixel((int)xs[y - p1.Y], y, c);
                }
            }
            //g.DrawLine(new Pen(c), p1, p2);
        }

        public void DrawWireFrameTriangle (Point p1, Point p2, Point p3, Color c)
        {
            DrawLine(p1, p2, c);
            DrawLine(p2, p3, c);
            DrawLine(p3, p1, c);
        }
    }
}
