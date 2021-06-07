using LibreriaApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaApi.Interfaces
{
    public interface IRegistroLibro
    {
        /// <summary>
        /// Realiza el proceso de validación para el registro del libro.
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        Task<ResultadoRegistro> ProcesarRegistoLibro(Entities.Libro libro);
    }
}
