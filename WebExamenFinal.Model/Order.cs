using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebExamenFinal.Model
{


    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        [StringLength(10)]
        public string OrderNumber { get; set; }

        public int CustomerId { get; set; }

        public decimal? TotalAmount { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
