namespace MinimalApi
{
    public static class MyPipeline
    {
        public static void BuildMyPipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
        }
    }
}
