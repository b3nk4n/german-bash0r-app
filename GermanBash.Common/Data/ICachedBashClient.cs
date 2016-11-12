using GermanBash.Common.Models;
using System.Threading.Tasks;

namespace GermanBash.Common.Data
{
    public interface ICachedBashClient : IBashClient
    {
        Task<BashCollection> GetQuotesAsync(string order, double lifeTimeDays, bool forceReload);

        void UpdateCache(BashCollection data);
    }
}
