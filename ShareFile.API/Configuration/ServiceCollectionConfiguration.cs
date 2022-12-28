namespace ShareFile.API.Configuration;

public static class ServiceCollectionConfiguration
{
    public static IServiceCollection InjectServices(this ServiceCollection services)
    {
        services.AddSingleton<FileExtensionContentTypeProvider>();
        return services;
    }
}
