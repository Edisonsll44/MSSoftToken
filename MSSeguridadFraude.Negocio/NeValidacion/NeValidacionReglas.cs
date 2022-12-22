using MSSeguridadFraude.AccesoDatos.AdReglas;
using MSSeguridadFraude.Entidades.ReglasOperacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguridadFraude.Negocio.NeValidacion
{
    public class NeValidacionReglas
    {
        protected NeValidacionReglas()
        {

        }

        /// <summary>
        /// Metodo que valida si la operacion y el monto estan permitidos
        /// </summary>
        /// <param name="reglaOperacion">EReglaOperacion</param>
        /// <returns>ERespuestaRegla</returns>
        public static ERespuestaRegla ValidarReglas(EReglaOperacion reglaOperacion)
        {

            //Valida si la operacion esta permitida
            ERespuestaRegla respuestaRegla = AdReglasNegocio.VerificarOperacionPermitidaCache(reglaOperacion);

            return respuestaRegla;
        }
    }
}
