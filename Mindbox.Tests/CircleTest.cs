using FigureLib.Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FigureLib.Tests
{
	[TestClass]
	public class CircleTest
	{
		FigureAgent figureAgent = new FigureAgent();

		[TestMethod]
		[DataRow(5d)]
		[DataRow(1.3d)]
		public void CircleAreaTestNormal(double radius)
		{
			//arrange
			var figure = figureAgent.CreateFigure(radius);
			double expectedArea = radius * radius * Math.PI;
			//act
			double actualArea = figure.GetArea();
			//assert
			Assert.AreEqual(expectedArea, actualArea);
		}

		[TestMethod]
		[DataRow(0d)]
		[DataRow(-1d)]
		[ExpectedException(typeof(ArgumentException))]
		public void CircleAreaTestException(double radius)
		{
			//arrange
			var figure = figureAgent.CreateFigure(radius);
			//act
			//assert
		}

		[TestMethod]
		[DataRow(true, 43.2d)]
		[DataRow(false, -1.3d)]
		[DataRow(false, 54.4d, 22d)]
		public void CircleExistsTest(bool expectedResult, params double[] sides)
		{
			//arrange
			//act
			bool actualResult = Circle.Exists(sides);
			//assert
			Assert.AreEqual(expectedResult, actualResult);
		}
	}
}