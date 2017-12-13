using ATM.UI.View;
using System.Windows.Input;

namespace ATM.UI.Model
{
    class CompletedTransactionModel:ObservableObject
    {
        public bool HasALoggedUser => SharedModel.LoggedUser != null;

        public ICommand HomeCommand => new DelegateCommand(Home);

        public void Home(object obj)
        {
            SharedModel.PageViewer.Navigate(typeof(UserPage));
        }

        public ICommand ExitCommand => new DelegateCommand(Exit);

        public void Exit(object obj)
        {
            SharedModel.LoggedUser = null;
            SharedModel.PageViewer.Navigate(typeof(LogInPage));
        }

    }
}
