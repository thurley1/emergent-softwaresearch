using FluentAssertions;
using NSubstitute;
using SoftwareSearch.Domain.Software.Services;
using Xunit;

namespace SoftwareSearch.Domain.Tests.Services
{
    public class SoftwareSearchStaticTests
    {
        [Fact]
        public void SearchVersion_WhenMajorNotPresent_ReturnsEmptyList()
        {
            var versionValidator = Substitute.For<ISemverVersionValidator>();
            versionValidator.ValidateVersionString(Arg.Any<string>());

            var searchService = new SoftwareSearchStatic(versionValidator);
            var searchText = "";
            var result = searchService.SearchVersions(searchText);
            result.Should().BeEmpty();
        }

        [Fact]
        public void SearchVersion_WhenMajorPresent_ReturnsList()
        {
            var versionValidator = Substitute.For<ISemverVersionValidator>();

            var searchService = new SoftwareSearchStatic(versionValidator);
            var searchText = "2";
            var result = searchService.SearchVersions(searchText);

            result.Should().NotBeEmpty()
                .And.HaveCount(5);
            result.Should().Contain(s =>  s.Name == "MS Word" && s.Version == "13.2.1" );
            result.Should().Contain(s => s.Name == "Angular" && s.Version == "8.1.13");
            result.Should().Contain(s => s.Name == "Vue.js" && s.Version == "2.6");
            result.Should().Contain(s => s.Name == "Visual Studio" && s.Version == "2017.0.1");
            result.Should().Contain(s => s.Name == "Visual Studio" && s.Version == "2019.1");

        }

        [Fact]
        public void SearchVersion_WhenMinorPresent_ReturnsList()
        {
            var versionValidator = Substitute.For<ISemverVersionValidator>();

            var searchService = new SoftwareSearchStatic(versionValidator);
            var searchText = "8.1";
            var result = searchService.SearchVersions(searchText);

            result.Should().NotBeEmpty()
                .And.HaveCount(4);
            result.Should().Contain(s => s.Name == "MS Word" && s.Version == "13.2.1");
            result.Should().Contain(s => s.Name == "Angular" && s.Version == "8.1.13");
            result.Should().Contain(s => s.Name == "Visual Studio" && s.Version == "2017.0.1");
            result.Should().Contain(s => s.Name == "Visual Studio" && s.Version == "2019.1");
        }

        [Fact]
        public void SearchVersion_WhenPatchPresent_ReturnsList()
        {
            var versionValidator = Substitute.For<ISemverVersionValidator>();

            var searchService = new SoftwareSearchStatic(versionValidator);
            var searchText = "2017.0.1";
            var result = searchService.SearchVersions(searchText);

            result.Should().NotBeEmpty()
                .And.HaveCount(2);
            result.Should().Contain(s => s.Name == "Visual Studio" && s.Version == "2017.0.1");
            result.Should().Contain(s => s.Name == "Visual Studio" && s.Version == "2019.1");
        }
    }
}
