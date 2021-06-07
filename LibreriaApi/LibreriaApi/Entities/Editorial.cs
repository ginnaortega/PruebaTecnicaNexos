using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaApi.Entities
{
    public class Editorial
    {
        /// <summary>
        /// Nombre de la editorial.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Dirección de Correspondencia.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Teléfono editorial.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Email editorial.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Tope máximo permitido de libros registrados.
        /// </summary>
        public long MaximoLibrosRegistrados { get; set; }
    }
}