using LibreriaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Interfaces
{
    /// <summary>
    /// Operaciones para obtención de datos de la entidad de género.
    /// </summary>
    public interface IRepositorioGenero
    {
        /// <summary>
        /// Consulta los generos almacenados.
        /// </summary>
        /// <returns></returns>
        Task<IList<Genero>> ObtenerGeneros();

        /// <summary>
        /// Realiza el registro de los géneros.
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        Task<bool> RegistrarGenero(Genero genero);

        /// <summary>
        /// Obtiene el genero por id.
        /// </summary>
        /// <returns></returns>
        Task<Genero> ObtenerGeneroPorIdentificador(int idGenero);
    }
}
