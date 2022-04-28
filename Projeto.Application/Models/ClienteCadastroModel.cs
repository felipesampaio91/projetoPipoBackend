﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models
{
    public class ClienteCadastroModel
    {
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres")]
        [MaxLength(60, ErrorMessage = "Informe no máximo {1} caracteres")]
        [Required(ErrorMessage = "Informe o nome do cliente.")]
        public string Nome { get; set; }

        [RegularExpression("^[0-9]{14}$", ErrorMessage = "Por favor, informe um CNPJ válido")]
        [Required(ErrorMessage = "Informe o CNPJ do cliente.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Informe a data de inclusão do cliente.")]
        public DateTimeOffset DataInclusao { get; set; }
    }
}
