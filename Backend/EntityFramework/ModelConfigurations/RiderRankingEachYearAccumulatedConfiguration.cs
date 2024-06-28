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
    public class RiderRankingEachYearAccumulatedConfiguration : IEntityTypeConfiguration<RiderRankingEachYearAccumulated>
    {
        public void Configure(EntityTypeBuilder<RiderRankingEachYearAccumulated> builder)
        {
            builder.ToTable("rider_rankings_each_year_accumulated");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.RiderId).HasColumnName("rider_id").IsRequired();
            builder.Property(x => x.Year).HasColumnName("year").IsRequired();
            builder.Property(x => x.Points).HasColumnName("points").IsRequired();
            builder.Property(x => x.Placement).HasColumnName("placement");

            builder.HasOne(x => x.Rider)
                   .WithMany()
                   .HasForeignKey(x => x.RiderId);
        }
    }
}
