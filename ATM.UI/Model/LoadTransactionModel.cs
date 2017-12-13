using System;
using System.Threading.Tasks;
using ATM.UI.View;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Animation;
using ATM.Data;
using ATM.Data.Exceptions;

namespace ATM.UI.Model
{
    class LoadTransactionModel:ObservableObject
    {
        public ICommand ContinueCommand => new DelegateCommand(Continue);

        public async void Continue(object obj)
        {

            switch (BaseViewModel.Transaction)
            {
                case BaseViewModel.Transactions.Withdraw:
                    try
                    {
                        BaseViewModel.TransactionAccount.Withdraw(BaseViewModel.Amount);
                    }
                    catch (InsufficientBalanceException e)
                    {
                        var messageBox =
                            new MessageDialog("Insufficient Funds.");
                        await messageBox.ShowAsync();

                        BaseViewModel.PageViewer.Navigate(typeof(EnterAmountPage));
                        return;

                    }
                    catch (WithdrawUpTo500Exception e)
                    {
                        var messageBox =
                            new MessageDialog("You cannot withdraw more than $500.00 of Checkings Account");
                        await messageBox.ShowAsync();

                        BaseViewModel.PageViewer.Navigate(typeof(EnterAmountPage));
                        return;
                    }
                    break;
                case BaseViewModel.Transactions.Deposit:
                    BaseViewModel.TransactionAccount.Deposit(BaseViewModel.Amount);
                    break;
                case BaseViewModel.Transactions.Transfer:
                    IAccount transferToAccount;

                    if (BaseViewModel.TransactionAccount is CheckingAccount)
                    {
                        transferToAccount = BaseViewModel.LoggedUser.SavingsAccount;
                    }
                    else
                    {
                        transferToAccount = BaseViewModel.LoggedUser.CheckingAccount;
                    }
               
                    BaseViewModel.TransactionAccount.TransferTo(transferToAccount, BaseViewModel.Amount);
                    break;
            }

            BaseViewModel.PageViewer.Navigate(typeof(CompletedTransactionPage));
        }
    }
}
