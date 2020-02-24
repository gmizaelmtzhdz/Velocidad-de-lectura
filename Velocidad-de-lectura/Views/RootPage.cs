using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Velocidad_de_lectura.Models;
using Velocidad_de_lectura.ViewModels;
using Velocidad_de_lectura.Views;
using Velocidaddelectura.Controls;
using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    public class  RootPage : MasterDetailPage
    {
        public static bool IsUWPDesktop { get; set; }

        Dictionary<int, NavigationPage> Pages { get; set; }
        public RootPage()
        {

            Pages = new Dictionary<int, NavigationPage>();
            Master = new MenuPage(this);
            BindingContext = new BaseViewModel
            {
                Title = "Velocidad",
                Icon = "burger_naranja.png"
            };


            VelocidadNavigationPage navigationPage = new VelocidadNavigationPage(new Inicio());
            //setup home page
            Pages.Add((int)MenuItemType.Inicio, navigationPage);
            Detail = Pages[(int)MenuItemType.Inicio];
            InvalidateMeasure();
        }



        public async Task NavigateAsync(int id)
        {

            if (Detail != null)
            {
                if (IsUWPDesktop || Device.Idiom != TargetIdiom.Tablet)
                    IsPresented = false;

                // if (Device.RuntimePlatform == Device.Android)await Task.Delay(300);
            }


            Page newPage;
            if (!Pages.ContainsKey(id))
            {

                switch (id)
                {
                    case (int)MenuItemType.Inicio:
                        Pages.Add(id, new VelocidadNavigationPage(new Inicio()));
                        break;
                    case (int)MenuItemType.Cronometro:
                        Pages.Add(id, new VelocidadNavigationPage(new Cronometro()));
                        break;
                    case (int)MenuItemType.Historial:
                        Pages.Add(id, new VelocidadNavigationPage(new Historial()));
                        break;
                    case (int)MenuItemType.AcercaDe:
                        Pages.Add(id, new VelocidadNavigationPage(new Acerca()));
                        break;
                }
            }

            newPage = Pages[id];
            if (newPage == null)
                return;

            //pop to root for Windows Phone
            if (Detail != null && Device.RuntimePlatform == Device.UWP)
            {
                await Detail.Navigation.PopToRootAsync();
            }
            Detail = newPage;
        }
    }
}