using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema.Generation;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.Processors.Security;

namespace CustomerService.API.SwaggerConfig
{
    public static class SwaggerConfiguration
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "v1";
                document.ApiGroupNames = new[] { "1" };
                document.DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;

                document.AddSecurity("oauth2", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        AuthorizationCode = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = "https://localhost:5001/connect/authorize",
                            TokenUrl = "https://localhost:5001/connect/token",
                            Scopes = new Dictionary<string, string>
                            {
                                {"CustomerService.API", "Customer Service"},
                                {"AccountService.API", "check to access account api when get customer details"}
                            }
                        },
                    }
                });

                document.OperationProcessors.Add(new OperationSecurityScopeProcessor("oauth2"));
            });
        }

        public static void UseVersionedSwagger(this IApplicationBuilder app)
        {
            app.UseOpenApi(config =>
            {
                config.PostProcess = (document, request) =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Title = "CustomerService.API",
                        Description = "CustomerService API",
                        Contact = new OpenApiContact
                        {
                            Name = "Nasr Aldin",
                            Email = "ns@nasraldin.com",
                            Url = "https://github.com/nasraldin"
                        },
                    };
                };
            });

            // Add Swagger UI
            app.UseSwaggerUi3(settings =>
            {
                settings.OAuth2Client = new OAuth2ClientSettings
                {
                    ClientId = "swagger.api",
                    AppName = "Swagger UI",
                    ClientSecret = null,
                    UsePkceWithAuthorizationCodeGrant = true
                };
            });
        }
    }
}
