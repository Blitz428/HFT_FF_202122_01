using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId {  get; set; }

        [Required]
        public string BrandName {  get; set; }

        [NotMapped]
        public virtual ICollection<Product> Products {  get; set; }

        public Brand()
        {
            Products= new HashSet<Product>();
        }

    }
}
