using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RVP.Core.Domain.Entities;


namespace RVP.Infrastructure.Persistence.EntityConfigurations
{
  public  class ElectedPositionEntityConfiguration: IEntityTypeConfiguration<ElectedPosition>
    {//configuration of  how the entity will be created in the database
        public void Configure(EntityTypeBuilder<ElectedPosition> builder)  {
            #region Basic configuration
            builder.HasKey(ep => ep.Id);
            builder.ToTable("ElectedPositions");
            #endregion

            #region Property configuration
            builder.Property(ep => ep.Name).IsRequired().HasMaxLength(90);
            builder.Property(u => u.Description).IsRequired().HasMaxLength(200);
            #endregion
            #region Relationship configuration
            builder.HasMany<CandidatePosition>(ep => ep.CandidatePositions)
                .WithOne(cp => cp.ElectedPosition)
                .HasForeignKey(cp => cp.IdElectedPosition)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany<ElectionCandidates>(ep => ep.ElectionCandidates)
               .WithOne(ec => ec.ElectedPosition)
               .HasForeignKey(ec => ec.IdElectedPosition)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany<ElectionPosition>(ep => ep.ElectionPosition)
               .WithOne(el => el.ElectedPosition)
               .HasForeignKey(el => el.IdElectedPosition)
               .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }


    }
}
