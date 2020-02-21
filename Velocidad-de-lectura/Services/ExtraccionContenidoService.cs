using System;
using System.Collections;

namespace Velocidaddelectura.Services
{
    public class ExtraccionContenidoService
    {
        public ExtraccionContenidoService()
        {
        }
        public static string GetPalabraClave(string categoria)
        {
            string resultado = "";
            ArrayList list = new ArrayList();
            Random random = new Random();
            switch (categoria)
            {
                case "Moda y belleza":
                    list.Add("Moda");
                    list.Add("Elegancia");
                    list.Add("Modista");
                    resultado = Convert.ToString(list[random.Next(0, list.Count)]);
                    break;
            }
            return resultado;
        }
    }
}
