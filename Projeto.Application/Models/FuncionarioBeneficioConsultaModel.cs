using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Models
{
    public class FuncionarioBeneficioConsultaModel
    {
        public int IdFuncionarioBeneficio { get; set; }
        public int IdFuncionario { get; set; }
        public int IdBeneficio { get; set; }
        public DateTimeOffset DataInclusao { get; set; }
    }
}
