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
    /// <summary>
    /// Clase VelocidadViewModel, es donde se controla el ejercicio de lectura
    /// </summary>
    public class VelocidadViewModel: INotifyPropertyChanged
    {
        /// <value>Variable de instancia: PropertyChanged. </value>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <value>Variable de instancia: Taps. Para llevar el conteo de cuantas veces le ha hecho tap al texto </value>
        public static int Taps = 0;

        /// <value>Variable de instancia: texto. texto original para ser leído</value>
        private String texto;

        /// <value>Variable de instancia: arreglo. Palabras almacenadas como ítems en el arreglo</value>
        private String[] arreglo;

        /// <value>Variable de instancia: palabra_inicio. Para saber el index de la palabra de inicio</value>
        private int palabra_inicio = 0;

        /// <value>Variable de instancia: palabra_fin. Para saber el index de la palabra de fin </value>
        private int palabra_fin = 0;
        /// <value>Variable de instancia: navigation. </value>
        private INavigation navigation;

        /// <value>Variable de instancia: StopWatch. Para llevar el control del tiempo</value>
        private Stopwatch StopWatch;
        /// <value>Variable de instancia: tiempo_finalizo. Para saber si el ejercicio ya finalizó</value>
        private bool tiempo_finalizo = false;


        /// <value>Variable de instancia: ejercicio. </value>
        private Ejercicio ejercicio;


        /// <value>Variable de instancia: _CronometroVelocidad. </value>
        private string _CronometroVelocidad;
        /// <summary>
        /// Gets or sets the "CronometroVelocidad" 
        /// </summary>
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

        /// <value>Variable de instancia: _InstruccionVelocidad. </value>
        private string _InstruccionVelocidad;
        /// <summary>
        /// Gets or sets the "InstruccionVelocidad" 
        /// </summary>
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

        /// <value>Variable de instancia: _ImagenVelocidad. </value>
        private string _ImagenVelocidad;
        /// <summary>
        /// Gets or sets the "ImagenVelocidad" 
        /// </summary>
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
        /// <summary>
        /// Constructor de la clase 'VelocidadViewModel'
        /// </summary>
        /// <param name="nav">INavigation.</param>
        /// <param name="ejercicio">Ejercicio.</param>
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
        /// <summary>
        /// aquí se agregan los span con base al arreglo de palabras
        /// </summary>
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
        /// <summary>
        /// Gets or sets the "ContenedorTexto" 
        /// </summary>
        public FormattedString ContenedorTexto
        {
            get
            {
                return GenerarTextoSpan();
            }
        }

        /// <value>Variable de instancia: Busy. </value>
        private bool Busy;
        /// <summary>
        /// Gets or sets the "IsBusy" 
        /// </summary>
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
        /// <summary>
        /// Recibe una llamada, cuando el span (palabra) es seleccionado (tap)  
        /// </summary>
        /// <param name="sender">object.</param>
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
