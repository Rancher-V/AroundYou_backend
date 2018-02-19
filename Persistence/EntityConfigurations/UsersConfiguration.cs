using AroudYou.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AroudYou.Persistence.EntityConfigurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .HasMaxLength(30);
            builder.Property(u => u.LastName)
                .HasMaxLength(30);
            builder.Property(u => u.Password)
                .IsRequired();




        }
    }
}
