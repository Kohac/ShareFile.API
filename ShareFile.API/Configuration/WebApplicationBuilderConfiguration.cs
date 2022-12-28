namespace ShareFile.API.Configuration;

public static class WebApplicationBuilderConfiguration
{
    public static WebApplicationBuilder BuilderFlowConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        return builder;
    }

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
        });
        return builder;
    }
}
