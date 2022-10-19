using Serilog;
namespace MinimalApi.ExtensionMethods;

public static partial class Extensions
{
    public static void BuildPipeline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseSerilogRequestLogging();

        app.UseHttpsRedirection();
    }
}

