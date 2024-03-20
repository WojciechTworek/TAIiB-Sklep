using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sklep
{
    public class BasketPosition:IEntityTypeConfiguration<BasketPosition>
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        public int ProductId {  get; set; }

        [ForeignKey(nameof(ProductId))]
        [Required]
        public Product Product { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [Required]
        public User User { get; set;}
        public int Amount { get; set; }

        public void Configure(EntityTypeBuilder<BasketPosition> builder)
        {
            builder
                 .HasOne(x => x.User)
                 .WithMany(x => x.BasketPositions)
                 .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.BasketPositions)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
