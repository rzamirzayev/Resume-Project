using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts.Configurations.Membership
{
    class ResumeUserClaimEntityTypeConfiguration : IEntityTypeConfiguration<ResumeUserClaim>
    {
        public void Configure(EntityTypeBuilder<ResumeUserClaim> builder)
        {
            builder.HasKey(m => m.Id);
            builder.ToTable("UserClaims", "Membership");
        }
    }
}
