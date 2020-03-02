using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Velocidaddelectura.Models;
using Velocidaddelectura.Views;
using Xamarin.Forms;

namespace Velocidaddelectura.ViewModels
{
    public class VelocidadViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static int Taps = 0;
        private String texto;
        private String[] arreglo;
        private int palabra_inicio = 0;
        private int palabra_fin = 0;
        private INavigation navigation;

        private Stopwatch StopWatch;
        private bool tiempo_finalizo = false;


        private Ejercicio ejercicio;


        private string _CronometroVelocidad;
        public string CronometroVelocidad
        {
            get
            {
                return _CronometroVelocidad;
            }
            set
            {
                _CronometroVelocidad = value;
                OnPropertyChanged();
            }
        }

        private string _InstruccionVelocidad;
        public string InstruccionVelocidad
        {
            get
            {
                return _InstruccionVelocidad;
            }
            set
            {
                _InstruccionVelocidad = value;
                OnPropertyChanged();
            }
        }


        private string _ImagenVelocidad;
        public string ImagenVelocidad
        {
            get
            {
                return _ImagenVelocidad;
            }
            set
            {
                _ImagenVelocidad = value;
                OnPropertyChanged();
            }
        }
        public VelocidadViewModel(INavigation nav, Ejercicio ejercicio)
        {
            this.ejercicio = ejercicio;
            Taps = 0;
            if(ejercicio.Texto!=null)
            {
                texto = ejercicio.Texto;
                arreglo = texto.Split(' ');
                navigation = nav;
            }
        }

        private void OnPropertyChanged(
                    [System.Runtime.CompilerServices.CallerMemberName]
                     string propertyName = null) =>
                    PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(propertyName));



        public ICommand TapCommand => new Command<Span>(async (palabra) =>
            SpanClicked(palabra)
        );

        public FormattedString GenerarTextoSpan()
        {
            IsBusy = true;
            FormattedString formattedString = new FormattedString();
            Span span = null;
            int limite = arreglo.Length>200?200:arreglo.Length;

            for (var i = 0; i < limite; i++)
            {
                span = new Span {Text = arreglo[i] + "   " };
                span.StyleId = Convert.ToString(i + 1);
                span.FontSize = ejercicio.TamanoFuente;
                span.GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = TapCommand,
                    CommandParameter = span
                });

                formattedString.Spans.Add(span);
            }
            IsBusy = false;
            return formattedString;
        }

        public FormattedString ContenedorTexto
        {
            get
            {
                return GenerarTextoSpan();
            }
        }
        private bool Busy;
        public bool IsBusy
        {
            get
            {
                return Busy;
            }
            set
            {
                Busy = value;
                OnPropertyChanged();
            }
        }
        public void SpanClicked(object sender)
        {
            IsBusy = true;
            Span palabra = (Span)sender;
            switch (Taps)
            {
                case 0:
                    Taps++;
                    palabra.FontSize = ejercicio.TamanoFuente+2;
                    palabra.TextColor = Color.Green;
                    palabra_inicio = Convert.ToInt32(palabra.StyleId);
                    tiempo_finalizo = false;
                    StopWatch = new Stopwatch();
                    if (!StopWatch.IsRunning) { StopWatch.Start(); }
                    else { StopWatch.Stop(); StopWatch.Reset();}
                    Device.StartTimer(new TimeSpan(0, 0, 1), () => {
                        if(tiempo_finalizo)
                        {
                            InstruccionVelocidad = "Selecciona la última palabra leída";
                            CronometroVelocidad = ejercicio.Segundos + "/" + ejercicio.Segundos + " segundos";
                        }
                        else
                        {
                            CronometroVelocidad = (StopWatch.ElapsedMilliseconds / 1000) + "/" + ejercicio.Segundos + " segundos";
                            if (StopWatch.IsRunning && (StopWatch.ElapsedMilliseconds / 1000) >= ejercicio.Segundos)
                            {
                                Application.Current.MainPage.DisplayAlert("Ejercicio Finalizado", "Selecciona la última palabra leída", "Ok");
                                StopWatch.Stop();
                                StopWatch.Reset();
                                tiempo_finalizo = true;
                            }
                        }   
                        return true;

                    });
                    ImagenVelocidad = "cronometro.png";
                    InstruccionVelocidad = "Al finalizar selecciona la última palabra leída";
                    break;
                case 1:
                    if (tiempo_finalizo)
                    {
                        Taps++;
                        palabra.FontSize = ejercicio.TamanoFuente + 2;
                        palabra.TextColor = Color.Red;
                        palabra_fin = Convert.ToInt32(palabra.StyleId);
                        int palabras_leidas = 0;
                        if (palabra_fin < palabra_inicio)
                        {
                            palabras_leidas = palabra_inicio - palabra_fin + 1;
                        }
                        else
                        {
                            palabras_leidas = palabra_fin - palabra_inicio + 1;
                        }
                        Application.Current.MainPage.DisplayAlert("Palabras", "Cantidad de palabras leidas: " + palabras_leidas, "Continuar");
                        ejercicio.PalabrasLeidas = palabras_leidas;
                        navigation.PushAsync(new Resumen(ejercicio));
                    }
                    break;
                default:
                    Taps = 0;
                    palabra_inicio = 0;
                    palabra_fin = 0;
                    break;
            }
            IsBusy = false;
        }
    }
}
