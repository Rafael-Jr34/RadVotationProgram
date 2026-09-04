using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RVP.Core.Domain.Entities;


namespace RVP.Infrastructure.Persistence.EntityConfigurations
{
  public  class ElectionEntityConfiguration: IEntityTypeConfiguration<Election>
    {//configuration of  how the entity will be created in the database
        public void Configure(EntityTypeBuilder<Election> builder)  {
            #region Basic configuration
            builder.HasKey(u => u.Id);
            builder.ToTable("Elections");
            #endregion

            #region Property configuration
            builder.Property(e => e.Name).IsRequired().HasMaxLength(90);
            #endregion
            #region Relationship configuration
            builder.HasMany<ElectionParties>(el=>el.ElectionParties)
                .WithOne(ep => ep.Election)
                .HasForeignKey(ep => ep.IdElection)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany<ElectionCandidates>(el => el.ElectionCandidates)
                .WithOne(ec => ec.Election)
                .HasForeignKey(ec => ec.IdElection)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany<ElectionPosition>(el => el.ElectionPositions)
                .WithOne(ep => ep.Election)
                .HasForeignKey(ep => ep.IdElection)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }


    }
}
