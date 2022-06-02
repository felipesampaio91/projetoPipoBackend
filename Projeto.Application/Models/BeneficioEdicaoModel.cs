using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models
{
    public class BeneficioEdicaoModel
    {
        [RegularExpression("^[0-9]{1,9}$", ErrorMessage = "Por favor, informe um ID válido")]
        [Required(ErrorMessage = "Informe o ID do benefício.")]
        public int IdBeneficio { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres")]
        [MaxLength(60, ErrorMessage = "Informe no máximo {1} caracteres")]
        [Required(ErrorMessage = "Informe o nome do cliente.")]
        public string Nome { get; set; }
    }
}
