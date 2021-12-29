using SoftwareSearch.Domain.Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SoftwareSearch.Domain.Software.Services
{
    public class SoftwareSearchStatic : ISoftwareSearch, ISemverVersionValidator
    {
        public IEnumerable<SoftwareInfo> SearchVersions(string SearchText)
        {
            ValidateVersionString(SearchText);
            var versions = SoftwareManager.GetAllSoftware();
            var parsedVersion = SearchText.Split('.');

            var majorSearchVal = SetVersionNode(parsedVersion, 1, 0);
            if (null == majorSearchVal)
                return Enumerable.Empty<SoftwareInfo>();

            var majors = versions
                .Where(maj => null != maj.Major && maj.Major >= majorSearchVal)
                .ToList();

            var minorSearchVal = SetVersionNode(parsedVersion, 2, 1);
            if (null == minorSearchVal)
                return majors;

            var minors = majors
                .Where(min => null == min.Minor || min.Major > majorSearchVal || (min.Major == majorSearchVal && min.Minor >= minorSearchVal))
                .ToList();

            var patchSearchVal = SetVersionNode(parsedVersion: parsedVersion, minLength: 3, versionPosition: 2);
            if (null == patchSearchVal)
                return minors;

            return minors
                .Where(pat => null == pat.Patch || pat.Minor > patchSearchVal || (pat.Minor == minorSearchVal && pat.Patch >= patchSearchVal))
                .ToList();
        }

        private int? SetVersionNode(string[] parsedVersion, int minLength, int versionPosition)
        {
            if (parsedVersion.Length >= minLength)
            {
                if (int.TryParse(parsedVersion[versionPosition], out int i))
                    return i;
            }

            return null;
        }

        public void ValidateVersionString(string versionString)
        {
            var pattern = @"^(\d|[1-9]\d*)(\.(\d|[1-9]\d*))?(\.(\d|[1-9]\d*))?$";
            var m = Regex.Match(versionString, pattern);
            if (!m.Success)
                throw new InvalidOperationException($"The provided version string ({versionString}) is not in a valid format");
        }
    }
}
