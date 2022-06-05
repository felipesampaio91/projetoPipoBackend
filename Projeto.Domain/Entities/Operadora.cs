using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class Operadora
    {
        public int IdOperadora { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTimeOffset DataInclusao { get; set; }

        public List<Beneficio> Beneficios { get; set; }
    }
}
