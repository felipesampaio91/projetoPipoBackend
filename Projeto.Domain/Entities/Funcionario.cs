using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class Funcionario
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public string? Endereco { get; set; }
        public string? Email { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Altura { get; set; }
        public decimal? HorasMeditadas { get; set; }
        public DateTimeOffset DataInclusao { get; set; }
        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }
    }
}
