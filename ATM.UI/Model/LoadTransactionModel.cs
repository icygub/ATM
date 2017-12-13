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

            switch (SharedModel.Transaction)
            {
                case SharedModel.Transactions.Withdraw:
                    try
                    {
                        SharedModel.TransactionAccount.Withdraw(SharedModel.Amount);
                    }
                    catch (InsufficientBalanceException e)
                    {
                        var messageBox =
                            new MessageDialog("Insufficient Funds.");
                        await messageBox.ShowAsync();

                        SharedModel.PageViewer.Navigate(typeof(EnterAmountPage));
                        return;

                    }
                    catch (WithdrawUpTo500Exception e)
                    {
                        var messageBox =
                            new MessageDialog("You cannot withdraw more than $500.00 of Checkings Account");
                        await messageBox.ShowAsync();

                        SharedModel.PageViewer.Navigate(typeof(EnterAmountPage));
                        return;
                    }
                    break;
                case SharedModel.Transactions.Deposit:
                    SharedModel.TransactionAccount.Deposit(SharedModel.Amount);
                    break;
                case SharedModel.Transactions.Transfer:
                    IAccount transferToAccount;

                    if (SharedModel.TransactionAccount is CheckingAccount)
                    {
                        transferToAccount = SharedModel.LoggedUser.SavingsAccount;
                    }
                    else
                    {
                        transferToAccount = SharedModel.LoggedUser.CheckingAccount;
                    }
               
                    SharedModel.TransactionAccount.TransferTo(transferToAccount, SharedModel.Amount);
                    break;
            }

            SharedModel.PageViewer.Navigate(typeof(CompletedTransactionPage));
        }
    }
}
