using System;
using System.Collections.Generic;
using System.Text;

namespace Velocidad_de_lectura.Models
{
    public enum MenuItemType
    {
        Inicio,
        AcercaDe
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
