using Microsoft.Maui.Graphics.Skia;
using Microsoft.Maui.Graphics;
using System;
using System.IO;
using System.Linq;

namespace FigureLib.Figures
{
    public class Rectangle : Figure
    {
        private const int SIDESNUMBER = 2;

        private readonly double firstSide;

        private readonly double secondSide;

        public double a
        {
            get => firstSide;
        }

        public double b
        {
            get => secondSide;
        }

        public Rectangle(params double[] sides) : base(sides)
        {
            if (!Exists(sides))
            {
                throw new ArgumentException("Rectangle with such sides can't exist");
            }
            firstSide = sides[0];
            secondSide = sides[1];
        }

        public new static bool Exists(params double[] sides)
        {
            if (sides.Length == SIDESNUMBER)
            {
                if (sides.All(x => x > 0))
                {
                    return true;
                }
            }
            return false;
        }

        public override double GetArea()
        {
            return firstSide * secondSide;
        }

		public override byte[] Draw(string color)
		{
			byte[] pictureBytes;
			int padding = 10;
			int pictureWidth = (int)(firstSide + padding);
			int pictureHeight = (int)(secondSide + padding);
			//создаем картинки
			SkiaBitmapExportContext bmp = new SkiaBitmapExportContext(pictureWidth, pictureHeight, 1f);
			//получаем канвас для рисования
			ICanvas canvas = bmp.Canvas;
			//рисуем рамку картинки
			canvas.StrokeColor = Colors.Black;
			canvas.StrokeSize = 1;
			//рисуем прямоугольник
			canvas.DrawRectangle(0, 0, pictureWidth, pictureHeight);
			canvas.FillColor = Color.FromRgba(color);
			canvas.FillRectangle(padding, padding, pictureWidth - 2 * padding, pictureHeight - 2 * padding);
			//сохраняем картинку
			using (MemoryStream ms = new MemoryStream())
			{
				bmp.WriteToStream(ms);
				pictureBytes = ms.ToArray();
			}
			return pictureBytes;
		}
	}
}
