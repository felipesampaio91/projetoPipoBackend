using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class ClienteBeneficio
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdBeneficio { get; set; }
        public Cliente Cliente { get; set; }
        public Beneficio Beneficio { get; set; }
        public DateTimeOffset DataInclusao { get; set; }
    }
}
