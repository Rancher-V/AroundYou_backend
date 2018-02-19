using AroudYou.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AroudYou.Persistence.EntityConfigurations
{
    public class FavoritesConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);

            builder.HasOne(f => f.Item)
                .WithMany(i => i.Favorites)
                .HasForeignKey(f => f.ItemId);

        }
    }
}
