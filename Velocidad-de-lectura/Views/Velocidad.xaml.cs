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
    /// <summary>
    /// Clase de code behind de la vista 'Velocidad.xml' donde el usuario puede realizar el ejercicio de lectura
    /// </summary>
    public partial class Velocidad : ContentPage
    {
        /// <summary>
        /// Constructor de la clase 'Velocidad'
        /// </summary>
        /// <param name="ejercicio">Parámetro Ejercicio.</param>
        public Velocidad(Ejercicio ejercicio)
        {
            InitializeComponent();
            LblTexto.FontSize = ejercicio.TamanoFuente;
            VelocidadViewModel velocidadViewModel = new VelocidadViewModel(Navigation, ejercicio);
            velocidadViewModel.ImagenVelocidad = "cohete_solo.png";
            velocidadViewModel.InstruccionVelocidad = "Selecciona una palabra para iniciar";
            velocidadViewModel.CronometroVelocidad = "";

            this.BindingContext = velocidadViewModel;
        }
    }
}
