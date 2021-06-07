using LibreriaApi.Dto;
using LibreriaApi.Entities;
using LibreriaApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LibreriaApi.Controllers
{
    public class LibroController : ApiController
    {
        /// <summary>
        /// Instancia de la interfaz de repositorio libro.
        /// </summary>
        readonly IRepositorioLibro _repositorioLibro;

        /// <summary>
        /// Instancia de la interfaz de registro libro.
        /// </summary>
        readonly IRegistroLibro _registroLibro;

        /// <summary>
        /// Constructor.
        /// </summary>
        public LibroController(IRepositorioLibro repositorioLibro, IRegistroLibro registroLibro)
        {
            _repositorioLibro = repositorioLibro;
            _registroLibro = registroLibro;
        }

        [HttpPost]
        [ActionName("GuardarLibro")]
        [ResponseType(typeof(ResultadoRegistro))]
        public async Task<IHttpActionResult> GuardarLibro([FromBody] Libro libro)
        {
            if (_registroLibro != null)
            {
                ResultadoRegistro respuesta = await _registroLibro.ProcesarRegistoLibro(libro);
                return Ok(respuesta);
            }
            return InternalServerError();
        }

        [HttpGet]
        [ActionName("ConsultarLibros")]
        [ResponseType(typeof(IList<ResultadoLibro>))]
        public async Task<IHttpActionResult> ConsultarLibros()
        {
            if (_repositorioLibro != null)
            {
                IList<ResultadoLibro> respuesta = await _repositorioLibro.ObtenerLibros();
                return Ok(respuesta);
            }

            return InternalServerError();
        }
    }
}
