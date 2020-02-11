using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Velocidaddelectura.Models;
using Velocidaddelectura.ViewModels;
using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    public partial class Velocidad : ContentPage
    {
        public Command CargarTexto { get; set; }
        public Velocidad(CategoriaModel categoria)
        {
            InitializeComponent();
            this.BindingContext = new VelocidadViewModel(Navigation);


        }
        /*
        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarTexto = new Command(async () => await AgregarTexto(), () => !IsBusy);
            CargarTexto.Execute(null);
        }
        private async Task AgregarTexto()
        {
            t(0, 25);

            Application.Current.MainPage.DisplayAlert("Tiempo", "Task", "Ok");
            System.Threading.Tasks.Task.Factory.StartNew(() => {
                Thread.Sleep(3000); // delay execution for 500 ms
                                    // more code
                t(26, arreglo.Length);
            });

            lblContenedor.Spans.Add(new Span { Text = "First ", ForegroundColor = Color.Red, Font = Font.SystemFontOfSize(14) });
            lblContenedor.Spans.Add(new Span { Text = " second ", ForegroundColor = Color.Blue, Font = Font.SystemFontOfSize(28) });
            lblContenedor.Spans.Add(new Span { Text = " third.", ForegroundColor = Color.Yellow, Font = Font.SystemFontOfSize(14) });
            return;
        }
        void Tiempo_Tick(object sender, EventArgs e)
        {

        }
        private void t(int inicio, int fin)
        {
            for (var i = inicio; i < fin; i++)
            {
                if (i > 600)
                    break;
                lblContenedor.Spans.Add(new Span { Text = arreglo[i] + " " });
            }
        }
        */
    }
}
