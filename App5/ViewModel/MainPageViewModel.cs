

using App5.Model;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace App5.ViewModel
{
    class MainPageViewModel : BaseViewModel
    {

        private IClickModel clickModel;
        public ICommand ClickCommand { get; private set; }

        //public string bitcoinPrice = Currency.GetBitcoin().price+'$';

        public string BitcoinPrice { get { return Currency.GetBitcoin().price.Replace("$"," ") + '$'; } }

        public string BitcoinGrowth { get { return Currency.GetBitcoin().growth; } }

        public string ClicksCount
        {
            get
            {
                
                return clickModel.Clicks.ToString()+'$';
                
            }
        }
        public MainPageViewModel()
        {
            ClickCommand = new Command(OnButtonClick);
            clickModel = new ClickModel();
        }
        private void OnButtonClick()
        {
            clickModel.OnClick();
            NotifyPropertyChanged(nameof(ClicksCount));
        }
    }
}
