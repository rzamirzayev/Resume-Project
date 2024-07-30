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
    public class PortfolioPostEntityTypeConfiguration:IEntityTypeConfiguration<PortfolioPost>
    {
        public void Configure(EntityTypeBuilder<PortfolioPost> builder)
        {
            builder.Property(b => b.Id).HasColumnType("int");
            builder.Property(b => b.Title).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(b => b.Desc).HasColumnType("nvarchar").HasMaxLength(500);
            builder.Property(b => b.ImagePath).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(b => b.CreatedBy).HasColumnType("int").IsRequired(false);
            builder.Property(b => b.CreatedAt).HasColumnType("datetime").IsRequired(false);
            builder.Property(b => b.PublishedBy).HasColumnType("int");
            builder.Property(b => b.PublishedAt).HasColumnType("datetime");
            builder.Property(b => b.LastModifiedBy).HasColumnType("int");
            builder.Property(b => b.LastModifiedAt).HasColumnType("datetime");
            builder.Property(b => b.DeletedBy).HasColumnType("int");
            builder.Property(b => b.DeletedAt).HasColumnType("datetime");

            builder.ToTable("PortfolioPosts");
            builder.HasKey(b => b.Id);

        }
    }
}
