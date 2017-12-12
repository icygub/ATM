using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ATM.UI.View;

namespace ATM.UI.Model
{
    class EnterAmountModel: ObservableObject
    {
        private string _amount;
        public string Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                RaisePropertyChangedEvent("Amount");
            }
        }

        public ICommand GoBackCommand => new DelegateCommand(GoBack);

        public void GoBack(object obj)
        {

            BaseViewModel.PageViewer.Navigate(typeof(SelectAmountPage));
        }

        public ICommand ClearCommand => new DelegateCommand(Clear);

        public void Clear(object obj)
        {
            Amount = null;
        }

        public ICommand ConfirmCommand => new DelegateCommand(Confirm);

        public void Confirm(object obj)
        {
            BaseViewModel.Amount = Double.Parse(Amount);
            BaseViewModel.PageViewer.Navigate(typeof(InsertCreditCardPage));
        }
    }
}
