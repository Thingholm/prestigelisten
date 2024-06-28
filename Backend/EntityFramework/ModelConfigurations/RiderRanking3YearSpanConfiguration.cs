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
    public class RiderRanking3YearSpanConfiguration : IEntityTypeConfiguration<RiderRanking3YearSpan>
    {
        public void Configure(EntityTypeBuilder<RiderRanking3YearSpan> builder)
        {
            builder.ToTable("rider_rankings_3_year_span");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.RiderId).HasColumnName("rider_id").IsRequired();
            builder.Property(x => x.StartYear).HasColumnName("start_year").IsRequired();
            builder.Property(x => x.EndYear).HasColumnName("end_year").IsRequired();
            builder.Property(x => x.Points).HasColumnName("points");
            builder.Property(x => x.Placement).HasColumnName("placement");

            builder.HasOne(x => x.Rider)
                   .WithMany()
                   .HasForeignKey(x => x.RiderId);
        }
    }
}
