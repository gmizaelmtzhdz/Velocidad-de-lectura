using Velocidad_de_lectura.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Velocidad_de_lectura.ViewModels;

namespace Velocidad_de_lectura.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {
                    Id = MenuItemType.Inicio,
                    Title="Inicio",
                    Icon ="home.png",
                    TextColor="#000000"
                },
                new HomeMenuItem {
                    Id = MenuItemType.Inicio,
                    Icon ="configuracion.png",
                    Title="Configuración",
                    TextColor="#000000"
                },
                new HomeMenuItem {
                    Id = MenuItemType.Inicio,
                    Title="Historial",
                    Icon ="historial.png",
                    TextColor="#000000"
                },
                new HomeMenuItem {
                    Id = MenuItemType.AcercaDe,
                    Title="Acerca de",
                    Icon ="info.png",
                    TextColor="#000000"
                }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}