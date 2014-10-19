using GermanBash.Common.Data;
using GermanBash.Common.Models;
using PhoneKit.Framework.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanBash.App.Data
{
    public class FullyCachedBashClient : IFullyCachedBashClient
    {
        private readonly ICachedBashClient _bashClient;

        private const string SEARCH_PREFIX = "search_";

        private const string WARTE_KEY = "WARTE";

        public FullyCachedBashClient(ICachedBashClient bashClient)
        {
            _bashClient = bashClient;
        }

        public Task<BashCollection> GetQueryAsync(string term)
        {
            return GetQueryAsync(term, false);
        }

        public async Task<BashCollection> GetQueryAsync(string term, bool forceRealod)
        {
            var searchKey = SEARCH_PREFIX + term;
            if (!forceRealod && PhoneStateHelper.ValueExists(searchKey))
            {
                return PhoneStateHelper.LoadValue<BashCollection>(searchKey);
            }

            var result = await _bashClient.GetQueryAsync(term);
            if (result != null)
            {
                PhoneStateHelper.SaveValue(searchKey, result);
            }
            return result;
        }

        public Task<BashCollection> GetQuotesAsync(string order, double lifeTimeDays, bool forceReload)
        {
            return _bashClient.GetQuotesAsync(order, lifeTimeDays, forceReload);
        }

        public void UpdateCache(BashCollection data)
        {
            _bashClient.UpdateCache(data);
        }

        public Task<BashCollection> GetQuotesAsync(string order)
        {
            return _bashClient.GetQuotesAsync(order);
        }

        public Task<bool> RateAsync(int id, string type)
        {
            return _bashClient.RateAsync(id, type);
        }
    }
}
