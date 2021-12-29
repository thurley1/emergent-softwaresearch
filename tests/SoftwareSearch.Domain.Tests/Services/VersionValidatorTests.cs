using FluentAssertions;
using SoftwareSearch.Domain.Software.Services;
using System;
using Xunit;

namespace SoftwareSearch.Domain.Tests.Services
{
    public class VersionValidatorTests
    {
        [Fact]
        public void ValidateVersionString_WhenVersionStringIsInvalid_Throws()
        {
            var searchString = "1.";
            var validator = new VersionValidator();
            var exception = Record.Exception(() => validator.ValidateVersionString(searchString));
            exception.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public void SearchVersion_WhenVersionStringIsValid_DoesNothrows()
        {
            var searchString = "1.2.3";
            var validator = new VersionValidator();
            var exception = Record.Exception(() => validator.ValidateVersionString(searchString));
            exception.Should().BeNull();
        }
    }
}
