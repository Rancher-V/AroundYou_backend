using AroudYou.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AroudYou.Persistence.EntityConfigurations
{
    public class ItemsConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(i => i.Id)
                .ValueGeneratedNever();       

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(i => i.City)
                .HasMaxLength(255);

            builder.Property(i => i.State)
                .HasMaxLength(255);

            builder.Property(i => i.Country)
                .HasMaxLength(255);

            builder.Property(i => i.Zipcode)
                .HasMaxLength(30);

            builder.Property(i => i.Address)
                .HasMaxLength(255);

        }
    }
}
