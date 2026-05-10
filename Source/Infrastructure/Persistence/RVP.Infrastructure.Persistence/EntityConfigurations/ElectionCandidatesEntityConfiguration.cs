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
  public  class ElectionCandidatesEntityConfiguration: IEntityTypeConfiguration<ElectionCandidates>
    {//configuration of  how the entity will be created in the database
        public void Configure(EntityTypeBuilder<ElectionCandidates> builder)  {
            #region Basic configuration
            builder.HasKey(ec => ec.Id);
            builder.ToTable("ElectionCandidates");
            #endregion


            #region Relationship configuration
            builder.HasMany<Votes>(ec => ec.Votes)
                .WithOne(v=>v.ElectionCandidates)
                .HasForeignKey(v => v.IdElectionCandidate)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }


    }
}
