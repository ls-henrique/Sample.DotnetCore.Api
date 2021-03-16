using Sample.Carros.Dominio.Commands;
using Sample.Carros.Dominio.Commands.Output;
using Sample.Carros.Dominio.Repositorios;
using Sample.Carros.Infra.Comum;
using System.Threading.Tasks;

namespace Sample.Carros.Dominio.Handlers
{
    public class CarrosHandler : ICommandHandler<AdicionarCarroCommand>, ICommandHandler<AtualizarCarroCommand>
    {
        private readonly ICarrosRepositorio carrosRepositorio;

        public CarrosHandler(ICarrosRepositorio carrosRepositorio)
        {
            this.carrosRepositorio = carrosRepositorio;
        }

        public async Task<ICommandResult> Handle(AdicionarCarroCommand command)
        {
            var valido = command.EhValido();
            if (!valido)
            {
                return new CarrosCommandResult(false, "Ocorreu um erro ao inserir os dados", command.Notifications);
            }

            var newCarros = new Entidades.Carros(
                command.Id,
                command.Nome,
                command.Ano,
                command.Tipo,
                command.Fabricante,
                command.Preco,
                command.Blindado
                );

            await this.carrosRepositorio.AddAsync(newCarros);

            return new CarrosCommandResult(true, "sucesso", null);
        }

        public async Task<ICommandResult> Handle(AtualizarCarroCommand command)
        {
            var valido = command.EhValido();
            if (!valido)
            {
                return new CarrosCommandResult(false, "Ocorreu um erro ao inserir os dados", command.Notifications);
            }

            var newCarros = new Entidades.Carros(
                command.Id,
                command.Nome,
                command.Ano,
                command.Tipo,
                command.Fabricante,
                command.Preco,
                command.Blindado
                );

            await this.carrosRepositorio.UpdateAsync(newCarros);

            return new CarrosCommandResult(true, "sucesso", null);
        }
    }
}