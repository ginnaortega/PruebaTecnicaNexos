using LibreriaApi.Dto;
using LibreriaApi.Entities;
using LibreriaApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LibreriaApi.Business
{
    public class RegistroLibro : IRegistroLibro
    {
        readonly IRepositorioLibro _repositorioLibro;
        readonly IRepositorioAutor _repositorioAutor;
        readonly IRepositorioEditorial _repositorioEditorial;
        readonly IRepositorioGenero _repositorioGenero;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RegistroLibro(IRepositorioLibro repositorioLibro, IRepositorioAutor repositorioAutor, IRepositorioEditorial repositorioEditorial,
                             IRepositorioGenero repositorioGenero)
        {
            _repositorioLibro = repositorioLibro;
            _repositorioAutor = repositorioAutor;
            _repositorioEditorial = repositorioEditorial;
            _repositorioGenero = repositorioGenero;
        }

        /// <summary>
        /// Realiza la validación de reglas de negocio antes de registrar el libro.
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        public async Task<ResultadoRegistro> ProcesarRegistoLibro(Libro libro)
        {
            if (libro == null)
            {
                return await Task.FromResult(new ResultadoRegistro { ConfirmacionRegistro = false, Respuesta = Resources.Mensajes.MensajeSinInformacionParametros });
            }

            Autor autor = await _repositorioAutor.ObtenerAutorPorIdentificador(libro.IdAutor);
            if (autor == null || string.IsNullOrEmpty(autor.Nombre))
            {
                return await Task.FromResult(new ResultadoRegistro { ConfirmacionRegistro = false, Respuesta = Resources.Mensajes.MensajeAutorNoRegistrado });
            }

            Editorial editorial = await _repositorioEditorial.ObtenerEditorialPorIdentificador(libro.IdEditorial);
            if (editorial == null || string.IsNullOrEmpty(editorial.Nombre))
            {
                return await Task.FromResult(new ResultadoRegistro { ConfirmacionRegistro = false, Respuesta = Resources.Mensajes.MensajeEditorialNoRegistrada });
            }

            Genero genero = await _repositorioGenero.ObtenerGeneroPorIdentificador(libro.IdGenero);
            if (genero == null || string.IsNullOrEmpty(genero.Descripcion))
            {
                return await Task.FromResult(new ResultadoRegistro { ConfirmacionRegistro = false, Respuesta = Resources.Mensajes.MensajeGeneroNoRegistrado });
            }

            if (!PermiteRegistroLibroPorEditorial(editorial.MaximoLibrosRegistrados, libro.IdEditorial))
            {
                return await Task.FromResult(new ResultadoRegistro { ConfirmacionRegistro = false, Respuesta = Resources.Mensajes.MensajeMaximoLibrosPermitidos });
            }
            
            return await Task.FromResult(await _repositorioLibro.RegistrarLibro(libro));
        }

        /// <summary>
        /// Valida el máximo permitido de registro de libros por editorial.
        /// </summary>
        /// <param name="maximoLibroEditorial"></param>
        /// <param name="idEditorial"></param>
        /// <returns></returns>
        private bool PermiteRegistroLibroPorEditorial(long maximoLibroEditorial, int idEditorial)
        {
            bool retorno = false;
            int cantidadLibrosEditorial = _repositorioLibro.CantidadLibrosPorEditorial(idEditorial);

            if (cantidadLibrosEditorial <= maximoLibroEditorial)
            {
                retorno = true;
            }

            return retorno;
        }
    }
}