using System;
using System.Windows.Input;
using Windows.UI.Popups;
using ATM.Data;
using ATM.Data.Exceptions;

namespace ATM.UI.Model
{
    public class LoginModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private string _accountNumber;
        private string _password;

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


        public LoginModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private async void LogIn(object obj)
        {
            // TODO: Verify Account Number and Password 

            try
            {
                var user = Authentication.Login(AccountNumber, Password);
            }
            catch (AuthenticationException e)
            {
                var dialog = new MessageDialog(e.Message);
                await dialog.ShowAsync();
            }
            
        }
    }
}
