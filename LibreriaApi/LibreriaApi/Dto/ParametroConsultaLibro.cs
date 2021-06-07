using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaApi.Dto
{
    public class ParametroConsultaLibro
    {
        /// <summary>
        /// Título del libro.
        /// </summary>
        public string TituloLibro { get; set; }

        /// <summary>
        /// Nombre del autor del libro.
        /// </summary>
        public string NombreAutor { get; set; }

        /// <summary>
        /// Anio de publicación.
        /// </summary>
        public int Anio { get; set; }
    }
}