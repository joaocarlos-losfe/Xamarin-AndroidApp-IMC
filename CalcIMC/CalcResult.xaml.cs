using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalcIMC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalcResult : ContentPage
    {
        public CalcResult(float imc_result)
        {
            InitializeComponent();
            imcResult.Text = imc_result.ToString("F") + " kgm/2";
            imcTypeResult.Text = imcType(imc_result);
            CrossLocalNotifications.Current.Show("IMC Calculado", "Seu ultimo calculo de imc foi de: " + imcResult.Text + ", Considerado "+imcTypeResult.Text);

        }

        private string imcType(float imc_result)
        {
            string imc_type = "";
            if (imc_result < 16)
                imc_type = "Magreza grau III";
            else if (imc_result >= 16 && imc_result < 16.9)
                imc_type = "Magreza grau II";
            else if (imc_result >= 17 && imc_result < 18.4)
                imc_type = "Magreza grau I";
            else if (imc_result >= 18.5 && imc_result < 24.9)
                imc_type = "Adequado";
            else if (imc_result >= 25 && imc_result < 29.9)
                imc_type = "Pré-obeso";
            else if (imc_result >= 30 && imc_result < 34.9)
                imc_type = "Obesidade grau I";
            else if (imc_result >= 35 && imc_result < 39.9)
                imc_type = "Obesidade grau II";
            else
                imc_type = "Obesidade grau III";


            return imc_type;
        }

        private async void returnToCalcBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}