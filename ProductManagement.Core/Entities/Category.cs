using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Core.Entities
{
    [Table("TB_CATEGORY")]
    public class Category
    {
        [Column("CATEGORY_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("CATEGORY_NAME")]
        public string Name { get; set; }

        [Column("CATEGORY_SITUATION")]
        public bool Situation { get; set; } = true;
    }
}
