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
    public class RaceDateConfiguration : IEntityTypeConfiguration<RaceDate>
    {
        public void Configure(EntityTypeBuilder<RaceDate> builder)
        {
            builder.ToTable("race_dates");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.RaceId).HasColumnName("race_id").IsRequired();
            builder.Property(x => x.Stage).HasColumnName("stage");
            builder.Property(x => x.Date).HasColumnName("date").IsRequired();

            builder.HasOne(x => x.Race)
                   .WithMany()
                   .HasForeignKey(x => x.RaceId);
        }
    }
}
