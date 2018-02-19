using AroudYou.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AroudYou.Persistence.EntityConfigurations
{
    public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            builder.HasKey(ic => new { ic.ItemId, ic.CategoryId});

            builder.HasOne(ic => ic.Item)
                .WithMany(i => i.ItemCategories)
                .HasForeignKey(ic => ic.ItemId);

            builder.HasOne(ic => ic.Category)
               .WithMany(c => c.ItemCategories)
               .HasForeignKey(ic => ic.CategoryId);


        }

    }
}
