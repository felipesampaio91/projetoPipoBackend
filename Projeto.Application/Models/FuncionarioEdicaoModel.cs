using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models
{
    public class FuncionarioEdicaoModel
    {
        [RegularExpression("^[0-9]{1,9}$", ErrorMessage = "Por favor, informe um ID válido")]
        [Required(ErrorMessage = "Informe o ID do funcionário.")]
        public int IdFuncionario { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres")]
        [MaxLength(60, ErrorMessage = "Informe no máximo {1} caracteres")]
        [Required(ErrorMessage = "Informe o nome do funcionário.")]
        public string Nome { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Por favor, informe um CPF válido")]
        [Required(ErrorMessage = "Informe o CPF do funcionário.")]
        public string Cpf { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres")]
        [MaxLength(8, ErrorMessage = "Informe no máximo {1} caracteres")]
        //[Required(ErrorMessage = "Informe a data de admissão do funcionário.")]
        public string DataAdmissao { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres")]
        [MaxLength(60, ErrorMessage = "Informe no máximo {1} caracteres")]
        //[Required(ErrorMessage = "Informe o endereço do funcionário.")]
        public string Endereco { get; set; }

        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres")]
        [MaxLength(60, ErrorMessage = "Informe no máximo {1} caracteres")]
        public string Email { get; set; }

        //[RegularExpression("^[0-9.,]{3,5}$", ErrorMessage = "Por favor, informe um peso válido")]
        public decimal? Peso { get; set; }

        //[RegularExpression("^[0-9.,]{3,4}$", ErrorMessage = "Por favor, informe uma altura válida")]
        public decimal? Altura { get; set; }
        public decimal? HorasMeditadas { get; set; }

        [RegularExpression("^[0-9]{1,9}$", ErrorMessage = "Por favor, informe um ID válido")]
        [Required(ErrorMessage = "Informe o ID do cliente.")]
        public int IdCliente { get; set; }
    }
}
