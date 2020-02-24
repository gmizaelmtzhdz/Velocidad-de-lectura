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

            GuardarHistorialCommand = new Command(async () => GuardarHistorial(), () => !IsBusy);
            GuardarHistorialCommand.Execute(null);
        }
        private void GuardarHistorial()
        {
            GuardarInformacionServices guardarInformacionServices = new GuardarInformacionServices();
            guardarInformacionServices.GuardarInformacion(this.ejercicio);
        }
        private void BtnSeleccion_Clicked(object sender, EventArgs e)
        {
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
            Navigation.PushAsync(new Inicio(), true);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);

        }
    }
}
