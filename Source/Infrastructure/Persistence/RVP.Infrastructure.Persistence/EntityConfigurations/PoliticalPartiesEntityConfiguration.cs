using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RVP.Core.Domain.Entities;


namespace RVP.Infrastructure.Persistence.EntityConfigurations
{
  public  class PoliticalPartiesEntityConfiguration: IEntityTypeConfiguration<PoliticalParties>
    {//configuration of  how the entity will be created in the database
        public void Configure(EntityTypeBuilder<PoliticalParties> builder)  {
            #region Basic configuration
            builder.HasKey(pp => pp.Id);
            builder.ToTable("PoliticalParties");
            #endregion

            #region Property configuration
            builder.Property(pp =>pp.Acronym).IsRequired().HasMaxLength(10);
            #endregion
            #region Relationship configuration
           builder.HasMany<Candidate>(pp=>pp.Candidates)
                .WithOne(c => c.PoliticalParties)
                .HasForeignKey(c=> c.IdParty)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany<ElectionParties>(pp=>pp.ElectionParties)
                .WithOne(ep=>ep.PoliticalParty)
                .HasForeignKey(ep => ep.IdPoliticalParty)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany<PoliticalLeaders>(pp=>pp.PoliticalLeader)
                .WithOne(pl=>pl.PoliticalParty)
                .HasForeignKey(pl=>pl.IdPoliticalParty)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }


    }
}
