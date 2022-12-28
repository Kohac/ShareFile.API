namespace ShareFile.API.Configuration;

public static class ServiceCollectionConfiguration
{
    public static void InjectServices(this IServiceCollection services)
    {
        services.AddSingleton<FileExtensionContentTypeProvider>();
    }
}
