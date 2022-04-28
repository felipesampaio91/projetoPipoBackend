using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Models
{
    public class OperadoraConsultaModel
    {
        public int IdOperadora { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTimeOffset DataInclusao { get; set; }

    }
}
