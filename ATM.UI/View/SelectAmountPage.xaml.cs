using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ATM.UI.View
{
    public sealed partial class SelectAmountPage : Page
    {
        public SelectAmountPage()
        {
            this.InitializeComponent();
        }

        private void GoToEnterAmount(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EnterAmountPage));
        }
    }
}
