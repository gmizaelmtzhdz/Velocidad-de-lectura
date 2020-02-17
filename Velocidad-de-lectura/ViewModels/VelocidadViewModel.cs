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

        public int TiempoConfigurado { get; set; }

        

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


        public VelocidadViewModel(INavigation nav)
        {
            Taps = 0;
            texto = "What is Lorem Ipsum? Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum. Why do we use it? It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like). Where does it come from? Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham. Where can I get some? There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.";
            arreglo = texto.Split(' ');
            navigation = nav;
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
            FormattedString formattedString = new FormattedString();
            Span span = null;
            int limite = arreglo.Length>250?250:arreglo.Length;

            for (var i = 0; i < limite; i++)
            {
                span = new Span {Text = arreglo[i] + "   " };
                span.StyleId = Convert.ToString(i + 1);
                span.GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = TapCommand,
                    CommandParameter = span
                });

                formattedString.Spans.Add(span);
            }
            return formattedString;
        }

        public FormattedString ContenedorTexto
        {
            get
            {
                return GenerarTextoSpan();
            }
        }
        public void SpanClicked(object sender)
        {
            Span palabra = (Span)sender;
            switch (Taps)
            {
                case 0:
                    Taps++;
                    palabra.FontSize = 38;
                    palabra.TextColor = Color.Green;
                    palabra_inicio = Convert.ToInt32(palabra.StyleId);
                    tiempo_finalizo = false;
                    StopWatch = new Stopwatch();
                    if (!StopWatch.IsRunning) { StopWatch.Start(); }
                    else { StopWatch.Stop(); StopWatch.Reset();}
                    Device.StartTimer(new TimeSpan(0, 0, 1), () => {
                        CronometroVelocidad = StopWatch.Elapsed.Seconds+"/"+ TiempoConfigurado + " segundos";
                        if (StopWatch.IsRunning && StopWatch.Elapsed.Seconds >= TiempoConfigurado)
                        {
                            StopWatch.Stop();
                            StopWatch.Reset();
                            tiempo_finalizo = true;
                            Application.Current.MainPage.DisplayAlert("Ejercicio Finalizado", "Selecciona la última palabra leída", "Ok");
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
                        palabra.FontSize = 38;
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
                        navigation.PushAsync(new Resumen(1, 2));
                    }
                    break;
                default:
                    Taps = 0;
                    palabra_inicio = 0;
                    palabra_fin = 0;
                    break;
            }
        }
    }
}
