using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Models
{
    public class ClienteBeneficioConsultaModel
    {
        public int IdClienteBeneficio { get; set; }
        public int IdCliente { get; set; }
        public int IdBeneficio { get; set; }
        public DateTimeOffset DataInclusao { get; set; }
    }
}
