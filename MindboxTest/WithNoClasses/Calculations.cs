using System.Security.Principal;

namespace MindboxTest.WithNoClasses
{
    public static class Calculations
    {
        /// <summary>
        /// Method for calculating area of circle
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double CalculateArea(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException(message: "Radius must be greater than zero!");
            double area = Math.PI * radius * radius;
            return area;
        }

        /// <summary>
        /// Method for calculating area of triangle
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double CalculateArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException(message: "Triangle side must be greater than zero !");
            double p = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
            return area;
        }

        public static bool isRightTriagle(double sideA, double sideB, double sideC)
        {
            bool flag = false;
            if (Math.Pow(sideA, 2) == (Math.Pow(sideB, 2) + Math.Pow(sideC, 2)))
                flag = true;
            else if(Math.Pow(sideB, 2) == (Math.Pow(sideA, 2) + Math.Pow(sideC, 2)))
                flag = true;
            else if(Math.Pow(sideC, 2) == (Math.Pow(sideA, 2) + Math.Pow(sideB, 2)))
                flag = true;
            return flag;
		}

    }
}