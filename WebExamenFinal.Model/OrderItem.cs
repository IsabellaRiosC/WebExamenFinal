using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebExamenFinal.Model
{

    [Table("OrderItem")]
    public partial class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
