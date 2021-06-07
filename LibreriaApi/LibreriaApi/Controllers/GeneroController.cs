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
    public class GeneroController : ApiController
    {
        /// <summary>
        /// Instancia de la interfaz de repositorio genero.
        /// </summary>
        readonly IRepositorioGenero _repositorioGenero;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositorioGenero"></param>
        public GeneroController(IRepositorioGenero repositorioGenero)
        {
            _repositorioGenero = repositorioGenero;
        }

        [HttpGet]
        [ActionName("ConsultarGenero")]
        [ResponseType(typeof(IList<Genero>))]
        public async Task<IHttpActionResult> ConsultarGenero()
        {
            if (_repositorioGenero != null)
            {
                IList<Entities.Genero> respuesta = await _repositorioGenero.ObtenerGeneros();
                return Ok(respuesta);
            }

            return InternalServerError();
        }

        [HttpPost]
        [ActionName("GuardarGenero")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> GuardarGenero([FromBody] Genero genero)
        
        {
            if (_repositorioGenero != null)
            {
                bool respuesta = await _repositorioGenero.RegistrarGenero(genero);
                return Ok(respuesta);
            }
            return InternalServerError();
        }

        [HttpGet]
        [ActionName("ConsultarGeneroPorIdentificador")]
        [ResponseType(typeof(Genero))]
        public async Task<IHttpActionResult> ConsultarGeneroPorIdentificador([FromUri] int idGenero)
        {
            if (_repositorioGenero != null)
            {
                Genero respuesta = await _repositorioGenero.ObtenerGeneroPorIdentificador(idGenero);
                return Ok(respuesta);
            }

            return InternalServerError();
        }
    }
}
