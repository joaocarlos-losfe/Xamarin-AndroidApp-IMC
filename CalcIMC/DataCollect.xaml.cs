using Android.App;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalcIMC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataCollect : ContentPage
    {
        public DataCollect()
        {
            InitializeComponent();
        }

        private async void startIMCCalcBtn_Clicked(object sender, EventArgs e)
        {
            float imc = imcCalc();

            if (imc != -1)
            {
                await Navigation.PushModalAsync(new CalcResult(imc));
                kgEntry.Text = "";
                cmEntry.Text = "";
                anEnty.Text = "";
            } 
            else
                await DisplayAlert("Erro", "Alguns campos estão vazios !!", "OK");
        }

        private float imcCalc()
        {
            if (string.IsNullOrEmpty(kgEntry.Text) || string.IsNullOrEmpty(cmEntry.Text))
                return -1;
            
            float altura_ao_quadrado = (float.Parse(cmEntry.Text) / 100);
            altura_ao_quadrado = altura_ao_quadrado * altura_ao_quadrado;
            float imc = float.Parse(kgEntry.Text) / altura_ao_quadrado;

            return imc;
        }
    }
}