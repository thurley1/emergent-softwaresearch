using SoftwareSearch.Domain.Software.Models;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareSearch.Domain.Software.Services
{
    public class SoftwareManager : ISoftwareManager
    {
        public IEnumerable<SoftwareInfo> GetAllSoftware()
        {
            return new List<SoftwareInfo>
            {
                new SoftwareInfo
                {
                    Name = "MS Word",
                    Version = "13.2.1"
                },
                new SoftwareInfo
                {
                    Name = "AngularJS",
                    Version = "1.7.1"
                },
                new SoftwareInfo
                {
                    Name = "Angular",
                    Version = "8.1.13"
                },
                new SoftwareInfo
                {
                    Name = "React",
                    Version = "0.0.5"
                },
                new SoftwareInfo
                {
                    Name = "Vue.js",
                    Version = "2.6"
                },
                new SoftwareInfo
                {
                    Name = "Visual Studio",
                    Version = "2017.0.1"
                },
                new SoftwareInfo
                {
                    Name = "Visual Studio",
                    Version = "2019.1"
                },
                new SoftwareInfo
                {
                    Name = "Visual Studio Code",
                    Version = "1.35"
                },
                new SoftwareInfo
                {
                    Name = "Blazor",
                    Version = "0.7"
                }
            };
        }

        public IEnumerable<SoftwareInfo> SearchVersions(string SearchText)
        {
            var versions = GetAllSoftware();
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
                .Where(pat => null == pat.Patch || pat.Minor > patchSearchVal || (pat.Minor == minorSearchVal &&  pat.Patch >= patchSearchVal))
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
    }
}
