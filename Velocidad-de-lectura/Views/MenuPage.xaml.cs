using Velocidad_de_lectura.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Velocidad_de_lectura.ViewModels;
using Velocidaddelectura.Views;

namespace Velocidad_de_lectura.Views
{
    /// <summary>
    /// Clase de code behind de la vista 'MenuPage.xml'
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        /// <value>Variable de instancia para manejar el root (Page).</value>
        RootPage root;
        /// <value>Variable de instancia para agregar los ítems del menú</value>
        List<HomeMenuItem> menuItems;
        /// <summary>
        /// Constructor de la clase 'MenuPage'
        /// </summary>
        /// <param name="root">Parámetro RootPage.</param>
        public MenuPage(RootPage root)
        {
            this.root = root;
            InitializeComponent();
            BindingContext = new BaseViewModel
            {
                Title = "Velocidad",
                Icon = "burger_naranja.png"
            };
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {
                    Id = MenuItemType.Inicio,
                    Title="Inicio",
                    Icon ="home.png",
                    TextColor="#636363"
                },
                new HomeMenuItem {
                    Id = MenuItemType.Cronometro,
                    Icon ="cronometro_menu.png",
                    Title="Cronómetro",
                    TextColor="#636363"
                },
                new HomeMenuItem {
                    Id = MenuItemType.Historial,
                    Title="Historial",
                    Icon ="historial.png",
                    TextColor="#636363"
                },
                new HomeMenuItem {
                    Id = MenuItemType.AcercaDe,
                    Title="Acerca de",
                    Icon ="info.png",
                    TextColor="#636363"
                }
            };
            ListViewMenu.ItemsSource = menuItems;
            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;
                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await this.root.NavigateAsync((int)((HomeMenuItem)e.SelectedItem).Id);
            };
        }
    }
}