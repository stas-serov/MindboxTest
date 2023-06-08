namespace MindboxTest.WithClasses
{
	public class Circle
	{
		public double radius {  get; set; }

		public Circle(double radius) 
		{
			if (radius <= 0)
				throw new ArgumentException(message: "Circle radius must be greater than zero!");
			this.radius = radius;
		}

		public double CalculateArea()
		{ 
			return Math.PI * radius * radius; 
		}

		public static double CalcualteArea(double radius)
		{
			return Math.PI * radius * radius;
		}
	}
}
