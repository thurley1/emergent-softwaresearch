
# The Challenge

An imaginary company stores a list of software products they use. They have stored the name and version of each product. They have asked us to create a simple website where users can type in a version number and receive a list of software products that are greater than the version they entered. If the user enters an invalid version, they should be notified that the version is not valid.

The software versions are stored as a string in [semver](semver.org) format. For this exercise, we're only concerned with major version, minor version, and patch (no pre-release or build) in the format [major].[minor].[patch]. The major, minor, and patch will always be non-negative integers. You may see versions like “2”, “1.5”, or “2.12.4”. The period is only used as a separator and does not represent a decimal point – 1.5 does not mean one and a half.

- "2" == "2.0" == "2.0.0"
- "2" < "2.0.1"
- "2" < "2.1"
- "2.0.1" < "2.1.0"

The imaginary company stores the software list as a C# object (provided below) that you can simply drop into your code – no need to call a database or REST service. This list of software is just a sample, assume the company will eventually switch to getting list from a database with thousands of softwares.

This site will be publicly available, so user authentication will not be required.

# Software Product List

    public class Software
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }

    public static class SoftwareManager
    {
        public static IEnumerable<Software> GetAllSoftware()
        {
            return new List<Software>
            {
                new Software
                {
                    Name = "MS Word",
                    Version = "13.2.1"
                },
                new Software
                {
                    Name = "AngularJS",
                    Version = "1.7.1"
                },
                new Software
                {
                    Name = "Angular",
                    Version = "8.1.13"
                },
                new Software
                {
                    Name = "React",
                    Version = "0.0.5"
                },
                new Software
                {
                    Name = "Vue.js",
                    Version = "2.6"
                },
                new Software
                {
                    Name = "Visual Studio",
                    Version = "2017.0.1"
                },
                new Software
                {
                    Name = "Visual Studio",
                    Version = "2019.1"
                },
                new Software
                {
                    Name = "Visual Studio Code",
                    Version = "1.35"
                },
                new Software
                {
                    Name = "Blazor",
                    Version = "0.7"
                }
            };
        }
    }