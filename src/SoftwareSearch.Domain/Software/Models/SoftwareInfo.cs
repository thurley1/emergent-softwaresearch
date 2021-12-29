namespace SoftwareSearch.Domain.Software.Models
{
    public class SoftwareInfo
    {
        public string Name { get; set; }
        public string Version { get; set; }

        public int? Major
        {
            get
            {
                var parsedVersion = ParseVersion();
                if (parsedVersion.Length <= 0)
                    return null;
                if (int.TryParse(parsedVersion[0], out int i))
                    return i;
                return null;
            }
        }

        public int? Minor
        {
            get
            {
                var parsedVersion = ParseVersion();
                if (parsedVersion.Length <= 1)
                    return null;
                if (int.TryParse(parsedVersion[1], out int i))
                    return i;
                return null;
            }
        }

        public int? Patch
        {
            get
            {
                var parsedVersion = ParseVersion();
                if (parsedVersion.Length <= 2)
                    return null;
                if (int.TryParse(parsedVersion[2], out int i))
                    return i;
                return null;
            }
        }

        private string[] ParseVersion()
        {
            return Version.Split('.');
        }
    }
}
