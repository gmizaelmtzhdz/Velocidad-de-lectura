using System;
using System.Collections.Generic;
using System.Text;

namespace Velocidad_de_lectura.Models
{
    /// <summary>
    /// Enum con los posibles ítems del menú
    /// </summary>
    public enum MenuItemType
    {
        Inicio,
        Cronometro,
        Historial,
        AcercaDe
    }
    /// <summary>
    /// Clase donde se almacena un ítem del menú
    /// </summary>
    public class HomeMenuItem
    {
        /// <value>Variable de instancia ID del ítem del menú</value>
        public MenuItemType Id { get; set; }
        /// <value>Variable de instancia Titulo del menú</value>
        public string Title { get; set; }
        /// <value>Variable de instancia string con la url relativa del ícono del ítem del menú</value>
        public string Icon { get; set; }
        /// <value>Variable de instancia color que deberá tener el ítem del menú</value>
        public string TextColor { get; set; }
    }
}
