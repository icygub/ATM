using Windows.UI.Xaml.Controls;
using ATM.Data;

namespace ATM.UI.Model
{
    class BaseViewModel
    {
        public enum Transactions
        {
            Withdraw,
            Deposit,
            Transfer
        };

        public static Frame PageViewer = null;
        public static User LoggedUser = null;
        public static Transactions? Transaction = null;
        public static Account TransactionAccount = null;
        public static double Amount = 0;
    }
}
