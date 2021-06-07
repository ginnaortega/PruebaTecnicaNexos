using LibreriaApi.Dto;
using LibreriaApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LibreriaApi.Repository
{
    public class RepositorioEditorial : IRepositorioEditorial
    {
        private readonly LibreriaEntities dbContext = new LibreriaEntities();

        /// <summary>
        /// Constructor.
        /// </summary>
        public RepositorioEditorial()
        {

        }

        /// <summary>
        /// Realiza la consulta de la editorial por identificador.
        /// </summary>
        /// <param name="idEditorial"></param>
        /// <returns></returns>
        public async Task<Entities.Editorial> ObtenerEditorialPorIdentificador(int idEditorial)
        {
            var resultado = dbContext.Editorials.Find(idEditorial);
            
            if (resultado == null)
            {
                return null;
            }

            Entities.Editorial editorial = new Entities.Editorial
            {
                Nombre = resultado.Nombre,
                Direccion = resultado.DireccionCorrespondencia,
                Telefono = resultado.Telefono,
                Email = resultado.Email,
                MaximoLibrosRegistrados = resultado.MaximoLibros
            };
            return await Task.FromResult(editorial);
        }

        /// <summary>
        /// Realiza la consulta de editoriales almacenadas.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<DatosBasicosEntidad>> ObtenerEditoriales()
        {
            using (LibreriaEntities libreria = new LibreriaEntities())
            {
                var resultado = libreria.Editorials.ToList();

                List<DatosBasicosEntidad> editoriales = (from item in resultado
                                                         select new DatosBasicosEntidad
                                                         {
                                                             Identificador = item.IdEditorial,
                                                             Descripcion = item.Nombre
                                                         }).ToList();

                return await Task.FromResult(editoriales);
            }
        }

        /// <summary>
        /// Realiza el registro de la editorial.
        /// </summary>
        /// <param name="editorial"></param>
        /// <returns></returns>
        public Task<bool> RegistrarEditorial(Entities.Editorial editorial)
        {
            Editorial entidad = new Editorial
            {
                Nombre = editorial.Nombre,
                DireccionCorrespondencia = editorial.Direccion,
                Telefono = editorial.Telefono,
                Email = editorial.Email,
                MaximoLibros = editorial.MaximoLibrosRegistrados
            };

            dbContext.Editorials.Add(entidad);
            dbContext.SaveChanges();
            return Task.FromResult(true);
        }
    }
}