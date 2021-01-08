using System;
using System.Diagnostics;
using AlbedoTeam.Sdk.Documentation.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using NSwag.AspNetCore;

namespace AlbedoTeam.Sdk.Documentation.Tests
{
    public class DocumentationSetupTests
    {
        private IServiceCollection _services;

        public DocumentationSetupTests()
        {
            _services = new ServiceCollection();
        }

        [Fact]
        public void AddDocumentation_Valid()
        {
            _services.AddDocumentation(cfg =>
            {
                cfg.DocumentName = "Anything";
                cfg.Description = "Some description";
                cfg.Title = "Whatever";
                cfg.Version = "v123";
                cfg.GroupNames = new[] {"group1", "group2", "group3"};
            });

            var bsp = _services.BuildServiceProvider();
            var scope = bsp.CreateScope();
            var registration = scope.ServiceProvider.GetService<OpenApiDocumentRegistration>();

            Assert.NotNull(registration);
        }
        
        [Fact]
        public void AddDocumentation_DocumentName_Null_Valid_Default()
        {
            _services.AddDocumentation(cfg =>
            {
                cfg.DocumentName = null;
                cfg.Description = "Some description";
                cfg.Title = "Whatever";
                cfg.Version = "v123";
                cfg.GroupNames = new[] {"group1", "group2", "group3"};
            });

            var bsp = _services.BuildServiceProvider();
            var scope = bsp.CreateScope();
            var registration = scope.ServiceProvider.GetService<OpenApiDocumentRegistration>();

            Assert.NotNull(registration);
            Assert.Equal("v1", registration.DocumentName);
            Assert.Equal("v1", registration.Generator.Settings.DocumentName);
        }

        [Fact]
        public void AddDocumentation_DocumentName_Valid()
        {
            _services.AddDocumentation(cfg =>
            {
                cfg.DocumentName = "Anything";
                cfg.Description = "Some description";
                cfg.Title = "Whatever";
                cfg.Version = "v123";
                cfg.GroupNames = new[] {"group1", "group2", "group3"};
            });

            var bsp = _services.BuildServiceProvider();
            var scope = bsp.CreateScope();
            var registration = scope.ServiceProvider.GetService<OpenApiDocumentRegistration>();

            Assert.NotNull(registration);
            Assert.Equal("Anything", registration.DocumentName);
            Assert.Equal("Anything", registration.Generator.Settings.DocumentName);
        }

        [Fact]
        public void AddDocumentation_Title_Valid()
        {
            _services.AddDocumentation(cfg =>
            {
                cfg.DocumentName = "Anything";
                cfg.Description = "Some description";
                cfg.Title = "Whatever";
                cfg.Version = "v123";
                cfg.GroupNames = new[] {"group1", "group2", "group3"};
            });

            var bsp = _services.BuildServiceProvider();
            var scope = bsp.CreateScope();
            var registration = scope.ServiceProvider.GetService<OpenApiDocumentRegistration>();

            Assert.NotNull(registration);
            Assert.Equal("Whatever", registration.Generator.Settings.Title);
        }

        [Fact]
        public void AddDocumentation_Description_Valid()
        {
            _services.AddDocumentation(cfg =>
            {
                cfg.DocumentName = "Anything";
                cfg.Description = "Some description";
                cfg.Title = "Whatever";
                cfg.Version = "v123";
                cfg.GroupNames = new[] {"group1", "group2", "group3"};
            });

            var bsp = _services.BuildServiceProvider();
            var scope = bsp.CreateScope();
            var registration = scope.ServiceProvider.GetService<OpenApiDocumentRegistration>();

            Assert.NotNull(registration);
            Assert.Equal("Some description", registration.Generator.Settings.Description);
        }

        [Fact]
        public void AddDocumentation_Version_Valid()
        {
            _services.AddDocumentation(cfg =>
            {
                cfg.DocumentName = "Anything";
                cfg.Description = "Some description";
                cfg.Title = "Whatever";
                cfg.Version = "v123";
                cfg.GroupNames = new[] {"group1", "group2", "group3"};
            });

            var bsp = _services.BuildServiceProvider();
            var scope = bsp.CreateScope();
            var registration = scope.ServiceProvider.GetService<OpenApiDocumentRegistration>();

            Assert.NotNull(registration);
            Assert.Equal("v123", registration.Generator.Settings.Version);
        }

        [Fact]
        public void AddDocumentation_GroupNames_Valid()
        {
            _services.AddDocumentation(cfg =>
            {
                cfg.DocumentName = "Anything";
                cfg.Description = "Some description";
                cfg.Title = "Whatever";
                cfg.Version = "v123";
                cfg.GroupNames = new[] {"group1", "group2", "group3"};
            });

            var bsp = _services.BuildServiceProvider();
            var scope = bsp.CreateScope();
            var registration = scope.ServiceProvider.GetService<OpenApiDocumentRegistration>();

            Assert.NotNull(registration);
            Assert.Equal(new[] {"group1", "group2", "group3"}, registration.Generator.Settings.ApiGroupNames);
        }

        [Fact]
        public void AddDocumentation_Null_Failure()
        {
            Assert.Throws<ArgumentNullException>(() => _services.AddDocumentation(null));
        }
    }
}