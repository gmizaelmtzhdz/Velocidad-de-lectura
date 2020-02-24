using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Velocidaddelectura.Models;
using Xamarin.Forms;

namespace Velocidaddelectura.Services
{
    public class GuardarInformacionServices
    {
        public GuardarInformacionServices()
        {

        }
        public async Task GuardarInformacion(Ejercicio ejercicio)
        {
            List<Ejercicio> historico = this.ObtenerInformacion();
            historico.Add(ejercicio);

            //Application.Current.MainPage.DisplayAlert("Json", JsonConvert.SerializeObject(historico), "Continuar");

            Application.Current.Properties["historico_velocidad"] = JsonConvert.SerializeObject(historico);
            await Application.Current.SavePropertiesAsync();
        }
        public List<Ejercicio> ObtenerInformacion()
        {
            List < Ejercicio > historico=new List<Ejercicio>();
            if (Application.Current.Properties.ContainsKey("historico_velocidad"))
            {
                var json = Application.Current.Properties["historico_velocidad"].ToString();
                try
                {
                    historico = JsonConvert.DeserializeObject<List<Ejercicio>>(json);
                }catch(Exception e)
                {
                    historico = new List<Ejercicio>();
                }
            }
            return historico;
        }
    }
}
