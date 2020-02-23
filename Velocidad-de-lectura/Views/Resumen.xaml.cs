using System;
using System.Collections.Generic;
using Velocidaddelectura.Models;
using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    public partial class Resumen : ContentPage
    {
        private Ejercicio ejercicio;
        public Resumen(Ejercicio ejercicio)
        {
            InitializeComponent();
            this.ejercicio = ejercicio;
            LblCantidadPalabras.Text = ""+ejercicio.PalabrasLeidas;
            LblResumen.Text = "Palabras en "+ejercicio.Segundos+" segundos";
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
