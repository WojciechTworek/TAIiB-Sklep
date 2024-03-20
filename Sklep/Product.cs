using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sklep
{
    public class Product:IEntityTypeConfiguration<Product>
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        public double Price { get; set; }
        [MaxLength(50)]
        public string Image { get; set; }
        public bool IsActive { get; set; }

        public OrderPosition OrderPosition { get; set; }

        public required IEnumerable<BasketPosition> BasketPositions { get; set;}

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                 .HasMany(x => x.BasketPositions)
                 .WithOne(x => x.Product)
                 .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(x => x.OrderPosition)
                .WithMany(x => x.Products)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
