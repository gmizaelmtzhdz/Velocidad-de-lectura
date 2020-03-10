using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    /// <summary>
    /// Clase de code behind de la vista 'Inicio.xml' donde el usuario puede iniciar su ejercicio
    /// </summary>
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Recibe una llamada, cuando el botón 'Iniciar' es seleccionado (tap)  
        /// </summary>
        /// <param name="sender">object.</param>
        /// <param name="e">EventArgs.</param>
        private void BtnSeleccion_Clicked(object sender, EventArgs e)
        {
            ViewEspera.IsVisible = true;
            FrameEspera.IsVisible = true;
            ActivityEspera.IsVisible = true;
            ActivityEspera.IsRunning = true;

            Device.BeginInvokeOnMainThread(Lanzar);
        }
        /// <summary>
        /// Se manda llamar, para iniciar el proceso asíncrono (LanzarAsync()) de lanzar la vista de 'Categoria'
        /// </summary>
        private async void Lanzar()
        {
            try
            {
                await LanzarAsync();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
        /// <summary>
        /// Lanza la vista de 'Categoria'
        /// </summary>
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