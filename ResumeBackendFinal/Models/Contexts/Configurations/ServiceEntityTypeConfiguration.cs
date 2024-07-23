using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumeBackendFinal.Models.Entities;

namespace ResumeBackendFinal.Models.Contexts.Configurations
{
    public class ServiceEntityTypeConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            throw new NotImplementedException();
        }
    }
}
