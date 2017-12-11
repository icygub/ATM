using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ATM.UI.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FinalPageUI
    {
        public FinalPageUI()
        {
            this.InitializeComponent();
        }


        private void GoToUserPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UserPageUI));
        }

        private void ExitProgram_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }
    }
}
