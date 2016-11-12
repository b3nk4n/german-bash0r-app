using GermanBash.Common.Data;
using GermanBash.Common.Models;
using System.Threading.Tasks;

namespace GermanBash.App.Data
{
    public interface IFullyCachedBashClient : ICachedBashClient
    {
        Task<BashCollection> GetQueryAsync(string term, bool forceReload);
    }
}
