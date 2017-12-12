using ATM.UI.View;
using System.Windows.Input;

namespace ATM.UI.Model
{
    class InsertPinModel:ObservableObject
    {
        private string _pin;
        public string Pin
        {
            get => _pin;
            set
            {
                _pin = value;
                RaisePropertyChangedEvent("Pin");
            }
        }

        public ICommand GoBackCommand => new DelegateCommand(GoBack);

        public void GoBack(object obj)
        {
            BaseViewModel.Amount = 0;

            if (BaseViewModel.LoggedUser != null)
            {
                BaseViewModel.PageViewer.Navigate(typeof(SelectAmountPage));
            }
            else
            {
                BaseViewModel.PageViewer.Navigate(typeof(LogInPage));
            }
        }

        public ICommand ClearCommand => new DelegateCommand(Clear);

        public void Clear(object obj)
        {
            Pin = null;
        }

        public ICommand ConfirmCommand => new DelegateCommand(Confirm);

        public void Confirm(object obj)
        {
            BaseViewModel.PageViewer.Navigate(typeof(LoadingTransactionPage));
        }
    }
}
