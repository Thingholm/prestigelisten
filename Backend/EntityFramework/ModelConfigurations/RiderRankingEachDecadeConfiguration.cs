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
    public class RiderRankingEachDecadeConfiguration : IEntityTypeConfiguration<RiderRankingEachDecade>
    {
        public void Configure(EntityTypeBuilder<RiderRankingEachDecade> builder)
        {
            builder.ToTable("rider_rankings_each_decade");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.RiderId).HasColumnName("rider_id").IsRequired();
            builder.Property(x => x.Decade).HasColumnName("decade").IsRequired();
            builder.Property(x => x.Points).HasColumnName("points");
            builder.Property(x => x.Placement).HasColumnName("placement");

            builder.HasOne(x => x.Rider)
                   .WithMany()
                   .HasForeignKey(x => x.RiderId);
        }
    }
}
