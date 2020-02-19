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
            Application.Current.MainPage.DisplayAlert("Palabras", ""+(new ExtraccionContenidoViewModel()).GetContenido(""), "Continuar");

        }
        private void BtnSeleccion_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Velocidad(ejercicio), true);
        }
    }
}
