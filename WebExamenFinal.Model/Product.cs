using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebExamenFinal.Model
{

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido.")]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int SupplierId { get; set; }

        public decimal? UnitPrice { get; set; }

        [StringLength(30)]
        public string Package { get; set; }

        public bool IsDiscontinued { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItem { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
