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
    public class PointSystemConfiguration : IEntityTypeConfiguration<PointSystem>
    {
        public void Configure(EntityTypeBuilder<PointSystem> builder)
        {
            builder.ToTable("point_system");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.RaceClassificationId).HasColumnName("race_classification_id");
            builder.Property(x => x.ResultType).HasColumnName("result_type").IsRequired();
            builder.Property(x => x.Points).HasColumnName("points").IsRequired();

            builder.HasOne(x => x.RaceClassification)
                   .WithMany()
                   .HasForeignKey(x => x.RaceClassificationId);
        }
    }
}
