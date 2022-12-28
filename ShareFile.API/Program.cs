var builder = WebApplication.CreateBuilder(args)
                            .BuildSwagger()
                            .BuilderFlowConfiguration();


var app = builder.Build()
                 .SwaggerConfiguration()
                 .ApiFlowConfiguration();