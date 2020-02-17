using System;
using System.Collections.Generic;
using Velocidaddelectura.Models;
using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    public partial class ConfiguracionEjercicio : ContentPage
    {
        private CategoriaModel categoria;
        public ConfiguracionEjercicio(CategoriaModel categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
        }
        private void BtnSeleccion_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Velocidad(categoria), true);

        }
    }
}
