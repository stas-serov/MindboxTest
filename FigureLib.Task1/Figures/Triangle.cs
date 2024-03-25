using Microsoft.Maui.Graphics.Skia;
using Microsoft.Maui.Graphics;
using System;
using System.IO;
using System.Linq;

namespace FigureLib.Figures
{
    public class Triangle : Figure
    {
        private const int SIDESNUMBER = 3;

        private readonly double firstSide;

        private readonly double secondSide;

        private readonly double thirdSide;

        public double a
        {
            get => firstSide;
        }

        public double b
        {
            get => secondSide;
        }

        public double c
        {
            get => thirdSide;
        }

        public Triangle(params double[] sides) : base(sides)
        {
            if (!Exists(sides))
            {
                throw new ArgumentException("Triangle with such sides can't exist");
            }
            firstSide = sides[0];
            secondSide = sides[1];
            thirdSide = sides[2];
        }

        public override double GetArea()
        {
            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }

        public bool IsRigth()
        {
            if (a * a == b * b + c * c)
                return true;
            else if (b * b == a * a + c * c)
                return true;
            else if (c * c == b * b + a * a)
                return true;
            else
                return false;
        }

        public new static bool Exists(params double[] sides)
        {
            if (sides.Length == SIDESNUMBER)
            {
                if (sides[0] < sides[1] + sides[2] && sides[1] < sides[0] + sides[2] && sides[2] < sides[0] + sides[1])
                {
                    if (sides.All(x => x > 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

		public override byte[] Draw(string color)
		{
			byte[] pictureBytes;
			int padding = 10;
            int pictureWidth = (int)sides.Max() + padding;
			int pictureHeight = (int)sides.Max() + padding;
			//создаем картинку
			SkiaBitmapExportContext bmp = new SkiaBitmapExportContext(pictureWidth, pictureHeight, 1f);
			//получаем канвас для рисования
			ICanvas canvas = bmp.Canvas;
			//рисуем рамку
			canvas.StrokeColor = Colors.Black;
			canvas.StrokeSize = 1;
			canvas.DrawRectangle(0, 0, pictureWidth, pictureHeight);
			//рисуем треугольник
			PathF path = new PathF();
			path.MoveTo(padding, pictureHeight - padding);
			path.LineTo(pictureWidth / 2, padding);
			path.LineTo(pictureWidth - padding, pictureHeight - padding);
			path.LineTo(padding, pictureHeight - padding);
            canvas.FillColor = Color.FromRgba(color);
			canvas.FillPath(path);
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
