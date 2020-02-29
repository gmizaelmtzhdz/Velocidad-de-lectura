using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Velocidaddelectura.Services;
using Xamarin.Forms;

namespace Velocidaddelectura.ViewModels
{
    public class ExtraccionContenidoViewModel
    {
        public ExtraccionContenidoViewModel()
        {

        }
        public async Task<string> GetContenidoAsync(string categoria)
        {
            string Contenido = "";
            try
            {
                WebClient client = new WebClient();
                string palabra_clave = ExtraccionContenidoService.GetPalabraClave(categoria);
                using (Stream stream =  client.OpenRead("http://es.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&explaintext=1&titles=" + palabra_clave))
                using (StreamReader reader = new StreamReader(stream))
                {
                    JsonSerializer ser = new JsonSerializer();
                    Result result = ser.Deserialize<Result>(new JsonTextReader(reader));
                    foreach (Page page in result.query.pages.Values)
                    {
                        Console.WriteLine(page.extract);
                        Contenido = page.extract;
                    }
                    if(String.IsNullOrEmpty(Contenido))
                    {
                        Contenido = "Larry Page y Sergey Brin comenzaron Google como un proyecto universitario en enero de 1996 cuando ambos eran estudiantes de posgrado en ciencias de la computación en la Universidad de Stanford. El nombre original del buscador era BackRub, en 1997 los fundadores deciden cambiar el nombre a Google inspirados por el término matemático «gúgol» que se refiere al número 10 elevado a la potencia de 100, en referencia a su objetivo de organizar la enorme cantidad de información en la Web. Page y Brin fundan, el 4 de septiembre de 1998, la compañía Google Inc.,​ que estrena en Internet su motor de búsqueda el 27 de septiembre siguiente (considerada la fecha de aniversario). Contaban con un armario lleno de servidores (unos 80 procesadores), y dos routers HP. Este motor de búsqueda superó al otro más popular de la época, AltaVista, que había sido creado en 1995. En el 2000 Google presentó AdWords, su sistema de publicidad en línea y la llamada Barra Google. En febrero de 2001, Google compra el servicio de debate Usenet Deja News y lo transforma en Google Grupos.En marzo del mismo año Eric Schmidt es nombrado presidente de la junta directiva. En julio de 2001 lanza su servicio de búsqueda de imágenes.En febrero de 2002 lanza Google Search Appliance. En mayo lanza Google Labs que cerrará 9 años más tarde.En septiembre se lanza Google Noticias. En diciembre del mismo año se lanza el servicio de búsqueda de productos llamado Froogle, ahora denominado Google Products. En febrero de 2003 Google adquiere Pyra Labs y con ello el servicio de creación de blogs Blogger. En abril se presenta Google Grants, un servicio de publicidad gratuito para organizaciones sin ánimo de lucro. En diciembre de ese año se lanza Google Print, posteriormente Google Libros.";
                    }
                    else
                    {
                        if(Contenido.Length==0)
                        {
                            Contenido = "Larry Page y Sergey Brin comenzaron Google como un proyecto universitario en enero de 1996 cuando ambos eran estudiantes de posgrado en ciencias de la computación en la Universidad de Stanford. El nombre original del buscador era BackRub, en 1997 los fundadores deciden cambiar el nombre a Google inspirados por el término matemático «gúgol» que se refiere al número 10 elevado a la potencia de 100, en referencia a su objetivo de organizar la enorme cantidad de información en la Web. Page y Brin fundan, el 4 de septiembre de 1998, la compañía Google Inc.,​ que estrena en Internet su motor de búsqueda el 27 de septiembre siguiente (considerada la fecha de aniversario). Contaban con un armario lleno de servidores (unos 80 procesadores), y dos routers HP. Este motor de búsqueda superó al otro más popular de la época, AltaVista, que había sido creado en 1995. En el 2000 Google presentó AdWords, su sistema de publicidad en línea y la llamada Barra Google. En febrero de 2001, Google compra el servicio de debate Usenet Deja News y lo transforma en Google Grupos.En marzo del mismo año Eric Schmidt es nombrado presidente de la junta directiva. En julio de 2001 lanza su servicio de búsqueda de imágenes.En febrero de 2002 lanza Google Search Appliance. En mayo lanza Google Labs que cerrará 9 años más tarde.En septiembre se lanza Google Noticias. En diciembre del mismo año se lanza el servicio de búsqueda de productos llamado Froogle, ahora denominado Google Products. En febrero de 2003 Google adquiere Pyra Labs y con ello el servicio de creación de blogs Blogger. En abril se presenta Google Grants, un servicio de publicidad gratuito para organizaciones sin ánimo de lucro. En diciembre de ese año se lanza Google Print, posteriormente Google Libros.";
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Contenido = "Larry Page y Sergey Brin comenzaron Google como un proyecto universitario en enero de 1996 cuando ambos eran estudiantes de posgrado en ciencias de la computación en la Universidad de Stanford. El nombre original del buscador era BackRub, en 1997 los fundadores deciden cambiar el nombre a Google inspirados por el término matemático «gúgol» que se refiere al número 10 elevado a la potencia de 100, en referencia a su objetivo de organizar la enorme cantidad de información en la Web. Page y Brin fundan, el 4 de septiembre de 1998, la compañía Google Inc.,​ que estrena en Internet su motor de búsqueda el 27 de septiembre siguiente (considerada la fecha de aniversario). Contaban con un armario lleno de servidores (unos 80 procesadores), y dos routers HP. Este motor de búsqueda superó al otro más popular de la época, AltaVista, que había sido creado en 1995. En el 2000 Google presentó AdWords, su sistema de publicidad en línea y la llamada Barra Google. En febrero de 2001, Google compra el servicio de debate Usenet Deja News y lo transforma en Google Grupos.En marzo del mismo año Eric Schmidt es nombrado presidente de la junta directiva. En julio de 2001 lanza su servicio de búsqueda de imágenes.En febrero de 2002 lanza Google Search Appliance. En mayo lanza Google Labs que cerrará 9 años más tarde.En septiembre se lanza Google Noticias. En diciembre del mismo año se lanza el servicio de búsqueda de productos llamado Froogle, ahora denominado Google Products. En febrero de 2003 Google adquiere Pyra Labs y con ello el servicio de creación de blogs Blogger. En abril se presenta Google Grants, un servicio de publicidad gratuito para organizaciones sin ánimo de lucro. En diciembre de ese año se lanza Google Print, posteriormente Google Libros.";
                //Application.Current.MainPage.DisplayAlert("Extracción de contenido", e.ToString(), "Continuar");
            }
            Contenido = LimpiarTexto(Contenido);
            return Contenido;
        }
        private String LimpiarTexto(string Contenido)
        {
            //string a = "El arte (del latín ars, artis, y este del griego τέχνη téchnē)[1] es entendido, lingüísticos, sonoros, corporales y mixtos.[1]";

            Regex regexComillasSimples = new Regex("[‘’'\"]");
            Contenido = regexComillasSimples.Replace(Contenido, "");


            Regex regexCorchete = new Regex(@"\[([^\]]*)\]");
            Contenido = regexCorchete.Replace(Contenido, "");

            

            Regex regexParentesis = new Regex(@"\([^)]*\)");
            Contenido = regexParentesis.Replace(Contenido, "");



            //Regex regexTitulos1 = new Regex(@"===([^\]]*)===");
            //Contenido = regexTitulos1.Replace(Contenido, "");

            //Regex regexTitulos2 = new Regex(@"==([^\]]*)==");
            //Contenido = regexTitulos2.Replace(Contenido, "");

            Contenido = Contenido.Trim();
            Contenido = Contenido.TrimStart();
            Contenido = Contenido.TrimEnd();

            return Contenido;
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
