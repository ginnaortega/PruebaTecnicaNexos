using LibreriaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaApi.Dto
{
    public class ResultadoLibro : Libro
    {
        /// <summary>
        /// Descripción del genero del libro.
        /// </summary>
        public string DescripcionGenero { get; set; }

        /// <summary>
        /// Nombre del autori del libro.
        /// </summary>
        public string NombreAutor { get; set; }

        /// <summary>
        /// Nombre de la editorial del libro.
        /// </summary>
        public string NombreEditorial { get; set; }


    }
}