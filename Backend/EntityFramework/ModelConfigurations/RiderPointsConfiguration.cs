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
    public class RiderPointsConfiguration : IEntityTypeConfiguration<RiderPoints>
    {
        public void Configure(EntityTypeBuilder<RiderPoints> builder)
        {
            builder.ToTable("rider_points");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.RiderId).HasColumnName("rider_id").IsRequired();
            builder.HasIndex(x => x.RiderId).IsUnique();
            builder.Property(x => x.Points).HasColumnName("points").IsRequired();
            builder.HasOne(x => x.Rider)
                   .WithOne()
                   .HasForeignKey<RiderPoints>(x => x.RiderId);
        }
    }
}
