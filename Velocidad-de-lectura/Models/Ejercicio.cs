using System;
namespace Velocidaddelectura.Models
{
    public class Ejercicio
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public int TamanoFuente { get; set; }
        public int Segundos { get; set; }
        public int PalabrasLeidas { get; set; }
        public string Texto { get; set; }
    }
}
