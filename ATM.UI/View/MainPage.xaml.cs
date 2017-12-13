using ATM.UI.Model;
using ATM.UI.View;
using Windows.UI.Xaml.Controls;

namespace ATM.UI.View
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SharedModel.PageViewer = PageViewer;
            PageViewer.Navigate(typeof(LogInPage));
        }
    }
}
