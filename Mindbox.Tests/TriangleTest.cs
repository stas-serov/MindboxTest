using FigureLib.Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FigureLib.Tests
{
	[TestClass]
	public class TriangleTest
	{
		FigureAgent figureService = new FigureAgent();

		[TestMethod]
		[DataRow(7d, 8d, 9d)]
		[DataRow(2.2d, 9.32d, 8.9d)]
		public void TriangleAreaTestNormal(double a, double b, double c)
		{
			//arrange
			var figure = figureService.CreateFigure(a, b, c);
			double p = (a + b + c) / 2;
			double expectedArea = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
			//act
			double actualArea = figure.GetArea();
			//assert
			Assert.AreEqual(expectedArea, actualArea);
		}

		[TestMethod]
		[DataRow(7d, 8d, 21d)]
		[DataRow(2.2d, 9.32d, -8.9d)]
		[ExpectedException(typeof(ArgumentException))]
		public void TriangleAreaTestException(double a, double b, double c)
		{
			//arrange
			var figure = figureService.CreateFigure(a, b, c);
			//act
			//assert
		}

		[TestMethod]
		[DataRow(true, 30.2d, 14.6d, 22.8d)]
		[DataRow(false, 1.3d, 13d, 34.8d, 85.3d)]
		[DataRow(false, -54.4d, 22d, 11.9d)]
		public void TriangleExistsTest(bool expectedResult, params double[] sides)
		{
			//arrange
			//act
			bool actualResult = Triangle.Exists(sides);
			//assert
			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod]
		[DataRow(7d, 8d, 9d, false)]
		[DataRow(3d, 4d, 5d, true)]
		public void TriangleIsRigthTest(double a, double b, double c, bool expectedResult)
		{
			//arrange
			var figure = figureService.CreateFigure(a, b, c);
			//act
			bool actualResult = (figure as Triangle).IsRigth();
			//assert
			Assert.AreEqual(expectedResult, actualResult);
		}
	}
}
