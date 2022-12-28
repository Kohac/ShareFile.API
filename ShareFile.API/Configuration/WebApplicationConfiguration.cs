using Microsoft.AspNetCore.StaticFiles;

namespace ShareFile.API.Configuration;

public static class WebApplicationConfiguration
{
    public static WebApplication SwaggerConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "FileShareAPI");
                o.RoutePrefix = string.Empty;
            });
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseSwaggerUI(o =>
            {
                var path = app.Configuration.GetSection("SwaggerSetup").GetValue<string>("Path");
                o.SwaggerEndpoint($"{path}/swagger/v1/swagger.json", "FileShareAPI");
                o.RoutePrefix = string.Empty;
            });
        }
        return app;
    }

    public static WebApplication ApiFlowConfiguration(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
        return app;
    }
}
