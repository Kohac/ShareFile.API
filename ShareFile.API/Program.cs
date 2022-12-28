//WebApplicationBuilder setup
var builder = WebApplication.CreateBuilder(args)
                            .BuildSwagger()
                            .BuilderFlowConfiguration();
//Service injection setup (db access should be added)
builder.Services.InjectServices();

//WebApplication setup
var app = builder.Build()
                 .SwaggerConfiguration()
                 .ApiFlowConfiguration();