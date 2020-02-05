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
                Id = 2,
                Nombre = "Moda y belleza",
                Imagen = "moda.png",
                Descripcion = "Moda y belleza"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 1,
                Nombre = "Cuentos infantiles",
                Imagen = "cuentos.png",
                Descripcion = "Cuentos infantiles"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 2,
                Nombre = "Tecnología",
                Imagen = "tecnologia.png",
                Descripcion = "Tecnología"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 2,
                Nombre = "Naturaleza",
                Imagen = "naturaleza.png",
                Descripcion = "Naturaleza"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id=1,
                Nombre="Arte",
                Imagen = "arte.png", Descripcion="Arte"
            });
            
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 1,
                Nombre = "Baile",
                Imagen = "baile.png", Descripcion = "Baile"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 1,
                Nombre = "Negocios",
                Imagen = "negocios.png", Descripcion = "Negocios"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 1,
                Nombre = "Ciencia Ficción",
                Imagen = "ciencia_ficcion.png", Descripcion = "Ciencia Ficción"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 2,
                Nombre = "Juegos",
                Imagen = "juegos.png", Descripcion = "Juegos"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 2,
                Nombre = "Cine",
                Imagen = "cine.png", Descripcion = "Cine"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 2,
                Nombre = "Deporte",
                Imagen = "deporte.png", Descripcion = "Deporte"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 2,
                Nombre = "Idiomas",
                Imagen = "idiomas.png", Descripcion = "Idiomas"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 2,
                Nombre = "Mascotas",
                Imagen = "mascota.png", Descripcion = "Mascotas"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 2,
                Nombre = "Música",
                Imagen = "musica.png", Descripcion = "Música"
            });
            
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 2,
                Nombre = "Salud",
                Imagen = "salud.png", Descripcion = "Salud"
            });
            
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 3,
                Nombre = "Matemáticas",
                Imagen = "matematicas.png", Descripcion = "Matemáticas"
            });
        }
    }
}
