﻿using Microsoft.AspNetCore.StaticFiles;

namespace ShareFile.API.Configuration;

public static class WebApplicationConfiguration
{
    /// <summary>
    /// Use swagger
    /// </summary>
    /// <param name="app">WebApplication</param>
    /// <returns>WebApplication</returns>
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
    /// <summary>
    /// Create flow for WebApplication (every use + run)
    /// </summary>
    /// <param name="app">WebApplication</param>
    /// <returns>WebApplication</returns>
    public static WebApplication ApiFlowConfiguration(this WebApplication app)
    {
        app.UseCors("FilePolicy");
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
        return app;
    }
}
