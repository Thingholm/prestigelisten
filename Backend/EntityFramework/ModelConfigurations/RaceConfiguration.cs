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
    public class RaceConfiguration : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            builder.ToTable("races");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.ActiveSpan).HasColumnName("active_span");
            builder.Property(x => x.NationId).HasColumnName("nation_id");
            builder.Property(x => x.RaceClassificationId).HasColumnName("race_classification_id");
            builder.Property(x => x.Active).HasColumnName("active");
            builder.Property(x => x.ColorHex).HasColumnName("color_hex").HasMaxLength(6);

            builder.HasOne(x => x.Nation)
                   .WithMany()
                   .HasForeignKey(x => x.NationId);

            builder.HasOne(x => x.RaceClassification)
                   .WithMany()
                   .HasForeignKey(x => x.RaceClassificationId);
        }
    }
}
