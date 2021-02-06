using System.Collections.Generic;

namespace AlbedoTeam.Sdk.Documentation.Models
{
    public class ApiDocument
    {
        public ApiDocument()
        {
            Versions = new Dictionary<string, ApiDocumentVersion>();
            DefaultVersion = default;
        }

        public string Title { get; set; }
        public string Description { get; set; }

        public ApiContact Contact { get; set; }

        public Dictionary<string, ApiDocumentVersion> Versions { get; }
        public ApiDocumentVersion DefaultVersion { get; private set; }

        public ApiDocument AddVersion(int majorVersion, int minorVersion = 0)
        {
            var documentVersion = new ApiDocumentVersion(majorVersion, minorVersion);
            Versions.TryAdd(documentVersion.ToString(), documentVersion);
            return this;
        }

        public ApiDocument AddDefaultVersion(int majorVersion = 1, int minorVersion = 0)
        {
            DefaultVersion = new ApiDocumentVersion(majorVersion, minorVersion);
            return this;
        }
    }
}