using Dapper;
using Sample.Carros.Dominio.QueryResults;
using Sample.Carros.Dominio.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Carros.Infra.Data
{
    public class CarrosRepositorio : ICarrosRepositorio
    {
        private readonly DataContext context;

        public CarrosRepositorio(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<CarroQueryResult> GetAll()
        {
            return this.context.Connection.Query<CarroQueryResult>("Select * from Carros");
        }

        public CarroQueryResult GetById(int id)
        {
            return this.context.Connection.QueryFirstOrDefault<CarroQueryResult>("Select * from Carros Where Id = @Id ", new { id });
        }

        public async Task AddAsync(Dominio.Entidades.Carros carros)
        {
            await this.context.Connection.ExecuteAsync("INSERT INTO CARROS VALUES (@Id, @Nome, @Ano, @Tipo, @Fabricante, @Preco, @Blindado)", carros);
        }

        public async Task UpdateAsync(Dominio.Entidades.Carros carros)
        {
            await this.context.Connection.ExecuteAsync("UPDATE CARROS SET Nome = @Nome, Ano = @Ano, Tipo = @Tipo, Fabricante = @Fabricante, Preco = @Preco, Blindado = @Blindado", carros);
        }

        public async Task DeleteAsync(int id)
        {
            await this.context.Connection.ExecuteAsync("DELETE CARROS WHERE Id = @Id", id);
        }
    }
}
