using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Velocidaddelectura.Models;

namespace Velocidaddelectura.Services
{
    public class TiempoConfiguracionEjercicioServices
    {
        public TiempoConfiguracionEjercicioServices()
        {

        }
        public async Task<List<Tiempo>> GetEtiquetasTiempo()
        {
            List<Tiempo> tiempos = null;
            try
            {
                var tiempo = new Tiempo();
                tiempo.Etiqueta = "15 Segundos";
                tiempo.Segundos = 15;

                tiempos.Add(tiempo);
            }
            catch (Exception ex)
            {
                
            }
            return tiempos;
        }


    }
}
