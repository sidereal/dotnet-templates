using MinimalApi;

var builder = WebApplication.CreateBuilder(args);

//Service configuration offloaded to an extension method
builder.BuildMyServices();

var app = builder.Build();

//Pipeline configuration offloaded to an extension method
app.BuildMyPipeline();  

//Endpoint configuration offloaded to an extension method
app.BuildMyEndpoints();

app.Run();