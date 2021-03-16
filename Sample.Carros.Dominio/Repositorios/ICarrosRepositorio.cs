using Sample.Carros.Dominio.QueryResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Carros.Dominio.Repositorios
{
    public interface ICarrosRepositorio
    {
        IEnumerable<CarroQueryResult> GetAll();

        CarroQueryResult GetById(int id);

        Task AddAsync(Entidades.Carros carros);

        Task UpdateAsync(Entidades.Carros carros);

        Task DeleteAsync(int id);
    }
}
