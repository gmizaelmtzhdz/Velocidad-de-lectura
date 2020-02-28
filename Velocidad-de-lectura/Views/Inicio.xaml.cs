using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            ViewEspera.IsVisible = true;
            FrameEspera.IsVisible = true;
            ActivityEspera.IsVisible = true;
            ActivityEspera.IsRunning = true;

            Device.BeginInvokeOnMainThread(Lanzar);
        }
        private async void Lanzar()
        {
            try
            {
                await LanzarAsync();
            }
            catch (Exception e)
            {

            }
        }

        private async Task LanzarAsync()
        {
            await Navigation.PushAsync(new Categoria());

            ViewEspera.IsVisible = false;
            FrameEspera.IsVisible = false;
            ActivityEspera.IsVisible = false;
            ActivityEspera.IsRunning = false;
        }
    }
}
