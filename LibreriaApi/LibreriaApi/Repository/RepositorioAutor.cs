using LibreriaApi.Dto;
using LibreriaApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LibreriaApi.Repository
{
    public class RepositorioAutor : IRepositorioAutor
    {
        private readonly LibreriaEntities dbContext = new LibreriaEntities();

        /// <summary>
        /// Constructor.
        /// </summary>
        public RepositorioAutor()
        {

        }

        /// <summary>
        /// Realiza la consulta de los autores almacenados.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<DatosBasicosEntidad>> ObtenerAutores()
        {
            using (LibreriaEntities libreria = new LibreriaEntities())
            {
                var resultado = libreria.Autors.ToList();

                List<DatosBasicosEntidad> autores = (from item in resultado
                                                 select new DatosBasicosEntidad
                                                 {
                                                     Identificador = item.IdAutor,
                                                     Descripcion = item.Nombre
                                                 }).ToList();

                return await Task.FromResult(autores);
            }
        }

        /// <summary>
        /// Realiza la consulta del autor por el identificador.
        /// </summary>
        /// <param name="idAutor"></param>
        /// <returns></returns>
        public async Task<Entities.Autor> ObtenerAutorPorIdentificador(int idAutor)
        {
            var resultado = dbContext.Autors.Find(idAutor);

            if (resultado == null)
            {
                return null;
            }

            Entities.Autor autor = new Entities.Autor
            {
                Nombre = resultado.Nombre,
                FechaNacimiento = resultado.FechaNacimiento,
                CiudadProcedencia = resultado.CiudadProcedencia,
                Email = resultado.Email
            };
            return await Task.FromResult(autor);
        }

        /// <summary>
        /// Realiza la inserción del registro en la tabla de Autor.
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        public Task<bool> RegistrarAutor(Entities.Autor autor)
        {
            Autor entidad = new Autor
            {
                Nombre = autor.Nombre,
                FechaNacimiento = autor.FechaNacimiento,
                CiudadProcedencia = autor.CiudadProcedencia,
                Email = autor.Email
            };

            dbContext.Autors.Add(entidad);
            dbContext.SaveChanges();
            return Task.FromResult(true);
        }
    }
}