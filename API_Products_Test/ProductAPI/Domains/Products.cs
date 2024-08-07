using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Domains
{
    [Table(nameof(Products))]
    public class Products
    {
        [Key]
        public Guid IdProduct { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

    }
}
