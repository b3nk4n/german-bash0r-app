using GermanBash.Common.Data;
using GermanBash.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanBash.App.Data
{
    public interface IFullyCachedBashClient : ICachedBashClient
    {
        Task<BashCollection> GetQueryAsync(string term, bool forceReload);
    }
}
