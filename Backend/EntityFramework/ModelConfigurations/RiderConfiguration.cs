using EntityFramework.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RiderConfiguration : IEntityTypeConfiguration<Rider>
{
    public void Configure(EntityTypeBuilder<Rider> builder)
    {
        builder.ToTable("riders");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.FirstName).HasColumnName("first_name").IsRequired();
        builder.Property(x => x.LastName).HasColumnName("last_name").IsRequired();
        builder.Property(x => x.BirthYear).HasColumnName("birth_year");
        builder.Property(x => x.NationId).HasColumnName("nation_id");
        builder.Property(x => x.TeamId).HasColumnName("team_id");
        builder.Property(x => x.Active).HasColumnName("active");

        builder.HasOne(x => x.Nation)
               .WithMany()
               .HasForeignKey(x => x.NationId);

        builder.HasOne(x => x.Team)
               .WithMany()
               .HasForeignKey(x => x.TeamId);
    }
}