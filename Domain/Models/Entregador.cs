﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Entregador")]
    public class Entregador : Entity
    {
        [Key]
        public Guid IdEntregador { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }

        public Guid ClienteId { get; set; }
        [ForeignKey("EnderecoId")]
        public virtual Clientes Clientes { get; set; }
    }
}
