using SoftwareSearch.Domain.Software.Models;
using System.Collections.Generic;

namespace SoftwareSearch.Domain.Software.Services
{
    public interface ISoftwareSearch
    {
        IEnumerable<SoftwareInfo> SearchVersions(string SearchText);
    }
}
