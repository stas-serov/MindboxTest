using FigureLib;
using FigureLib.Figures;
using FigureService.Interfaces;
using Microsoft.Extensions.Logging;
using Orm.SQLServer;
using System;
using System.Linq;

namespace FigureService.Providers
{
	public class FigureProvider : IFigureProvider
	{
		private readonly ILogger logger;
		private readonly FigureDbContext dbContext;
		public FigureProvider(ILogger<FigureProvider> logger, FigureDbContext dbContext) 
		{ 
			this.logger = logger;
			this.dbContext = dbContext;
		}
		public bool AddFigure(string figureName, string color)
		{
			if(dbContext.Figures.FirstOrDefault(x => x.Name == figureName && x.Color == color) != null) 
			{
				return false;
			}
			dbContext.Add(new Orm.SQLServer.Models.Figure { Name = figureName, Color = color });
			dbContext.SaveChanges();
			return true;
		}

		public bool DeleteFigure(string figureName, string color)
		{
			if (dbContext.Figures.FirstOrDefault(x => x.Name == figureName && x.Color == color) == null)
			{
				return false;
			}
			Orm.SQLServer.Models.Figure figureToDelete = dbContext.Figures.First(x => x.Name == figureName && x.Color == color);
			dbContext.Remove(figureToDelete);
			dbContext.SaveChanges();
			return true;
		}

		public byte[] GetFigure(string figureName, string color)
		{
			if (dbContext.Figures.FirstOrDefault(x => x.Name == figureName && x.Color == color) == null)
			{
				return Array.Empty<byte>();
			}
			FigureAgent figureAgent = new FigureAgent();
			byte[] image = Array.Empty<byte>();
			IFigure figure;
			switch (figureName)
			{
				case nameof(Circle):
					figure = figureAgent.CreateFigure(50);
					break;
				case nameof(Triangle):
					figure = figureAgent.CreateFigure(100, 100, 100);
					break;
				case nameof(Rectangle):
					figure = figureAgent.CreateFigure(200, 100);
					break;
				default:
					throw new Exception("There is no figure with such name");
			}
			image = figure.Draw(color);
			return image;
		}
	}
}
