using MindboxTest.WithClasses;
using MindboxTest.WithNoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
	public class TestWithClasses
	{
		[Fact]
		public void TestCirleArea()
		{
			//arrange
			double radius = 5.0;
			double expectedArea = 78.5;
			Circle circle = new Circle(radius);
			//act
			double actualArea = Math.Round(circle.CalculateArea(), 1);
			//assert
			Assert.Equal(expectedArea, actualArea);
		}

		[Fact]
		public void TestTriangleArea()
		{
			//arrange
			double sideA = 13.0;
			double sideB = 10.0;
			double sideC = 15.0;
			double expectedArea = 64.1;
			//act
			double actualArea = Math.Round(Triangle.CalculateArea(sideA, sideB, sideC), 1);
			//assert
			Assert.Equal(expectedArea, actualArea);
		}

		[Fact]
		public void TestIsRightTriangle()
		{
			//arrange
			double sideA = 3.0;
			double sideB = 4.0;
			double sideC = 5.0;
			bool expectedIsRightTriangle = true;
			//act
			bool actualIsRightTriangle = Triangle.isRightTriangle(sideA, sideB, sideC);
			//assert
			Assert.Equal(expectedIsRightTriangle, actualIsRightTriangle);
		}
	}
}
