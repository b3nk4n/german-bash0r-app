using Microsoft.Phone.Controls;
using GermanBash.App.Helpers;

namespace GermanBash.App.Pages
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void EasterEggDoubleTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            LicenceEasterEggHelper.TriggerEasterEggRequested();
        }
    }
}