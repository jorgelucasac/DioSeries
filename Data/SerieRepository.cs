using System.Collections.Generic;
using System.Linq;
using Estudos.Dio.AppSeries.Dominio;

namespace Estudos.Dio.AppSeries.Data
{
    public class SerieRepository : Repository<Serie>, ISerieRepository
    {
        public List<Serie> BuscarPorTitulo(string titulo)
        {
            return Buscar(a => a.Titulo.Contains(titulo)).ToList();
        }

        public List<Serie> BuscarPorCategoria(Categoria categoria)
        {
            return Buscar(a => a.Categoria == categoria).ToList();
        }
    }


    public interface ISerieRepository : IRepository<Serie>
    {
        List<Serie> BuscarPorTitulo(string titulo);
        List<Serie> BuscarPorCategoria(Categoria categoria);
    }
}