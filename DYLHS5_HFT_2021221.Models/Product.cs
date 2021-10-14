using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        public int? BasePrice {  get; set; }

        [NotMapped]
        public virtual Brand Brand {  get; set; }

        public int BrandID { get; set; }

        [NotMapped]
        public virtual List<Order> Orders { get; set; }

        public Product()
        {
            Orders = new List<Order>();
        }
    }
}
