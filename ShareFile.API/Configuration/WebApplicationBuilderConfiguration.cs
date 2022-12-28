using System.Reflection;

namespace ShareFile.API.Configuration;

public static class WebApplicationBuilderConfiguration
{
    /// <summary>
    /// Builder flow (add controllers etc.)
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    /// <returns>WebApplicationBuilder</returns>
    public static WebApplicationBuilder BuilderFlowConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        return builder;
    }
    /// <summary>
    /// Build swagger
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    /// <returns>WebApplicationBuilder</returns>
    public static WebApplicationBuilder BuildSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Description = "Api to share files.",
                    Title = "Share Files",
                });
            var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
        });
        return builder;
    }
}
