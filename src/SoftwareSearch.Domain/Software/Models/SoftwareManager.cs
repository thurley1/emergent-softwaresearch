using System.Collections.Generic;

namespace SoftwareSearch.Domain.Software.Models
{
    public static class SoftwareManager
    {
        public static IEnumerable<SoftwareInfo> GetAllSoftware()
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
    }
}
