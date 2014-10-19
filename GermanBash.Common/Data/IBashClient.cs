using GermanBash.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanBash.Common.Data
{
    public interface IBashClient
    {
        Task<BashCollection> GetQuotesAsync(string order);

        Task<BashCollection> GetQueryAsync(string term);

        Task<bool> RateAsync(int id, string type);
    }
}
