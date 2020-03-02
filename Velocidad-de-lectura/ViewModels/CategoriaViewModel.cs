using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Velocidaddelectura.Models;
using Velocidaddelectura.Views;
using Xamarin.Forms;

namespace Velocidaddelectura.ViewModels
{
    public class CategoriaViewModel : INotifyPropertyChanged
    {
        private Ejercicio ejercicio;
        public ObservableCollection<CategoriaModel> NombreCategoria { get; set; }
        public INavigation Navigation { get; set; }
        public Command GetCategoriasCommand { get; set; }

        public CategoriaViewModel(INavigation navigation)
        {
            Navigation = navigation;

            this.ejercicio = new Ejercicio();
            NombreCategoria = new ObservableCollection<CategoriaModel>();

            GetCategoriasCommand = new Command(async () => await LlenarCategorias());
            GetCategoriasCommand.Execute(null);
        }
        public CategoriaModel _selectedItem;
        public CategoriaModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                IsBusy = true;
                if (_selectedItem == null)
                {
                    IsBusy = false;
                    return;
                }
                ejercicio.Categoria = _selectedItem.Nombre;
                Device.BeginInvokeOnMainThread(Lanzar);
            }
        }
        private async void Lanzar()
        {
            try
            {
                await LanzarAsync();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        private async Task LanzarAsync()
        {
            await Navigation.PushAsync(new ConfiguracionEjercicio(ejercicio));

            IsBusy = false;
        }


        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handle = PropertyChanged;
            if (handle != null)
                handle(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private bool Busy;
        public bool IsBusy
        {
            get
            {
                return Busy;
            }
            set
            {
                Busy = value;
                RaisePropertyChanged("IsBusy");
            }
        }
        public async Task LlenarCategorias()
        {
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 1,
                Nombre = "Moda y belleza",
                Imagen = "moda.png",
                Descripcion = "Moda y belleza"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 2,
                Nombre = "Cuentos infantiles",
                Imagen = "cuentos.png",
                Descripcion = "Cuentos infantiles"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 3,
                Nombre = "Tecnología",
                Imagen = "tecnologia.png",
                Descripcion = "Tecnología"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 4,
                Nombre = "Naturaleza",
                Imagen = "naturaleza.png",
                Descripcion = "Naturaleza"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 5,
                Nombre = "Arte",
                Imagen = "arte.png",
                Descripcion = "Arte"
            });

            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 6,
                Nombre = "Baile",
                Imagen = "baile.png",
                Descripcion = "Baile"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 7,
                Nombre = "Negocios",
                Imagen = "negocios.png",
                Descripcion = "Negocios"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 8,
                Nombre = "Ciencia Ficción",
                Imagen = "ciencia_ficcion.png",
                Descripcion = "Ciencia Ficción"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 9,
                Nombre = "Juegos",
                Imagen = "juegos.png",
                Descripcion = "Juegos"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 10,
                Nombre = "Cine",
                Imagen = "cine.png",
                Descripcion = "Cine"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 11,
                Nombre = "Deporte",
                Imagen = "deporte.png",
                Descripcion = "Deporte"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 12,
                Nombre = "Idiomas",
                Imagen = "idiomas.png",
                Descripcion = "Idiomas"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 13,
                Nombre = "Mascotas",
                Imagen = "mascota.png",
                Descripcion = "Mascotas"
            });
            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 14,
                Nombre = "Música", 
                Imagen = "musica.png",
                Descripcion = "Música"
            });

            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 15,
                Nombre = "Salud",
                Imagen = "salud.png",
                Descripcion = "Salud"
            });

            NombreCategoria.Add(new CategoriaModel()
            {
                Id = 16,
                Nombre = "Matemáticas",
                Imagen = "matematicas.png",
                Descripcion = "Matemáticas"
            });
        }
        
    }
}
