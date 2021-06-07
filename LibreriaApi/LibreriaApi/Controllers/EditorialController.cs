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
    public class EditorialController : ApiController
    {
        /// <summary>
        /// Instancia de la interfaz de repositorio editorial.
        /// </summary>
        readonly IRepositorioEditorial _repositorioEditorial;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositorioEditorial"></param>
        public EditorialController(IRepositorioEditorial repositorioEditorial)
        {
            _repositorioEditorial = repositorioEditorial;
        }

        [HttpPost]
        [ActionName("GuardarEditorial")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> GuardarEditorial([FromBody] Editorial editorial)
        {
            if (_repositorioEditorial != null)
            {
                bool respuesta = await _repositorioEditorial.RegistrarEditorial(editorial);
                return Ok(respuesta);
            }
            return InternalServerError();
        }

        [HttpGet]
        [ActionName("ConsultarEditorialPorIdentificador")]
        [ResponseType(typeof(Editorial))]
        public async Task<IHttpActionResult> ConsultarEditorialPorIdentificador([FromUri] int idEditorial)
        {
            if (_repositorioEditorial != null)
            {
                Editorial respuesta = await _repositorioEditorial.ObtenerEditorialPorIdentificador(idEditorial);
                return Ok(respuesta);
            }

            return InternalServerError();
        }

        [HttpGet]
        [ActionName("ConsultarEditoriales")]
        [ResponseType(typeof(IList<DatosBasicosEntidad>))]
        public async Task<IHttpActionResult> ConsultarEditoriales()
        {
            if (_repositorioEditorial != null)
            {
                IList<DatosBasicosEntidad> respuesta = await _repositorioEditorial.ObtenerEditoriales();
                return Ok(respuesta);
            }

            return InternalServerError();
        }
    }
}
