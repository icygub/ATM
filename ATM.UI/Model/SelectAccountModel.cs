using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ATM.Data;
using ATM.UI.View;

namespace ATM.UI.Model
{
    class SelectAccountModel:ObservableObject
    {
        public User User => BaseViewModel.LoggedUser;

        public ICommand SelectAcountCommand => new DelegateCommand(SelectAccount);

        private void SelectAccount(object obj)
        {
            BaseViewModel.TransactionAccount = obj as Account;
            BaseViewModel.PageViewer.Navigate(typeof(SelectAmountPage));
        }

        public ICommand GoBackCommand => new DelegateCommand(GoBack);

        private void GoBack(object obj)
        {
            BaseViewModel.PageViewer.Navigate(typeof(UserPage));
        }
    }
}
