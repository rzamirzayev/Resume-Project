using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts.Configurations
{
    class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(c => c.Name).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.HasKey(c=> c.Id);
            builder.ToTable("Products");
        }
    }
}
