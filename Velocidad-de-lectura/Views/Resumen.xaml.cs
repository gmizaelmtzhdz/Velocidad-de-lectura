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
    }
}
