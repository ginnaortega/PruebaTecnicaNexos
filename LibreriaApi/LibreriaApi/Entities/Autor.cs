using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaApi.Entities
{
    public class Autor
    {
        /// <summary>   
        /// Nombre del autor.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Fecha de nacimiento del autor.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Ciudad de orígen del autor.
        /// </summary>
        public string CiudadProcedencia { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }
    }
}