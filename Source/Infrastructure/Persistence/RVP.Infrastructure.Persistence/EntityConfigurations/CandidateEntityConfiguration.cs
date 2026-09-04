using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RVP.Core.Domain.Entities;


namespace RVP.Infrastructure.Persistence.EntityConfigurations
{
  public  class CandidateEntityConfiguration: IEntityTypeConfiguration<Candidate>
    {//configuration of  how the entity will be created in the database
        public void Configure(EntityTypeBuilder<Candidate> builder)  {
            #region Basic configuration
            builder.HasKey(u => u.Id);
            builder.ToTable("Candidates");
            #endregion

            #region Property configuration
            builder.Property(ca => ca.LastName).IsRequired().HasMaxLength(90);
            builder.Property(ca => ca.Name).IsRequired().HasMaxLength(90);
            #endregion
            #region Relationship configuration
            builder.HasMany<CandidatePosition>(ca => ca.CandidatePositions)
                .WithOne(cp => cp.Candidate)
                .HasForeignKey(cp => cp.IDCandidate)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany<ElectionCandidates>(ca => ca.ElectionCandidates)
                .WithOne(ec => ec.Candidate)
                .HasForeignKey(ec => ec.IdCandidate)
                .OnDelete(DeleteBehavior.Restrict);


            #endregion
        }


    }
}
