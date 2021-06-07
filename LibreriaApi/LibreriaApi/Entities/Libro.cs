using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaApi.Entities
{
    public class Libro
    {
        /// <summary>
        /// Identificador del libro.
        /// </summary>
        public int IdLibro { get; set; }

        /// <summary>
        /// Titulo del libro.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Año de publicación del libro.
        /// </summary>
        public int Anio { get; set; }

        /// <summary>
        /// Identificador del genero asociado al libro.
        /// </summary>
        public int IdGenero { get; set; }

        /// <summary>
        /// Número de páginas del libro.
        /// </summary>
        public long NumeroPaginas { get; set; } 

        /// <summary>
        /// Identificador de la editorial.
        /// </summary>
        public int IdEditorial { get; set; }

        /// <summary>
        /// Identificador del autor.
        /// </summary>
        public int IdAutor { get; set; }
    }
}