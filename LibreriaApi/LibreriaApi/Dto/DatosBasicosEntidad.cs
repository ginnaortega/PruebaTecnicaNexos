using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaApi.Dto
{
    public class DatosBasicosEntidad
    {
     
        /// <summary>
        /// Identificador de la entidad.
        /// </summary>
        public int Identificador { get; set; }

        /// <summary>
        /// Descripción de la entidad.
        /// </summary>
        public string Descripcion { get; set; }
    }
}