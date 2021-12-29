namespace SoftwareSearch.Domain.Software.Services
{
    public interface ISemverVersionValidator
    {
        void ValidateVersionString(string versionString);
    }
}
