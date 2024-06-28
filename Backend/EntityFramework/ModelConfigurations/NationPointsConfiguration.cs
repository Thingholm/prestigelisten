using EntityFramework.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.ModelConfigurations
{
    public class NationPointsConfiguration : IEntityTypeConfiguration<NationPoints>
{
    public void Configure(EntityTypeBuilder<NationPoints> builder)
    {
        builder.ToTable("nation_points");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.NationId).HasColumnName("nation_id").IsRequired();
        builder.HasIndex(x => x.NationId).IsUnique();
        builder.Property(x => x.Points).HasColumnName("points").IsRequired();
        
        builder.HasOne(x => x.Nation)
               .WithOne()
               .HasForeignKey<NationPoints>(x => x.NationId);
    }
}
}
