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
        public Velocidad(Ejercicio ejercicio)
        {
            InitializeComponent();
            VelocidadViewModel velocidadViewModel = new VelocidadViewModel(Navigation, ejercicio);
            velocidadViewModel.ImagenVelocidad = "cohete_solo.png";
            velocidadViewModel.InstruccionVelocidad = "Selecciona una palabra para iniciar";
            velocidadViewModel.CronometroVelocidad = "";
            


            this.BindingContext = velocidadViewModel;
        }
    }
}
