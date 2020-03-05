using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Velocidaddelectura.Models;
using Velocidaddelectura.Services;
using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    /// <summary>
    /// Clase de code behind de la vista 'Resumen.xml' donde el usuario puede cambiar el resumen de su Ejercicio, donde se le muestra la cantidad de palabras leídas y el tiempo
    /// </summary>
    public partial class Resumen : ContentPage
    {
        /// <value>Almacena una instancia de la clase Ejercicio. Esta vista modifica de 'Ejercicio' la variable de instancia: -Segundos, -TamanoFuente y -Texto </value>
        private Ejercicio ejercicio;
        /// <value> Variable de instancia para mandar llamar a GuardarHistorialAsync()... </value>
        public Command GuardarHistorialCommand { get; set; }
        /// <summary>
        /// Constructor de la clase 'Historial'
        /// </summary>
        /// <param name="ejercicio">Parámetro Ejercicio.</param>
        public Resumen(Ejercicio ejercicio)
        {
            InitializeComponent();
            this.ejercicio = ejercicio;
            LblCantidadPalabras.Text = ""+ejercicio.PalabrasLeidas;
            LblResumen.Text = "Palabras en "+ejercicio.Segundos+" segundos";

            GuardarHistorialCommand = new Command(async () => await GuardarHistorialAsync(), () => !IsBusy);
            GuardarHistorialCommand.Execute(null);
        }
        /// <summary>
        /// Para guardar la velocidad del ejercicio
        /// </summary>
        private async Task GuardarHistorialAsync()
        {
            GuardarInformacionServices guardarInformacionServices = new GuardarInformacionServices();
            await guardarInformacionServices.GuardarInformacion(this.ejercicio);
        }
        /// <summary>
        /// Recibe una llamada, cuando el botón 'CONTINUAR' es seleccionado (tap)  
        /// </summary>
        private void BtnSeleccion_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(false);
            Navigation.PopAsync(false);
            Navigation.PopAsync(false);
            Navigation.PopAsync(false);
            Navigation.PushAsync(new Inicio(), true);
            Navigation.PopAsync(false);
            Navigation.PopAsync(false);
        }
    }
}
