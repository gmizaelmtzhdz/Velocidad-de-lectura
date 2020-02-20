using System;
using System.Collections.Generic;
using Velocidaddelectura.Models;
using Velocidaddelectura.ViewModels;
using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    public partial class ConfiguracionEjercicio : ContentPage
    {
        private Ejercicio ejercicio;
        public ConfiguracionEjercicio(Ejercicio ejercicio)
        {
            InitializeComponent();
            this.ejercicio = ejercicio;
            this.ejercicio.Segundos = 30;
            this.ejercicio.Texto = (new ExtraccionContenidoViewModel()).GetContenido("javag");
            Application.Current.MainPage.DisplayAlert("Palabras", this.ejercicio.Texto, "Continuar");

        }
        private void BtnSeleccion_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Velocidad(ejercicio), true);
        }
    }
}
