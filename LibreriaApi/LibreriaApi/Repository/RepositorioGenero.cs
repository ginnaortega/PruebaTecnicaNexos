using LibreriaApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LibreriaApi.Repository
{
    public class RepositorioGenero : IRepositorioGenero
    {
        private readonly LibreriaEntities dbContext = new LibreriaEntities();

        /// <summary>
        /// Constructor.
        /// </summary>
        public RepositorioGenero()
        {

        }

        /// <summary>
        /// Obtiene el genero por el identificador.
        /// </summary>
        /// <param name="idGenero"></param>
        /// <returns></returns>
        public async Task<Entities.Genero> ObtenerGeneroPorIdentificador(int idGenero)
        {
            var resultado = dbContext.Generoes.Find(idGenero);

            if (resultado == null)
            {
                return null;
            }

            Entities.Genero genero = new Entities.Genero
            {
                Descripcion = resultado.Descripcion,
                IdGenero = resultado.IdGenero
            };
            return await Task.FromResult(genero);
        }

        /// <summary>
        /// Consulta los generos.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Entities.Genero>> ObtenerGeneros()
        {           

            using (LibreriaEntities libreria = new LibreriaEntities())
            {
                var resultado = libreria.Generoes.ToList();

                List<Entities.Genero> generos = (from item in resultado
                                        select new Entities.Genero
                                        {
                                            IdGenero = item.IdGenero,
                                            Descripcion = item.Descripcion
                                        }).ToList();
                
                return await Task.FromResult(generos);
            }
           
        }

        /// <summary>
        /// Realiza la inserción del registro en la tabla de Genero.
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        public Task<bool> RegistrarGenero(Entities.Genero genero)
        {
            Genero entidad = new Genero
            {
                Descripcion = genero.Descripcion
            };

            dbContext.Generoes.Add(entidad);
            dbContext.SaveChanges();
            return Task.FromResult(true);
        }
    }
}