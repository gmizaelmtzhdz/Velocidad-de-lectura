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
            VelocidadViewModel.TiempoConfigurado = 30; //segundos

            this.BindingContext = velocidadViewModel;
        }
    }
}
