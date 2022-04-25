using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string  Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTimeOffset DataInclusao { get; set; }


        public List<Funcionario> Funcionarios { get; set; }
        public List<ClienteBeneficio> ClienteBeneficios { get; set; }

    }
}
