using MinimalApi;


var builder = WebApplication.CreateBuilder(args);

//Service configuration offloaded to a static class
MyServices.Build(builder);

var app = builder.Build();

//Pipeline configuration offloaded to a static class
MyPipeline.Build(app);


//Endpoint configuration offloaded to a static class
MyEndPoints.Build(app);

app.Run();

