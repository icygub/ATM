using System;
using System.Windows.Input;
using Windows.UI.Popups;
using ATM.Data;
using ATM.Data.Exceptions;
using ATM.UI.View;

namespace ATM.UI.Model
{
    public class LoginModel : ObservableObject
    {
        private string _accountNumber = "";
        private string _password = "";

        public string AccountNumber
        {
            get => _accountNumber;
            set
            {
                _accountNumber = value;
                RaisePropertyChangedEvent("AccountNumber");
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChangedEvent("Password");
            }
        }

        public ICommand LogInCommand => new DelegateCommand(LogIn);

        private async void LogIn(object obj)
        {
            try
            {
                var user = Authentication.Login(AccountNumber, Password);

                SharedModel.LoggedUser = user;
                SharedModel.PageViewer.Navigate(typeof(UserPage));
            }
            catch (AuthenticationException e)
            {
                var dialog = new MessageDialog(e.Message);
                await dialog.ShowAsync();
            }

        }

        public ICommand WithdrawCreditCardCommand => new DelegateCommand(WithdrawCreditCard);

        private void WithdrawCreditCard(object obj)
        {
            SharedModel.PageViewer.Navigate(typeof(InsertCreditCardPage));
        }
    }
}
