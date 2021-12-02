namespace MinimalAPI.Configuration
{
    public class SwaggerConfiguration
    {
        public static void AddSwagger(WebApplication app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API v1");
            });

        }
    }
}
