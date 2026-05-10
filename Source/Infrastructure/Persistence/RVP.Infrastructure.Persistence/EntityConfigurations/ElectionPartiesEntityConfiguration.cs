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
  public  class ElectionPartiesEntityConfiguration: IEntityTypeConfiguration<ElectionParties>
    {//configuration of  how the entity will be created in the database
        public void Configure(EntityTypeBuilder<ElectionParties> builder)  {
            #region Basic configuration
            builder.HasKey(u => u.Id);
            builder.ToTable("ElectionParties");
            #endregion

            
            #region Relationship configuration
            builder.HasMany<ElectionCandidates>(ep=>ep.ElectionCandidates)
                .WithOne(ec => ec.ElectionParty)
                .HasForeignKey(ec => ec.IdEllectionParty)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }


    }
}
