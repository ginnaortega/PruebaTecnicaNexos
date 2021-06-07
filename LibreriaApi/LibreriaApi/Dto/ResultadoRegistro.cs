using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaApi.Dto
{
    public class ResultadoRegistro
    {
        /// <summary>
        /// Confirmación de registro.
        /// </summary>
        public bool ConfirmacionRegistro { get; set; }
        /// <summary>
        /// Mensaje de respuesta.
        /// </summary>
        public string Respuesta { get; set; }
    }
}