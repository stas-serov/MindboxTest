namespace FigureService.Interfaces
{
	public interface IFigureProvider
	{
		byte[] GetFigure(string figureName, string color);

		bool AddFigure(string figureName, string color);

		bool DeleteFigure(string figureName, string color);
	}
}
