using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Velocidaddelectura.Models;
using Xamarin.Forms;

namespace Velocidaddelectura.Services
{
    /// <summary>
    /// Clase GuardarInformacionServices, utilizada para guardar y extraer info. en el Dispositivo
    /// </summary>
    public class GuardarInformacionServices
    {
        /// <summary>
        /// GuardarInformacion: guarda en formato JSON el ejercicio hecho por el usuario
        /// </summary>
        /// <param name="ejercicio">Parámetro ejercicio.</param>
        public async Task GuardarInformacion(Ejercicio ejercicio)
        {
            List<Ejercicio> historico = this.ObtenerInformacion();
            historico.Add(ejercicio);
            //Application.Current.MainPage.DisplayAlert("Json", JsonConvert.SerializeObject(historico), "Continuar");
            Application.Current.Properties["historico_velocidad"] = JsonConvert.SerializeObject(historico);
            await Application.Current.SavePropertiesAsync();
        }
        /// <summary>
        /// ObtenerInformacion: obtiene el historico de los ejercicios hechos por el usuario. Parsea de formato JSON a List Ejercicio
        /// </summary>
        /// <param name="ejercicio">Parámetro ejercicio.</param>
        /// <returns>
        /// Una lista con los ejercicios hechos (tipo de dato: Ejercicio)
        /// </returns>
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
                    Console.Write(e);
                }
            }
            return historico;
        }
    }
}
