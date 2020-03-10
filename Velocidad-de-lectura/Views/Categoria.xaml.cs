using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Velocidaddelectura.Models;
using Velocidaddelectura.ViewModels;
using Xamarin.Forms;

namespace Velocidaddelectura.Views
{
    /// <summary>
    /// Clase de code behind de la vista 'Categoria.xml' donde se muestra una lista con las categorías disponibles
    /// </summary>
    public partial class Categoria : ContentPage
    {
        /// <summary>
        /// Constructor de la clase 'Categoria'
        /// </summary>
        public Categoria()
        {
            InitializeComponent();
            this.BindingContext = new CategoriaViewModel(Navigation);
        }
    }
}
