using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ATM.UI.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EnterAmountUI : Page
    {
        public EnterAmountUI()
        {
            this.InitializeComponent();
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            amountTextBox.Text = "";
        }

        private void GoToInsertCreditCard(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(InsertCreditCardUI));
        }
    }
}
