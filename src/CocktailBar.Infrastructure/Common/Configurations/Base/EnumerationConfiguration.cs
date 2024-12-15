using CocktailBar.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailBar.Infrastructure.Common.Configurations.Base;

public class EnumerationConfiguration<T> : IEntityTypeConfiguration<T> where T : Enumeration
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.ToTable(typeof(T).Name);
    }
}
