using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class Beneficio
    {
        public int IdBeneficio { get; set; }
        public string Nome { get; set; }
        public int IdOperadora { get; set; }
        public DateTimeOffset DataInclusao { get; set; }


        public Operadora Operadora { get; set; }
        public List<ClienteBeneficio> ClienteBeneficios { get; set; }
    }
}
