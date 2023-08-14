using Swashbuckle.AspNetCore.SwaggerUI;

namespace KnowlyApp.WebAPI.Extentions
{
    public static class AppExtension
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Knowly API");
                options.DefaultModelRendering(ModelRendering.Model);
            });
        }
    }
}