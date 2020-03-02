using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Velocidaddelectura.Models;
using Velocidaddelectura.Services;
using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    public partial class Resumen : ContentPage
    {
        private Ejercicio ejercicio;
        public Command GuardarHistorialCommand { get; set; }

        public Resumen(Ejercicio ejercicio)
        {
            InitializeComponent();
            this.ejercicio = ejercicio;
            LblCantidadPalabras.Text = ""+ejercicio.PalabrasLeidas;
            LblResumen.Text = "Palabras en "+ejercicio.Segundos+" segundos";

            GuardarHistorialCommand = new Command(async () => await GuardarHistorialAsync(), () => !IsBusy);
            GuardarHistorialCommand.Execute(null);
        }
        private async Task GuardarHistorialAsync()
        {
            GuardarInformacionServices guardarInformacionServices = new GuardarInformacionServices();
            await guardarInformacionServices.GuardarInformacion(this.ejercicio);
        }
        private void BtnSeleccion_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(false);
            Navigation.PopAsync(false);
            Navigation.PopAsync(false);
            Navigation.PopAsync(false);
            Navigation.PushAsync(new Inicio(), true);
            Navigation.PopAsync(false);
            Navigation.PopAsync(false);
        }
    }
}
