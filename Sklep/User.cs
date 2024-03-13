using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sklep
{
    public enum Type
    {
        Admin,
        Casual
    }
    public class User : IEntityTypeConfiguration<User>
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Login { get; set; }
        [Required, MaxLength(20)]
        public string Password { get; set; }

        public Type Type { get; set;}

        public bool IsActived { get; set; }

        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<BasketPosition> BasketPositions { get; set; }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                 .HasMany(x => x.BasketPositions)
                 .WithOne(x => x.User)
                 .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
