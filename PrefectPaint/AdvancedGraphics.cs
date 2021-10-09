using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using PerfectPaint.Properties;

namespace AdvancedGraphics
{
    class Lines
    {
        public static void DDADrawLine(Bitmap bmpPad, int sourceX, int sourceY, int desX, int desY, Color color)
        {
            int ix, iy;
            float x, y, dx, dy, m;
            if(sourceX == desX)
            {
                ix = sourceX;
                if(sourceY > desY)
                    SwapInteger(ref sourceY, ref desY);
                for(iy = sourceY; iy < desY; iy++)
                    bmpPad.SetPixel(ix, iy, color);
                return;
            }
            else
            {
                dy = desY - sourceY;
                dx = desX - sourceX;
                m = dy / dx;
                if(Math.Abs(m) <= 1)
                {
                    if(sourceX > desX)
                    {
                        SwapInteger(ref sourceX, ref desX);
                        SwapInteger(ref sourceY, ref desY);
                    }
                    y = desY;
                    iy = Convert.ToInt32(Math.Round(y));
                    for(ix = sourceX; ix <= desX; ix++)
                    {
                        bmpPad.SetPixel(ix, iy, color);
                        y += m;
                        iy = Convert.ToInt32(Math.Round(y));
                    }

                }
                else
                {
                    if(sourceY > desY)
                    {
                        SwapInteger(ref sourceY, ref desY);
                        SwapInteger(ref sourceX, ref desX);
                    }
                    x = desX;
                    ix = Convert.ToInt32(Math.Round(x));
                    for(iy = sourceY; iy <= desY; iy++)
                    {
                        bmpPad.SetPixel(ix, iy, color);
                        x += m;
                        ix = Convert.ToInt32(Math.Round(x));
                    }

                }
            }
        }

        public static void MedianPointDrawLine(Bitmap bmpPad, int sourceX, int sourceY, int desX, int desY, Color color)
        {
            int x, y, dx, dy, d1, d2, D;            
            if(sourceX > desX)
                SwapInteger(ref sourceX, ref desX);
            if(sourceY > desY)
                SwapInteger(ref sourceY, ref desY);
            
            y = desY;
            dx = desX - sourceX;
            dy = desY - sourceY;
            d2 = 2 * (dy - dx);
            d1 = 2 * (dy);
            D = d1 + (d1 + d2) / 2;
            bmpPad.SetPixel(sourceX, sourceY, color);
            for(x = sourceX + 1; x <= desX; x++)
            {
                bmpPad.SetPixel(x, y, color);
                if(D <= 0)
                    D += d1;
                else
                {
                    D += d2;
                    y--;
                }
                
            }
        }

        protected static void SwapInteger(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}