using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sklep
{
    public class Order:IEntityTypeConfiguration<Order>
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [Required]
        public User User {  get; set; }

        public DateTime Date { get; set; }

        public required IEnumerable<OrderPosition> OrderPositions { get; set; }

        

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                 .HasOne(x => x.User)
                 .WithMany(x => x.Orders)
                 .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(x => x.OrderPositions)
                .WithOne(x => x.Order)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
