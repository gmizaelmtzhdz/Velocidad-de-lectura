using System;
namespace Velocidaddelectura.Models
{
    /// <summary>
    /// Clase donde se almacena un ítem por ejercicio HECHO
    /// </summary>
    public class Ejercicio
    {
        /// <value>Variable de instancia ID del ejercicio</value>
        public int Id { get; set; }
        /// <value>Variable de instancia, categoría seleccionada</value>
        public string Categoria { get; set; }
        /// <value>Variable de instancia, tamaño de la letra ej. 14, 24, 28, etc.</value>
        public int TamanoFuente { get; set; }
        /// <value>Variable de instancia, segundos que duró el ejercicio</value>
        public int Segundos { get; set; }
        /// <value>Variable de instancia, palabras que leyó en el ejercicio</value>
        public int PalabrasLeidas { get; set; }
        /// <value>Variable de instancia, texto que se le mostró en el ejercicio para que leyera</value>
        public string Texto { get; set; }
    }
}
