using ATM.UI.View;
using System.Windows.Input;

namespace ATM.UI.Model
{
    class CompletedTransactionModel:ObservableObject
    {
        public bool HasALoggedUser => BaseViewModel.LoggedUser != null;

        public ICommand HomeCommand => new DelegateCommand(Home);

        public void Home(object obj)
        {
            BaseViewModel.PageViewer.Navigate(typeof(UserPage));
        }

        public ICommand ExitCommand => new DelegateCommand(Exit);

        public void Exit(object obj)
        {
            BaseViewModel.LoggedUser = null;
            BaseViewModel.PageViewer.Navigate(typeof(LogInPage));
        }

    }
}
