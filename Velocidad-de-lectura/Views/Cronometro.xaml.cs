using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    /// <summary>
    /// Clase de code behind de la vista 'Cronometro.xml' donde el usuario puede tomar el tiempo para ejercicios independientes
    /// </summary>
    public partial class Cronometro : ContentPage
    {
        /// <value> Variable de instancia para llevar el control del tiempo (cronómetro) </value>
        private Stopwatch StopWatch;
        /// <value> Variable de instancia para saber cuántos taps ha dado el usuario en las palabras </value>
        private int inicio = 0;

        /// <summary>
        /// Constructor de la clase 'Cronometro'
        /// </summary>
        public Cronometro()
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
            switch(inicio)
            {
                case 0:
                    BtnAccion.Text = "Detener";
                    StopWatch = new Stopwatch();
                    if (!StopWatch.IsRunning) { StopWatch.Start(); }
                    else { StopWatch.Stop(); StopWatch.Reset(); }
                    Device.StartTimer(new TimeSpan(0, 0, 1), () => {
                        if (StopWatch.IsRunning)
                        {
                            string hora = ""+(StopWatch.Elapsed.Hours<10 ? "0"+Convert.ToString(StopWatch.Elapsed.Hours): Convert.ToString(StopWatch.Elapsed.Hours));
                            string minuto = "" + (StopWatch.Elapsed.Minutes < 10 ? "0" + Convert.ToString(StopWatch.Elapsed.Minutes) : Convert.ToString(StopWatch.Elapsed.Minutes));
                            string segundo = "" + (StopWatch.Elapsed.Seconds < 10 ? "0" + Convert.ToString(StopWatch.Elapsed.Seconds) : Convert.ToString(StopWatch.Elapsed.Seconds));  
                            LblCronometroTiempo.Text = hora + ":" + minuto + ":" + segundo;
                        }
                        return true;

                    });
                    inicio++;
                    break;
                case 1:
                    BtnAccion.Text = "Reiniciar";
                    StopWatch.Stop();
                    StopWatch.Reset();
                    inicio++;
                    break;
                case 2:
                    BtnAccion.Text = "Iniciar";
                    LblCronometroTiempo.Text = "00:00:00";
                    inicio = 0;
                    break;
            }
        }
    }
}
