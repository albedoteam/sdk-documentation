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
        private DocConfig _docCfg;

        public DocumentationSetupTests()
        {
            _services = new ServiceCollection();
            _docCfg = new DocConfig
            {
                DocumentName = "Anything",
                Description = "Some description",
                Title = "Whatever",
                Version = "v123",
                GroupNames = new[] {"group1", "group2", "group3"}
            };
        }

        [Fact]
        public void AddDocumentation_Valid()
        {
            _services.AddDocumentation(new DocConfig());

            var bsp = _services.BuildServiceProvider();
            var scope = bsp.CreateScope();
            var registration = scope.ServiceProvider.GetService<OpenApiDocumentRegistration>();

            Assert.NotNull(registration);
        }

        [Fact]
        public void AddDocumentation_DocumentName_Valid()
        {
            _services.AddDocumentation(_docCfg);

            var bsp = _services.BuildServiceProvider();
            var scope = bsp.CreateScope();
            var registration = scope.ServiceProvider.GetService<OpenApiDocumentRegistration>();

            Assert.NotNull(registration);
            Assert.Equal(_docCfg.DocumentName, registration.DocumentName);
            Assert.Equal(_docCfg.DocumentName, registration.Generator.Settings.DocumentName);
        }

        [Fact]
        public void AddDocumentation_Title_Valid()
        {
            _services.AddDocumentation(_docCfg);

            var bsp = _services.BuildServiceProvider();
            var scope = bsp.CreateScope();
            var registration = scope.ServiceProvider.GetService<OpenApiDocumentRegistration>();

            Assert.NotNull(registration);
            Assert.Equal(_docCfg.Title, registration.Generator.Settings.Title);
        }

        [Fact]
        public void AddDocumentation_Description_Valid()
        {
            _services.AddDocumentation(_docCfg);

            var bsp = _services.BuildServiceProvider();
            var scope = bsp.CreateScope();
            var registration = scope.ServiceProvider.GetService<OpenApiDocumentRegistration>();

            Assert.NotNull(registration);
            Assert.Equal(_docCfg.Description, registration.Generator.Settings.Description);
        }

        [Fact]
        public void AddDocumentation_Version_Valid()
        {
            _services.AddDocumentation(_docCfg);

            var bsp = _services.BuildServiceProvider();
            var scope = bsp.CreateScope();
            var registration = scope.ServiceProvider.GetService<OpenApiDocumentRegistration>();

            Assert.NotNull(registration);
            Assert.Equal(_docCfg.Version, registration.Generator.Settings.Version);
        }

        [Fact]
        public void AddDocumentation_GroupNames_Valid()
        {
            _services.AddDocumentation(_docCfg);

            var bsp = _services.BuildServiceProvider();
            var scope = bsp.CreateScope();
            var registration = scope.ServiceProvider.GetService<OpenApiDocumentRegistration>();

            Assert.NotNull(registration);
            Assert.Equal(_docCfg.GroupNames, registration.Generator.Settings.ApiGroupNames);
        }

        [Fact]
        public void AddDocumentation_Null_Failure()
        {
            Assert.Throws<ArgumentNullException>(() => _services.AddDocumentation(null));
        }
    }
}