using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Velocidaddelectura.ViewModels
{
    public class ExtraccionContenidoViewModel
    {
        public ExtraccionContenidoViewModel()
        {

        }
        public string GetContenido(string palabra_clave)
        {
            string contenido = "";
            WebClient client = new WebClient();
            using (Stream stream = client.OpenRead("http://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&explaintext=1&titles="+ palabra_clave))
            using (StreamReader reader = new StreamReader(stream))
            {
                JsonSerializer ser = new JsonSerializer();
                Result result = ser.Deserialize<Result>(new JsonTextReader(reader));
                
                foreach (Page page in result.query.pages.Values)
                {
                    Console.WriteLine(page.extract);
                    contenido = page.extract;
                }
                    
            }
            return contenido;
        }
    }
    public class Result
    {
        public Query query { get; set; }
    }

    public class Query
    {
        public Dictionary<string, Page> pages { get; set; }
    }

    public class Page
    {
        public string extract { get; set; }
    }
}
