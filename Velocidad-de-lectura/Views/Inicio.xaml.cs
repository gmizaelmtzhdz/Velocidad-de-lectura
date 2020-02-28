using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    public partial class Inicio : ContentPage
    {
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }
        public Inicio()
        {
            InitializeComponent();
            IsBusy = true;
        }
        private void BtnSeleccion_Clicked(object sender, EventArgs e)
        {
            IsBusy = true;
           // Navigation.PushAsync(new Categoria(), true);
        }
    }
}
