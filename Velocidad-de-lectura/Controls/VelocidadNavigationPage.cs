using System;
using Xamarin.Forms;

namespace Velocidaddelectura.Controls
{
    public class VelocidadNavigationPage : NavigationPage
    {
        public VelocidadNavigationPage(Page root) : base(root)
        {
            Init();
        }

        public VelocidadNavigationPage()
        {
            Init();
        }

        void Init()
        {
            BarBackgroundColor = Color.FromRgb(255, 255, 255);
            BarTextColor = Color.Black;
            Title = "Velocidad";
        }
    }
}
