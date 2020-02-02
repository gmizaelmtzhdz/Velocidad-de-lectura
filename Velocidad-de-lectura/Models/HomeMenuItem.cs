using System;
using System.Collections.Generic;
using System.Text;

namespace Velocidad_de_lectura.Models
{
    public enum MenuItemType
    {
        Inicio,
        Configuracion,
        Historial,
        AcercaDe
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string TextColor { get; set; }
    }
}
