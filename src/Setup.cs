using System;
using AlbedoTeam.Sdk.Documentation.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AlbedoTeam.Sdk.Documentation
{
    public static class Setup
    {
        public static IServiceCollection AddDocumentation(this IServiceCollection services, DocConfig docConfig)
        {
            if (docConfig is null) throw new ArgumentNullException(nameof(docConfig));
            if (docConfig.DocumentName is null) docConfig.DocumentName = "v1";
            
            services.AddOpenApiDocument(d =>
            {
                d.Title = docConfig.Title;
                d.Description = docConfig.Description;
                d.DocumentName = docConfig.DocumentName;
                d.ApiGroupNames = docConfig.GroupNames;
                d.Version = docConfig.Version;
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