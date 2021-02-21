

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
        Currency[] currs = Currency.GetCurr();
        public string BitcoinPrice { get { return currs[0].price.Replace("$"," ") + '$'; } }

        public string BitcoinGrowth { get { return currs[0].growth; } }


        public string EtherPrice { get { return currs[1].price.Replace("$", " ") + '$'; } }

        public string EtherGrowth { get { return currs[1].growth; } }


        public string TetherPrice { get { return currs[2].price.Replace("$", " ") + '$'; } }

        public string TetherGrowth { get { return currs[2].growth; } }


        public string RipplePrice { get { return currs[3].price.Replace("$", " ") + '$'; } }

        public string RippleGrowth { get { return currs[3].growth; } }


        public string CardanoPrice { get { return currs[4].price.Replace("$", " ") + '$'; } }

        public string CardanoGrowth { get { return currs[4].growth; } }


        public string LitePrice { get { return currs[5].price.Replace("$", " ") + '$'; } }

        public string LiteGrowth { get { return currs[5].growth; } }


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
