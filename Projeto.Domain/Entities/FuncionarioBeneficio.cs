using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class FuncionarioBeneficio
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public int IdBeneficio { get; set; }
        public Funcionario Funcionario { get; set; }
        public Beneficio Beneficio { get; set; }
        public DateTimeOffset DataInclusao { get; set; }
    }
}
