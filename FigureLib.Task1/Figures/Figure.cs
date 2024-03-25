namespace FigureLib.Figures
{
    public abstract class Figure : IFigure
    {
        protected readonly FigureType figureType;
        protected readonly double[] sides;

        public Figure(params double[] sides)
        {
            this.sides = sides;
            figureType = GetType(sides);
        }
        public abstract double GetArea();

        public abstract byte[] Draw(string color);

        public static bool Exists(params double[] sides)
        {
            FigureType figureType = GetType(sides);
            bool flag;
            switch (figureType)
            {
                case FigureType.Circle:
                    flag = Circle.Exists(sides);
                    break;
                case FigureType.Triangle:
                    flag = Triangle.Exists(sides);
                    break;
                case FigureType.Rectangle:
                    flag = Rectangle.Exists(sides);
                    break;
                default:
                    flag = false;
                    break;
            }
            return flag;
        }

        public static FigureType GetType(params double[] sides)
        {
            FigureType figureType;
            switch (sides.Length)
            {
                case 1:
                    figureType = FigureType.Circle;
                    break;
                case 2:
                    figureType = FigureType.Rectangle;
                    break;
                case 3:
                    figureType = FigureType.Triangle;
                    break;
                default:
                    figureType = FigureType.Unknown;
                    break;
            }
            return figureType;
        }
    }
}