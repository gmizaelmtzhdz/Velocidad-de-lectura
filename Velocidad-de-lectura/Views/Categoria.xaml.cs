using System;
using System.Collections.Generic;
using Velocidaddelectura.ViewModels;
using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    public partial class Categoria : ContentPage
    {
        public Categoria()
        {
            InitializeComponent();

            this.BindingContext = new CategoriaViewModel(Navigation);
            ListCategorias.ItemSelected += ListCategorias_ItemSelected;
        }
        private async void ListCategorias_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var SelectedItem = e.SelectedItem as Models.CategoriaModel;
            if (SelectedItem != null)
            {
                await Navigation.PushAsync(new Velocidad(SelectedItem));
                ListCategorias.SelectedItem = null;
            }
        }
    }
}
