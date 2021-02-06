namespace AlbedoTeam.Sdk.Documentation.Models
{
    public readonly struct ApiDocumentVersion
    {
        public int MajorVersion { get; }
        public int MinorVersion { get; }

        public ApiDocumentVersion(int major = 1, int minor = 0)
        {
            MajorVersion = major;
            MinorVersion = minor;
        }

        public override string ToString()
        {
            var version = $"v{MajorVersion}";
            if (MinorVersion > 0)
                version += $".{MinorVersion}";

            return version;
        }
    }
}