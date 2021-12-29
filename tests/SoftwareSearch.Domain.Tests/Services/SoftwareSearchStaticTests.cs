using FluentAssertions;
using SoftwareSearch.Domain.Software.Models;
using Xunit;

namespace SoftwareSearch.Domain.Tests.Services
{
    public class SoftwareSearchStaticTests
    {
        [Fact]
        public void Major_WhenMajorExistsInVersion_SetsProperty()
        {
            var softwareInfo = new SoftwareInfo
            {
                Name = "Test Software",
                Version = "1"
            };

            softwareInfo.Major.Should().Be(1);
        }

        [Fact]
        public void Major_WhenMajorDoesNotExistInVersion_SetsPropertyToNull()
        {
            var softwareInfo = new SoftwareInfo
            {
                Name = "Test Software",
                Version = ""
            };

            softwareInfo.Major.Should().BeNull();
        }

        [Fact]
        public void Minor_WhenMinorExistsInVersion_SetsProperty()
        {
            var softwareInfo = new SoftwareInfo
            {
                Name = "Test Software",
                Version = "1.2"
            };

            softwareInfo.Minor.Should().Be(2);
        }

        [Fact]
        public void Minor_WhenMinorDoesNotExistInVersion_SetsPropertyToNull()
        {
            var softwareInfo = new SoftwareInfo
            {
                Name = "Test Software",
                Version = "1"
            };

            softwareInfo.Minor.Should().BeNull();
        }

        [Fact]
        public void Patch_WhenPatchExistsInVersion_SetsProperty()
        {
            var softwareInfo = new SoftwareInfo
            {
                Name = "Test Software",
                Version = "1.2.3"
            };

            softwareInfo.Patch.Should().Be(3);
        }

        [Fact]
        public void Patch_WhenPatchDoesNotExistInVersion_SetsPropertyToNull()
        {
            var softwareInfo = new SoftwareInfo
            {
                Name = "Test Software",
                Version = "1.2"
            };

            softwareInfo.Patch.Should().BeNull();
        }
    }
}
