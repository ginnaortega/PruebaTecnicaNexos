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
    public class AutorController : ApiController
    {
        /// <summary>
        /// Instancia de la interfaz de repositorio de autori.
        /// </summary>
        readonly IRepositorioAutor _repositorioAutor;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositorioAutor"></param>
        public AutorController(IRepositorioAutor repositorioAutor)
        {
            _repositorioAutor = repositorioAutor;
        }

        [HttpPost]
        [ActionName("GuardarAutor")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> GuardarAutor([FromBody] Autor autor)

        {
            if (_repositorioAutor != null)
            {
                bool respuesta = await _repositorioAutor.RegistrarAutor(autor);
                return Ok(respuesta);
            }
            return InternalServerError();
        }

        [HttpGet]
        [ActionName("ConsultarAutorPorIdentificador")]
        [ResponseType(typeof(Autor))]
        public async Task<IHttpActionResult> ConsultarAutorPorIdentificador([FromUri] int idAutor)
        {
            if (_repositorioAutor != null)
            {
                Autor respuesta = await _repositorioAutor.ObtenerAutorPorIdentificador(idAutor);
                return Ok(respuesta);
            }

            return InternalServerError();
        }

        [HttpGet]
        [ActionName("ConsultarAutores")]
        [ResponseType(typeof(IList<DatosBasicosEntidad>))]
        public async Task<IHttpActionResult> ConsultarAutores()
        {
            if (_repositorioAutor != null)
            {
                IList<DatosBasicosEntidad> respuesta = await _repositorioAutor.ObtenerAutores();
                return Ok(respuesta);
            }

            return InternalServerError();
        }
    }
}
