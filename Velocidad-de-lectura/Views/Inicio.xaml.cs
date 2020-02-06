using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
        }
        private void BtnSeleccion_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Categoria(), true);

        }
    }
}
