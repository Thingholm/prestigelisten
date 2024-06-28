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
    public class RaceCalendarConfiguration : IEntityTypeConfiguration<RaceCalendar>
    {
        public void Configure(EntityTypeBuilder<RaceCalendar> builder)
        {
            builder.ToTable("race_calendar");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.RaceId).HasColumnName("race_id").IsRequired();
            builder.Property(x => x.StartDate).HasColumnName("start_date").IsRequired();
            builder.Property(x => x.EndDate).HasColumnName("end_date").IsRequired();

            builder.HasOne(x => x.Race)
                   .WithOne()
                   .HasForeignKey<RaceCalendar>(x => x.RaceId);
        }
    }
}
