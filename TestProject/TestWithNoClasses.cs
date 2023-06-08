using Xunit;
using MindboxTest.WithNoClasses;
using MindboxTest.WithClasses;
using Xunit.Sdk;
using System;
using NuGet.Frameworks;

namespace TestProject
{
	public class TestWithNoClasses
	{
		[Fact]
		public void TestCirleArea()
		{
			//arrange
			double radius = 5.0;
			double expectedArea = 78.5;
			//act
			double actualArea = Math.Round(Calculations.CalculateArea(radius), 1);
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
			double actualArea = Math.Round(Calculations.CalculateArea(sideA, sideB, sideC), 1);
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
			bool actualIsRightTriangle = Calculations.isRightTriagle(sideA, sideB, sideC);
			//assert
			Assert.Equal(expectedIsRightTriangle, actualIsRightTriangle);
		}
	}
}