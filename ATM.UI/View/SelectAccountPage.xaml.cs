using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ATM.UI.View
{
    public sealed partial class SelectAccountPage : Page
    {
        public SelectAccountPage()
        {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void GoToSelectAmount(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SelectAmountPage));
        }
    }
}
