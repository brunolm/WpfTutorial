using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfTutorial.Extenders;

namespace WpfTutorial.ViewModels
{
    [ExportViewModel(typeof(Level1ViewViewModel))]
    public class Level1ViewViewModel : BaseLevelViewModel
    {
        private ObservableCollection<Fee> fees;
        public ObservableCollection<Fee> Fees
        {
            get { return fees; }
            set
            {
                fees = value;
                this.RaisePropertyChanged();
            }
        }

        private string amountText;
        public string AmountText
        {
            get { return amountText; }
            set
            {
                amountText = value;
                this.RaisePropertyChanged();
            }
        }

        public RelayCommand PayCommand { get; private set; }

        public class Fee
        {
            public string Name { get; set; }

            public decimal Value { get; set; }
        }

        public override void OnLoaded(object sender)
        {
            Fees = new ObservableCollection<Fee>(new List<Fee>
            {
                new Fee { Name = "Main", Value = 400M },
                new Fee { Name = "Something", Value = 100.50M },
                new Fee { Name = "Good stuff", Value = 2000M },
            });

            PayCommand = new RelayCommand(PayExecute);

            #region Level info

            Description = @"Level 1 - Exception on Pay
Expected result
===============
If the total is 2500.50 and I pay 500.50 it should show a message saying the remaining to pay is 2000.

Actual result
===============
An exception happens when I click to pay.

Steps to reproduce:
1. Enter 500.50 on the amount field
2. Click pay
";

            #endregion
        }

        private void PayExecute(object parameter)
        {
            decimal amountToPay = int.Parse(AmountText);
            decimal totalAmount = Fees.Sum(o => o.Value);

            if (amountToPay <= 0 || amountToPay > totalAmount)
            {
                MessageBox.Show("Invalid value", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show(String.Format("You have payed {0} out of {1}. {2} remaining.", amountToPay, totalAmount, totalAmount - amountToPay), "Payment completed successfully");
        }
    }
}
