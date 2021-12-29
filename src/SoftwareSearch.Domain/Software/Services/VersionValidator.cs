using System;
using System.Text.RegularExpressions;

namespace SoftwareSearch.Domain.Software.Services
{
    public class VersionValidator : ISemverVersionValidator
    {
        public void ValidateVersionString(string versionString)
        {
            var pattern = @"^(\d|[1-9]\d*)(\.(\d|[1-9]\d*))?(\.(\d|[1-9]\d*))?$";
            var m = Regex.Match(versionString, pattern);
            if (!m.Success)
                throw new InvalidOperationException($"The provided version string ({versionString}) is not in a valid format");
        }
    }
}
