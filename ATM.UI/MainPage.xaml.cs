using ATM.UI.Model;
using ATM.UI.View;
using Windows.UI.Xaml.Controls;

namespace ATM.UI
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            BaseViewModel.PageViewer = PageViewer;
            PageViewer.Navigate(typeof(LogInPage));
        }
    }
}
