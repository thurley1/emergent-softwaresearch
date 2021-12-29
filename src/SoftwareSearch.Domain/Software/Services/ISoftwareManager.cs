using SoftwareSearch.Domain.Software.Models;
using System.Collections.Generic;

namespace SoftwareSearch.Domain.Software.Services
{
    public interface ISoftwareManager
    {
        IEnumerable<SoftwareInfo> GetAllSoftware();
        IEnumerable<SoftwareInfo> SearchVersions(string SearchText);
    }
}
