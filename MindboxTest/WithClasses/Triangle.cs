using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindboxTest.WithClasses
{
	public class Triangle
	{
		public double sideA {  get; set; }

		public double sideB { get; set; }

		public double sideC { get; set; }

		public Triangle(double sideA, double sideB, double sideC)
		{
			if (sideA <= 0 ||  sideB<= 0 || sideC <= 0)
				throw new ArgumentException(message: "Triangle side must be greater than zero !");
			this.sideA = sideA;
			this.sideB = sideB;
			this.sideC = sideC;
		}

		public double CalculateArea()
		{
			double p = (sideA + sideB + sideC) / 2;
			double area = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
			return area;
		}

		public bool isRightTriangle()
		{
			bool flag = false;
			if (Math.Pow(sideA, 2) == (Math.Pow(sideB, 2) + Math.Pow(sideC, 2)))
				flag = true;
			else if (Math.Pow(sideB, 2) == (Math.Pow(sideA, 2) + Math.Pow(sideC, 2)))
				flag = true;
			else if (Math.Pow(sideC, 2) == (Math.Pow(sideA, 2) + Math.Pow(sideB, 2)))
				flag = true;
			return flag;
		}

		public static double CalculateArea(double sideA, double sideB, double sideC)
		{
			double p = (sideA + sideB + sideC) / 2;
			double area = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
			return area;
		}

		public static bool isRightTriangle(double sideA, double sideB, double sideC)
		{
			bool flag = false;
			if (Math.Pow(sideA, 2) == (Math.Pow(sideB, 2) + Math.Pow(sideC, 2)))
				flag = true;
			else if (Math.Pow(sideB, 2) == (Math.Pow(sideA, 2) + Math.Pow(sideC, 2)))
				flag = true;
			else if (Math.Pow(sideC, 2) == (Math.Pow(sideA, 2) + Math.Pow(sideB, 2)))
				flag = true;
			return flag;
		}
	}
}
