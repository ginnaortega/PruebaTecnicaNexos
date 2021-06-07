using LibreriaApi.Dto;
using LibreriaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Interfaces
{
    public interface IRepositorioEditorial
    {
        /// <summary>
        /// Realiza el registro de la editorial.
        /// </summary>
        /// <param name="editorial"></param>
        /// <returns></returns>
        Task<bool> RegistrarEditorial(Editorial editorial);

        /// <summary>
        /// Obtiene las editoriales almacenadass.
        /// </summary>
        /// <returns></returns>
        Task<IList<DatosBasicosEntidad>> ObtenerEditoriales();

        /// <summary>
        /// Obtiene la editorial por id.
        /// </summary>
        /// <returns></returns>
        Task<Editorial> ObtenerEditorialPorIdentificador(int idEditorial);
    }
}
