using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class SubdepartmentConfiguration : IEntityTypeConfiguration<Subdepartment>
    {
        public void Configure(EntityTypeBuilder<Subdepartment> builder)
        {
            builder.HasIndex(c => c.Name).IsUnique();
        }
    }
}
