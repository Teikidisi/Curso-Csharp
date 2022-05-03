using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    public class SubdepartmentConfiguration : IEntityTypeConfiguration<Subdepartment>
    {
        public void Configure(EntityTypeBuilder<Subdepartment> builder)
        {
            builder.HasIndex(c => c.Name).IsUnique();
        }
    }
}