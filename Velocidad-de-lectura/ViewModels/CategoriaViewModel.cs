using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Velocidaddelectura.Models;
using Xamarin.Forms;

namespace Velocidaddelectura.ViewModels
{
    public class CategoriaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CategoriaModel> NombreCategoria { get; set; }
        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public CategoriaViewModel(INavigation navigation)
        {
            Navigation = navigation;
            NombreCategoria = new ObservableCollection<CategoriaModel>();

            NombreCategoria.Add(new CategoriaModel()
            {
                Id=1,
                Nombre="Arte",
                Description="Arte"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 2,
                Nombre = "Ciencia",
                Description = "Ciencia"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 3,
                Nombre = "Matemáticas",
                Description = "Matemáticas"
            });
        }
    }
}
