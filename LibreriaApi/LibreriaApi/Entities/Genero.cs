using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaApi.Entities
{
    public class Genero
    {
        /// <summary>
        /// Identificador del género.
        /// </summary>
        public int IdGenero { get; set; }

        /// <summary>
        /// Descripción del género literario.
        /// </summary>
        public string Descripcion { get; set; }
    }
}