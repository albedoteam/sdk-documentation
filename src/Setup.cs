using System;
using AlbedoTeam.Sdk.Documentation.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using NSwag;

namespace AlbedoTeam.Sdk.Documentation
{
    public static class Setup
    {
        public static IServiceCollection AddDocumentation(
            this IServiceCollection services,
            Action<ApiDocument> configureDocumentation)
        {
            if (configureDocumentation == null)
                throw new ArgumentNullException(nameof(configureDocumentation));

            var apiDocument = new ApiDocument();
            configureDocumentation.Invoke(apiDocument);

            foreach (var documentVersion in apiDocument.Versions)
                services.AddOpenApiDocument(d =>
                {
                    var version = documentVersion.Key;

                    d.Title = apiDocument.Title;
                    d.Description = apiDocument.Description;
                    d.DocumentName = version;
                    d.ApiGroupNames = new[] {version};
                    d.Version = version;

                    d.PostProcess = document =>
                    {
                        document.Info.Contact = new OpenApiContact
                        {
                            Name = apiDocument.Contact.Name,
                            Email = apiDocument.Contact.Email,
                            Url = apiDocument.Contact.Url
                        };
                    };
                });

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;

                options.DefaultApiVersion = new ApiVersion(
                    apiDocument.DefaultVersion.MajorVersion,
                    apiDocument.DefaultVersion.MinorVersion);

                options.ApiVersionReader = new UrlSegmentApiVersionReader();

                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        public static IApplicationBuilder UseDocumentation(this IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3();

            return app;
        }
    }
}