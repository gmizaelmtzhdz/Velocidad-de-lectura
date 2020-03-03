using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Velocidaddelectura.Models;
using Velocidaddelectura.Services;
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
            this.ejercicio.Segundos = 0;

            ViewEspera.IsVisible = true;
            FrameEspera.IsVisible = true;
            ActivityEspera.IsVisible = true;
            ActivityEspera.IsRunning = true;

            Device.BeginInvokeOnMainThread(Extraccion);
        }

        private void BtnSeleccion_Clicked(object sender, EventArgs e)
        {
            switch(PickerTiempo.SelectedIndex)
            {
                case 0:
                    this.ejercicio.Segundos = 15;
                    break;
                case 1:
                    this.ejercicio.Segundos = 30;
                    break;
                case 2:
                    this.ejercicio.Segundos = 60;
                    break;
            }
            switch (PickerLetra.SelectedIndex)
            {
                case 0:
                    this.ejercicio.TamanoFuente = 14;
                    break;
                case 1:
                    this.ejercicio.TamanoFuente = 24;
                    break;
                case 2:
                    this.ejercicio.TamanoFuente = 28;
                    break;
                case 3:
                        this.ejercicio.TamanoFuente = 34;
                break;
            }

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
                Console.Write(e);
            }
        }

        private async Task LanzarAsync()
        {
            await Navigation.PushAsync(new Velocidad(ejercicio));

            ViewEspera.IsVisible = false;
            FrameEspera.IsVisible = false;
            ActivityEspera.IsVisible = false;
            ActivityEspera.IsRunning = false;
        }
        private async void Extraccion()
        {
            try
            {
                await ExtraccionAsync();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        private async Task ExtraccionAsync()
        {
            LlenarEtiquetasTiempo();
            LlenarEtiquetasTamanoLetra();

            this.ejercicio.Texto = await (new ExtraccionContenidoViewModel()).GetContenidoAsync(this.ejercicio.Categoria);


            ViewEspera.IsVisible = false;
            FrameEspera.IsVisible = false;
            ActivityEspera.IsVisible = false;
            ActivityEspera.IsRunning = false;
        }

        private void LlenarEtiquetasTiempo()
        {
            var etiquetas = new List<string>();
            etiquetas.Add("15 Segundos");
            etiquetas.Add("30 Segundos");
            etiquetas.Add("60 Segundos");
            PickerTiempo.ItemsSource = etiquetas;
            PickerTiempo.SelectedIndex = 2;
        }
        private void LlenarEtiquetasTamanoLetra()
        {
            var etiquetas = new List<string>();
            etiquetas.Add("Tamaño 14");
            etiquetas.Add("Tamaño 24");
            etiquetas.Add("Tamaño 28");
            etiquetas.Add("Tamaño 34");
            PickerLetra.ItemsSource = etiquetas;
            PickerLetra.SelectedIndex = 2;
        }
    }
}
