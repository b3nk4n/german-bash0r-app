using GermanBash.Common.Models;

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
