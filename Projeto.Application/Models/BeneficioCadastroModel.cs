using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models
{
    public class BeneficioCadastroModel
    {
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres")]
        [MaxLength(60, ErrorMessage = "Informe no máximo {1} caracteres")]
        [Required(ErrorMessage = "Informe o nome do benefício.")]
        public string Nome { get; set; }

        [RegularExpression("^[0-9]{1,9}$", ErrorMessage = "Por favor, informe um ID válido")]
        [Required(ErrorMessage = "Informe o ID do cliente.")]
        public int IdOperadora { get; set; }

        [Required(ErrorMessage = "Informe a data de inclusão do benefício.")]
        public DateTimeOffset DataInclusao { get; set; }
    }
}
