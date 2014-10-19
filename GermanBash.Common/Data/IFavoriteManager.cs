using GermanBash.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanBash.Common.Data
{
    public interface IFavoriteManager
    {
        void AddToFavorites(BashData bashData);

        void RemoveFromFavorites(BashData bashData);

        BashCollection GetData(bool forceReload = false);

        void SaveData();

        bool IsFavorite(BashData bashData);

        bool HasDataChanged { get; }
    }
}
