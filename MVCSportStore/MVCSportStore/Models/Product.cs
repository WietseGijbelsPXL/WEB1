using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCSportStore.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public string? Category { get; set; }

        public Product()
        {

        }

        public Product(string[] data)
        {
            //name;description;category;price
            Name = data[0];
            Description = data[1];
            Category = data[2];
            Price = decimal.Parse(data[3]);

        }
    }
}
