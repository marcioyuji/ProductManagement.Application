using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Core.Entities
{
    [Table("TB_PRODUCT")]
    public class Product
    {
        [Column("PRODUCT_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("PRODUCT_NAME")]
        public string Name { get; set; }

        [Column("PRODUCT_DESCRIPTION")]
        public string Description { get; set; }

        [Column("PRODUCT_PRICE", TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Column("PRODUCT_SITUATION")]
        public bool Situation { get; set; } = true;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
