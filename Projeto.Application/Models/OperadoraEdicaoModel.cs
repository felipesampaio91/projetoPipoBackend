using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models
{
    public class OperadoraEdicaoModel
    {
        [RegularExpression("^[0-9]{1,9}$", ErrorMessage = "Por favor, informe um ID válido")]
        [Required(ErrorMessage = "Informe o ID do fornecedor")]
        public int IdOperadora { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres")]
        [Required(ErrorMessage = "Informe o nome da operadora.")]
        public string Nome { get; set; }

        [RegularExpression("^[0-9]{14}$", ErrorMessage = "Por favor, informe um CNPJ válido")]
        [Required(ErrorMessage = "Informe o CNPJ da operadora.")]
        public string Cnpj { get; set; }
    }
}
