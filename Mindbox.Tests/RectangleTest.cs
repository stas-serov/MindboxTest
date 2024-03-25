using FigureLib.Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FigureLib.Tests
{
	[TestClass]
	public class RectangleTest
	{
		FigureAgent figureAgent = new FigureAgent();

		[TestMethod]
		[DataRow(5d, 4d)]
		[DataRow(2.6d, 5.9d)]
		public void ReactangleAreaTestNormal(double a, double b)
		{
			//arrange
			var figure = figureAgent.CreateFigure(a, b);
			double expectedArea = a * b;
			//act
			double actualArea = figure.GetArea();
			//assert
			Assert.AreEqual(expectedArea, actualArea);
		}

		[TestMethod]
		[DataRow(-5d, 12.4d)]
		[DataRow(85.3f, -1d)]
		[ExpectedException(typeof(ArgumentException))]
		public void ReactangleAreaTestException(double a, double b)
		{
			//arrange
			var figure = figureAgent.CreateFigure(a, b);
			//act
			//assert
		}

		[TestMethod]
		[DataRow(true, 43.2d, 14.6d)]
		[DataRow(false, 1.3d, 13d, 34.8d)]
		[DataRow(false, -54.4d, 22d)]
		public void ReactangleExistsTest(bool expectedResult, params double[] sides)
		{
			//arrange
			//act
			bool actualResult = Rectangle.Exists(sides);
			//assert
			Assert.AreEqual(expectedResult, actualResult);
		}
	}
}
