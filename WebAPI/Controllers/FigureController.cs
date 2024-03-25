using FigureService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FigureController : ControllerBase
	{
		private readonly ILogger logger;

		private readonly IFigureProvider figureProvider;

		public FigureController(ILogger<FigureController> logger, IFigureProvider figureProvider)
		{
			this.logger = logger;
			this.figureProvider = figureProvider;
		}

		[HttpGet]
		[Route("{figure:required}/{color:required}")]
		public IResult GetFigure([FromRoute] string figure, [FromRoute] string color)
		{
			byte[] figureBytes = figureProvider.GetFigure(figure, color);
			if(figureBytes == Array.Empty<byte>())
			{
				return Results.NotFound("Such figure does not exist");
			}
			else
			{
				return Results.File(figureBytes, "image/jpeg");
			}
		}

		[HttpPost]
		[Route("{figure:required}/{color:required}")]
		public IResult PostFigure([FromRoute] string figure, [FromRoute] string color)
		{
			bool result = figureProvider.AddFigure(figure, color);
			if(result)
			{
				return Results.Ok();
			}
			else
			{
				return Results.BadRequest("Such figure already exists");
			}
		}

		[HttpDelete]
		[Route("{figure:required}/{color:required}")]
		public IResult DeleteFigure([FromRoute] string figure, [FromRoute] string color)
		{
			bool result = figureProvider.DeleteFigure(figure, color);
			if (result)
			{
				return Results.Ok();
			}
			else
			{
				return Results.BadRequest("There is no such figure");
			}
		}

		[HttpPut]
		[Route("{figure:required}/{color:required}")]
		public IResult PutFigure([FromRoute] string figure, [FromRoute] string color)
		{
			throw new NotImplementedException();
		}
	}
}
