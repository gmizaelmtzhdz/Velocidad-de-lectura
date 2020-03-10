using System;
using Xamarin.Forms;

namespace Velocidaddelectura.Controls
{
    /// <summary>
    /// Clase de 'VelocidadNavigationPage.cs' para manejo del master detail
    /// </summary>
    public class VelocidadNavigationPage : NavigationPage
    {
        /// <summary>
        /// Constructor de la clase 'VelocidadNavigationPage'
        /// </summary>
        /// <param name="root">Parámetro Page.</param>
        public VelocidadNavigationPage(Page root) : base(root)
        {
            Init();
        }
        /// <summary>
        /// Constructor de la clase 'VelocidadNavigationPage'
        /// </summary>
        public VelocidadNavigationPage()
        {
            Init();
        }
        /// <summary>
        /// Init, establece propiedades de la vista como el color del bar tool, el titulo, etc.
        /// </summary>
        void Init()
        {
            BarBackgroundColor = Color.FromRgb(255, 255, 255);
            BarTextColor = Color.Black;
            Title = "Velocidad";
        }
    }
}
