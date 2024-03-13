using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sklep
{
    public class OrderPosition:IEntityTypeConfiguration<OrderPosition>
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        public int Amount { get; set; }
        public double? Price {  get; set; }

        public void Configure(EntityTypeBuilder<OrderPosition> builder)
        {
            builder
                 .HasOne(x => x.Order)
                 .WithMany(x => x.OrderPositions)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
