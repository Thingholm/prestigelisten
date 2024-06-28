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
    public class RaceClassificationConfiguration : IEntityTypeConfiguration<RaceClassification>
    {
        public void Configure(EntityTypeBuilder<RaceClassification> builder)
        {
            builder.ToTable("race_classifications");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
