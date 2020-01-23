using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Velocidad_de_lectura.Services;
using Velocidad_de_lectura.Views;

namespace Velocidad_de_lectura
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
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
