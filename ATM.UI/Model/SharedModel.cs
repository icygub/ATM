using Windows.UI.Xaml.Controls;
using ATM.Data;

namespace ATM.UI.Model
{
    class SharedModel
    {
        public enum Transactions
        {
            Withdraw,
            Deposit,
            Transfer
        };

        public static Frame PageViewer = null;
        public static User LoggedUser = null;
        public static bool NonLoggedUser => LoggedUser == null;
        public static Transactions? Transaction = null;
        public static IAccount TransactionAccount = null;
        public static double Amount = 0;
    }
}
