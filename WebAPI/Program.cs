using FigureService.Interfaces;
using FigureService.Providers;
using Microsoft.EntityFrameworkCore;
using Orm.SQLServer;

var builder = WebApplication.CreateBuilder(args);

if(builder.Environment.IsDevelopment())
{
	builder.Configuration.AddJsonFile("appsettings.Development.json");
}
else
{
	builder.Configuration.AddJsonFile("appsettings.json");
}

builder.Services.AddControllers();

builder.Services.AddLogging();

string connectionString = builder.Configuration.GetConnectionString("SQLServer");

builder.Services.AddDbContext<FigureDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IFigureProvider, FigureProvider>();

builder.Logging.AddConsole();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
