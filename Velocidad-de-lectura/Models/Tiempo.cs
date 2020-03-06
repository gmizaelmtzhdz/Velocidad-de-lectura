using System;
namespace Velocidaddelectura.Models
{
    /// <summary>
    /// Clase Tiempo utilizada para mostrarle al usuario el select con las opciones de tiempo para realizar el ejercicio (Ej. 15 segundos, 30 segundos, 60 segundos)
    /// </summary>
    public class Tiempo
    {
        /// <value>Variable de instancia: Etiqueta utilizada para mostrar el texto del tiempo </value>
        public string Etiqueta { get; set; }
        /// <value>Variable de instancia: Segundos </value>
        public int Segundos { get; set; }
    }
}
