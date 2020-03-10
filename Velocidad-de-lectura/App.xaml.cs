using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Velocidad_de_lectura.Views;

namespace Velocidad_de_lectura
{
    /// <summary>
    /// App 
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Constructor de la clase 'App'
        /// </summary(
        public App()
        {
            InitializeComponent();
            MainPage = new RootPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
