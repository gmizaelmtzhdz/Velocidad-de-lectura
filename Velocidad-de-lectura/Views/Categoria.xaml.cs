using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Velocidaddelectura.Models;
using Velocidaddelectura.ViewModels;
using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    public partial class Categoria : ContentPage
    {
        private Ejercicio ejercicio;
        public Categoria()
        {
            InitializeComponent();
            ejercicio = new Ejercicio();
            this.BindingContext = new CategoriaViewModel(Navigation);
            ListCategorias.ItemSelected += ListCategorias_ItemSelected;
        }
        private void ListCategorias_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var SelectedItem = e.SelectedItem as Models.CategoriaModel;
            if (SelectedItem != null)
            {
                ejercicio.Categoria = SelectedItem.Nombre;


                ViewEspera.IsVisible = true;
                FrameEspera.IsVisible = true;
                ActivityEspera.IsVisible = true;
                ActivityEspera.IsRunning = true;

                Device.BeginInvokeOnMainThread(Lanzar);
            }
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
            await Navigation.PushAsync(new ConfiguracionEjercicio(ejercicio));

            ViewEspera.IsVisible = false;
            FrameEspera.IsVisible = false;
            ActivityEspera.IsVisible = false;
            ActivityEspera.IsRunning = false;
        }
    }
}
