using ATM.UI.View;
using System.Windows.Input;

namespace ATM.UI.Model
{
    class InsertCreditCardModel: ObservableObject
    {
        public ICommand GoBackCommand => new DelegateCommand(GoBack);

        public void GoBack(object obj)
        {
            BaseViewModel.Amount = 0;
            BaseViewModel.PageViewer.Navigate(typeof(SelectAmountPage));
        }

        public ICommand ConfirmCommand => new DelegateCommand(Confirm);

        public void Confirm(object obj)
        {
            BaseViewModel.PageViewer.Navigate(typeof(InsertPinPage));
        }
    }
}
