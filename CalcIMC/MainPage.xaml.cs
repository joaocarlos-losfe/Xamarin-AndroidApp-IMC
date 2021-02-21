using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalcIMC
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void startCalcBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new DataCollect());
        }
    }
}
