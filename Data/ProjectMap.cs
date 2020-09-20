using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nop.Data.Mapping;
using Nop.Plugin.Misc.Projects.Domain;

namespace Nop.Plugin.Misc.Projects.Data
{
    public class ProjectMap : NopEntityTypeConfiguration<Project>
    {
      

        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable(nameof(Project));
            builder.HasKey(pr => pr.Id);
            builder.Property(pr => pr.Name).IsRequired();
            builder.Property(pr => pr.ShortDescription).IsRequired();
            builder.Property(pr => pr.FullDescription).IsRequired();

        }
    }
}
