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
    public class NationRankingEachYearConfiguration : IEntityTypeConfiguration<NationRankingEachYear>
    {
        public void Configure(EntityTypeBuilder<NationRankingEachYear> builder)
        {
            builder.ToTable("nation_rankings_each_year");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.NationId).HasColumnName("nation_id").IsRequired();
            builder.Property(x => x.Year).HasColumnName("year").IsRequired();
            builder.Property(x => x.Points).HasColumnName("points");
            builder.Property(x => x.Placement).HasColumnName("placement");
            builder.Property(x => x.NumberOfResults).HasColumnName("number_of_results").IsRequired();

            builder.HasOne(x => x.Nation)
                   .WithMany()
                   .HasForeignKey(x => x.NationId);
        }
    }
}
