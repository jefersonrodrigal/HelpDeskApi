using HelpDeskApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDeskApi.DataMapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasColumnName("Nome")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(80);

            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasColumnName("Sobrenome")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(80);

            builder.Property(x => x.Email);
            builder.Property(x => x.PasswordHash);

            builder.HasOne(x => x.Role)
                   .WithMany(x => x.Users);

            builder.HasIndex(x => x.Email)
                   .IsUnique();
        }
    }
}
