using System;
using System.Collections;

namespace Velocidaddelectura.Services
{
    /// <summary>
    /// Clase ExtraccionContenidoService, utilizada para generar los ítems de la categoria
    /// </summary>
    public class ExtraccionContenidoService
    {
        /// <summary>
        /// Clase ExtraccionContenidoService, utilizada para la extracción de palabras clave con base en la categoria
        /// </summary>
        /// <param name="categoria">Categoría seleccionada</param>
        /// <returns>
        /// Retorna una palabra o palabras clave con base en la categoria seleccionada, las palabras se utilizan para la extracción de un texto relacionado al tema
        /// </returns>
        public static string GetPalabraClave(string categoria)
        {
            string resultado = "";
            ArrayList list = new ArrayList();
            Random random = new Random();
            switch (categoria)
            {
                case "Moda y belleza":
                    list.Add("Moda");
                    list.Add("Belleza");
                    list.Add("Estética");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Cuentos infantiles":
                    list.Add("Cuento infantil");
                    list.Add("Aladino");
                    list.Add("El yesquero");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Tecnología":
                    list.Add("Tecnología");
                    list.Add("Ciencia");
                    list.Add("Método científico");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Naturaleza":
                    list.Add("Naturaleza");
                    list.Add("Universo");
                    list.Add("Ecosistema");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Arte":
                    list.Add("Arte");
                    list.Add("La Gioconda");
                    list.Add("Artista");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Baile":
                    list.Add("Arte");
                    list.Add("Ritmo");
                    list.Add("Movimiento artístico");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Negocios":
                    list.Add("Negociación");
                    list.Add("Liderazgo");
                    list.Add("Emprendimiento");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Ciencia Ficción":
                    list.Add("Ciencia Ficción");
                    list.Add("Androide");
                    list.Add("Clima ficción");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Juegos":
                    list.Add("Juegos");
                    list.Add("Juegos Olímpicos");
                    list.Add("Fútbol");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Cine":
                    list.Add("Cine");
                    list.Add("Actuación");
                    list.Add("Cortometraje");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Deporte":
                    list.Add("Deporte");
                    list.Add("Fútbol");
                    list.Add("Baloncesto");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Idiomas":
                    list.Add("Idioma");
                    list.Add("Gramática");
                    list.Add("Lenguaje");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Mascotas":
                    list.Add("Animalia");
                    list.Add("Vertebrata");
                    list.Add("Arachnida");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Música":
                    list.Add("Música");
                    list.Add("Género musical");
                    list.Add("Sonido");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Salud":
                    list.Add("Salud");
                    list.Add("Medicina");
                    list.Add("Nutrición");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
                case "Matemáticas":
                    list.Add("Matemáticas");
                    list.Add("Axioma");
                    list.Add("Número");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;

            }
            return resultado;
        }
    }
}
