using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RVP.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Infrastructure.Persistence.EntityConfigurations
{
  public  class CitizenEntityConfiguration: IEntityTypeConfiguration<Citizen>
    {//configuration of  how the entity will be created in the database
        public void Configure(EntityTypeBuilder<Citizen> builder)  {
            #region Basic configuration
            builder.HasKey(ci => ci.Id);
            builder.ToTable("Citizens");
            #endregion

            #region Property configuration
            builder.Property(ci => ci.LastName).IsRequired().HasMaxLength(90);
            builder.Property(ci => ci.Name).IsRequired().HasMaxLength(90);
            builder.Property(ci =>ci.Email).IsRequired().HasMaxLength(100);
            #endregion

            #region Relationship configuration
            builder.HasMany<Votes>(ci => ci.Votes)
                .WithOne(v => v.Citizen)
                .HasForeignKey(v => v.IdCitizen)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }


    }
}
