using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;
using System;
using System.IO;
using System.Linq;

namespace FigureLib.Figures
{
    public class Circle : Figure
    {
        private const int SIDESNUMBER = 1;

        private double _radius;

        public double radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Triangle's radius must be greater than 0!");
                }
                else
                {
                    _radius = value;
                }
            }
        }
        public Circle(params double[] sides) : base(sides)
        {
            radius = sides[0];
        }
        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }
        public new static bool Exists(params double[] sides)
        {
            if (sides.Length == SIDESNUMBER)
            {
                if (sides.First() > 0)
                {
                    return true;
                }
            }
            return false;
        }

		public override byte[] Draw(string color)
		{
			byte[] pictureBytes;
			int padding = 10;
			int pictureWidth = (int)(radius * 2) + padding * 2;
            int pictureHeight = (int)(radius * 2) + padding * 2;
			//формируем картинку
			SkiaBitmapExportContext bmp = new SkiaBitmapExportContext(pictureWidth, pictureHeight, 1f);
			//получаем канвас для рисования
			ICanvas canvas = bmp.Canvas;
			//рисуем рамку картинки
			canvas.StrokeColor = Colors.Black;
			canvas.StrokeSize = 1;
			canvas.DrawRectangle(0, 0, pictureWidth, pictureHeight);
            //рисуем круг
            canvas.FillColor = Color.FromRgba(color);
			canvas.FillEllipse((pictureWidth - pictureHeight) / 2 + padding, padding, (float)(radius * 2), (float)(radius * 2));
			//сохраняем картинку в массив байт
			using (MemoryStream ms = new MemoryStream())
			{
				bmp.WriteToStream(ms);
				pictureBytes = ms.ToArray();
			}
			return pictureBytes;
		}
	}
}
