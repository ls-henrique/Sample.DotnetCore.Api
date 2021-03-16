using System.Threading.Tasks;

namespace Sample.Carros.Infra.Comum
{
    public interface ICommandHandler<T> where T : ICommandPadrao
    {
        Task<ICommandResult> Handle(T command);
    }
}
