using Flunt.Notifications;
using Flunt.Validations;
using Sample.Carros.Infra.Comum;

namespace Sample.Carros.Dominio.Commands
{
    public class AdicionarCarroCommand : Notifiable, ICommandPadrao
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Ano { get; set; }

        public string Tipo { get; set; }

        public string Fabricante { get; set; }

        public decimal Preco { get; set; }

        public bool Blindado { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract()
               .IsNotNullOrEmpty(Nome, "Nome", "Nome é obrigatório")
            );

            return Valid;
        }
    }
}
