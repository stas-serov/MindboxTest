using FigureLib.Figures;
using System;

namespace FigureLib
{
	public class FigureAgent
	{
		public Figure CreateFigure(params double[] sides)
		{
			Figure figure;
			if(Figure.Exists(sides))
			{
				FigureType type = Figure.GetType(sides);
				switch(type)
				{
					case FigureType.Circle:
						figure = new Circle(sides); 
						break;
					case FigureType.Triangle: 
						figure = new Triangle(sides); 
						break;
					case FigureType.Rectangle: 
						figure = new Rectangle(sides);
						break;
					default:
						throw new ArgumentException("Unknown figure type for these sides");
				}
				return figure;
			}
			else
			{
				throw new ArgumentException("Such figure can't be created");
			}	
		}
	}
}
