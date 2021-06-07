using LibreriaApi.Dto;
using LibreriaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Interfaces
{
    public interface IRepositorioAutor
    {

        /// <summary>
        /// Realiza el registro del autor.
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        Task<bool> RegistrarAutor(Autor autor);

        /// <summary>
        /// Obtiene los autores almacenados.
        /// </summary>
        /// <returns></returns>
        Task<IList<DatosBasicosEntidad>> ObtenerAutores();

        /// <summary>
        /// Obtiene el autor por id.
        /// </summary>
        /// <returns></returns>
        Task<Autor> ObtenerAutorPorIdentificador(int idAutor);
    }
}
