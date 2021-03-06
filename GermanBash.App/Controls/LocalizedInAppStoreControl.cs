using GermanBash.App.Resources;
using GermanBash.Common;
using System.Windows.Media;

namespace GermanBash.App.Controls
{
    public class LocalizedInAppStoreControl : MyInAppStoreControlBase
    {
        public LocalizedInAppStoreControl()
        {
            BackgroundTheme.Color = (Color)App.Current.Resources["ThemeColorRed"];
        }

        /// <summary>
        /// Localizes the user control content and texts.
        /// </summary>
        protected override void LocalizeContent()
        {
            InAppStoreLoadingText = AppResources.InAppStoreLoading;
            InAppStoreNoProductsText = AppResources.InAppStoreNoProducts;
            InAppStorePurchasedText = AppResources.InAppStorePurchased;
            SupportedProductIds = AppConstants.IAP_AWESOME_EDITION;
        }
    }
}
