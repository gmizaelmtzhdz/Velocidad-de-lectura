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
        public Velocidad(CategoriaModel categoria)
        {
            InitializeComponent();
            VelocidadViewModel velocidadViewModel = new VelocidadViewModel(Navigation);
            velocidadViewModel.ImagenVelocidad = "cohete_solo.png";
            velocidadViewModel.TiempoConfigurado = 30; //segundos
            velocidadViewModel.InstruccionVelocidad = "Selecciona una palabra para iniciar";
            velocidadViewModel.CronometroVelocidad = "";
            


            this.BindingContext = velocidadViewModel;
        }
    }
}
