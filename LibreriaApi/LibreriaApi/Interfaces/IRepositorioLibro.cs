using LibreriaApi.Dto;
using LibreriaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Interfaces
{
    public interface IRepositorioLibro
    {
        /// <summary>
        /// Realiza el registro del libro.
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        Task<ResultadoRegistro> RegistrarLibro(Entities.Libro libro);

        /// <summary>
        /// Realiza la consulta de la cantidad de los libros registrados por editorial.
        /// </summary>
        /// <param name="idEditorial"></param>
        /// <returns></returns>
        int CantidadLibrosPorEditorial(int idEditorial);

        /// <summary>
        /// Consulta los libros almacenados.
        /// </summary>
        /// <returns></returns>
        Task<IList<ResultadoLibro>> ObtenerLibros();
    }
}
