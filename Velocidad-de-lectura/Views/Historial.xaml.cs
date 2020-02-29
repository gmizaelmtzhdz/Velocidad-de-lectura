using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Velocidaddelectura.Models;
using Velocidaddelectura.Services;
using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    public partial class Historial : ContentPage
    {
        public Command GetHistoricoCommand { get; set; }
        public Historial()
        {
            InitializeComponent();
            this.BindingContext = this;

            ViewEspera.IsVisible = true;
            FrameEspera.IsVisible = true;
            ActivityEspera.IsVisible = true;
            ActivityEspera.IsRunning = true;

            GetHistoricoCommand = new Command(async () => await CargaItems(), () => !IsBusy);
            GetHistoricoCommand.Execute(null);
        }
        private async Task CargaItems()
        {
            if (!this.IsBusy)
            {
                this.IsBusy = true;
                GuardarInformacionServices guardarInformacionServices = new GuardarInformacionServices();
                List<Ejercicio> historico = guardarInformacionServices.ObtenerInformacion();
                if (historico != null)
                {
                    if (historico.Count > 0)
                    {
                        int row = 0;
                        Label lblVelocidadTitulo = new Label()
                        {
                            Text = "VELOCIDAD",
                            FontSize = 18,
                            HorizontalTextAlignment= TextAlignment.Center
                        };
                        Label lblTiempoTitulo = new Label()
                        {
                            Text = "TIEMPO",
                            FontSize = 18,
                            HorizontalTextAlignment = TextAlignment.Center
                        };
                        Label lblPalabrasTitulo = new Label()
                        {
                            Text = "PALABRAS",
                            FontSize = 18,
                            HorizontalTextAlignment = TextAlignment.Center
                        };
                        HistoricoGrid.Children.Add(lblVelocidadTitulo, 0, row);
                        HistoricoGrid.Children.Add(lblTiempoTitulo, 1, row);
                        HistoricoGrid.Children.Add(lblPalabrasTitulo, 2, row);
                        row++;

                        for (var i=historico.Count-1;i>=0;i--)
                        {
                            decimal velocidad = 0;
                            try
                            {
                                velocidad=decimal.Round(historico[i].PalabrasLeidas / historico[i].Segundos, 3);
                            }
                            catch(Exception e)
                            {
                            }
                            Label lblVelocidad = new Label()
                            {
                                Text = velocidad+"/segundo",
                                FontSize = 18,
                                TextColor= Color.FromHex("#d6450c"),
                                HorizontalTextAlignment = TextAlignment.Center
                            };
                            Label lblTiempo = new Label()
                            {
                                Text = historico[i].Segundos + " s",
                                FontSize = 18,
                                HorizontalTextAlignment = TextAlignment.Center
                            };
                            Label lblPalabras = new Label()
                            {
                                Text = ""+ historico[i].PalabrasLeidas,
                                FontSize = 18,
                                HorizontalTextAlignment = TextAlignment.Center
                            };
                            HistoricoGrid.Children.Add(lblVelocidad, 0, row);
                            HistoricoGrid.Children.Add(lblTiempo, 1, row);
                            HistoricoGrid.Children.Add(lblPalabras, 2, row);
                            row++;
                        }
                        
                    }
                    else
                    {
                        Label lblNoHayHistorial = new Label()
                        {
                            Text = "No hay historial :(",
                            FontSize = 18,
                            HorizontalTextAlignment = TextAlignment.Center
                        };
                        HistoricoGrid.Children.Add(lblNoHayHistorial, 1, 0);
                    }
                }
                ViewEspera.IsVisible = false;
                FrameEspera.IsVisible = false;
                ActivityEspera.IsVisible = false;
                ActivityEspera.IsRunning = false;

                this.IsBusy = false;
            }
        }
    }
}
