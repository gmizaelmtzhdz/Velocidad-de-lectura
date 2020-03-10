using System;
namespace Velocidaddelectura.Models
{
    /// <summary>
    /// Clase donde se almacena cada ítem de la categoría
    /// </summary>
    public class CategoriaModel
    {
        /// <value>Variable de instancia ID de la categoría</value>
        public int Id { get; set; }
        /// <value>Variable de instancia Nombre de la categoría</value>
        public string Nombre { get; set; }
        /// <value>Variable de instancia url relativa que representará a la categoría</value>
        public string Imagen { get; set; }
        /// <value>Variable de instancia descripción larga de la categoría</value>
        public string Descripcion { get; set; }
    }
}
