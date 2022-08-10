using MinimalApi;
using MinimalApi.Endpoints;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Service configuration offloaded to an extension method
builder.BuildApiServices();

var app = builder.Build();

//Pipeline configuration offloaded to an extension method
app.BuildPipeline();  

//Endpoint configuration offloaded to an extension method
app.BuildDemoEndpoints();

app.UseMiddleware<DemoMiddleware>();

app.Run();

Log.Information("Closing Down");
Log.CloseAndFlush();