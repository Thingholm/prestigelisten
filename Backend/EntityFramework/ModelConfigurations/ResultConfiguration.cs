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
    public class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.ToTable("results");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.RaceId).HasColumnName("race_id").IsRequired();
            builder.Property(x => x.RiderId).HasColumnName("rider_id").IsRequired();
            builder.Property(x => x.ResultType).HasColumnName("result_type").IsRequired();
            builder.Property(x => x.Placement).HasColumnName("placement");

            builder.HasOne(x => x.Race)
                   .WithMany()
                   .HasForeignKey(x => x.RaceId);

            builder.HasOne(x => x.Rider)
                   .WithMany()
                   .HasForeignKey(x => x.RiderId);
        }
    }
}
