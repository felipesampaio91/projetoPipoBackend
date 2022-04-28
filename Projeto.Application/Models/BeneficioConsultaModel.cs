using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Models
{
    public class BeneficioConsultaModel
    {
        public int IdBeneficio { get; set; }
        public string Nome { get; set; }
        public int IdOperadora { get; set; }
        public DateTimeOffset DataInclusao { get; set; }

        public OperadoraConsultaModel Operadora { get; set; }

    }
}
