using LibreriaApi.Dto;
using LibreriaApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LibreriaApi.Repository
{
    public class RepositorioLibro : IRepositorioLibro
    {
        private readonly LibreriaEntities dbContext = new LibreriaEntities();

        /// <summary>
        /// Constructor.
        /// </summary>
        public RepositorioLibro()
        {

        }

        /// <summary>
        /// Realiza la consulta de la cantidad de los libros registrados por editorial.
        /// </summary>
        /// <param name="idEditorial"></param>
        /// <returns></returns>
        public int CantidadLibrosPorEditorial(int idEditorial)
        {
            var resultado = dbContext.Libroes.Where(libro => libro.IdEditorial.Equals(idEditorial)).ToList();

            if (resultado == null)
            {
                return 0;
            }

            int cantidadLibros = resultado.Count();

            return cantidadLibros;
        }

        /// <summary>
        /// Realiza la consulta de los libros.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<ResultadoLibro>> ObtenerLibros()
        {
            IList<ResultadoLibro> libros = new List<ResultadoLibro>();

            using (LibreriaEntities libreria = new LibreriaEntities())
            {
                var query = from libro in libreria.Libroes
                            join genero in libreria.Generoes on libro.IdGenero equals genero.IdGenero
                            join autor in libreria.Autors on libro.IdAutor equals autor.IdAutor
                            join editorial in libreria.Editorials on libro.IdEditorial equals editorial.IdEditorial
                            select new ResultadoLibro
                            {
                                IdLibro = libro.IdLibro,
                                Titulo = libro.Titulo,
                                Anio = libro.Anio,
                                NumeroPaginas = libro.NumeroPaginas,
                                IdGenero = libro.IdGenero,
                                DescripcionGenero = genero.Descripcion,
                                IdAutor = libro.IdAutor,
                                NombreAutor = autor.Nombre,
                                IdEditorial = libro.IdEditorial,
                                NombreEditorial = editorial.Nombre
                            };

                libros = query.ToList();

            }
            return await Task.FromResult(libros);
        }

        /// <summary>
        /// Realiza el registro del libro.
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        public Task<ResultadoRegistro> RegistrarLibro(Entities.Libro libro)
        {
            Libro entidad = new Libro
            {
                Titulo = libro.Titulo,
                Anio = libro.Anio,
                IdGenero = libro.IdGenero,
                NumeroPaginas = libro.NumeroPaginas,
                IdEditorial = libro.IdEditorial,
                IdAutor = libro.IdAutor
            };

            dbContext.Libroes.Add(entidad);
            dbContext.SaveChanges();

            ResultadoRegistro resultado = new ResultadoRegistro
            {
                ConfirmacionRegistro = true,
                Respuesta = Resources.Mensajes.MensajeRegistroExitoso
            };
            return Task.FromResult(resultado);
        }
    }
}