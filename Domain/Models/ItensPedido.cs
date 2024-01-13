using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("ItensPedido")]
    public class ItensPedido : Entity
    {
        [Key]
        public Guid IdItensPedido { get; set; }

        public Guid PedidoId { get; set; }

        public Guid ItensMenuId { get; set; }
        [ForeignKey("ItemMenuId")]
        public virtual ItensMenu ItemMenu { get; set; }

        public int Quantidade { get; set; }
    }
}
