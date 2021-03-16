namespace Sample.Carros.Dominio.Entidades
{
    public class Carros
    {
        public Carros(int id, string nome, int ano, string tipo, string fabricante, decimal preco, bool blindado)
        {
            Id = id;
            Nome = nome;
            Ano = ano;
            Tipo = tipo;
            Fabricante = fabricante;
            Preco = preco;
            Blindado = blindado;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Tipo { get; set; }
        public string Fabricante { get; set; }
        public decimal Preco { get; set; }
        public bool Blindado { get; set; }
    }
}
