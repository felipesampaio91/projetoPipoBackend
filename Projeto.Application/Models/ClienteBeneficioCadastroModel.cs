﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models
{
    public class ClienteBeneficioCadastroModel
    {
        [RegularExpression("^[0-9]{1,9}$", ErrorMessage = "Por favor, informe um ID válido")]
        [Required(ErrorMessage = "Informe o ID do cliente.")]
        public int IdCliente { get; set; }

        [RegularExpression("^[0-9]{1,9}$", ErrorMessage = "Por favor, informe um ID válido")]
        [Required(ErrorMessage = "Informe o ID do benefício.")]
        public int IdBeneficio { get; set; }

        [Required(ErrorMessage = "Informe a data de inclusão do cliente-benefício.")]
        public DateTimeOffset DataInclusao { get; set; }

    }
}
