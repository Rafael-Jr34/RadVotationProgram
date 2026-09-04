using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RVP.Core.Domain.Entities;


namespace RVP.Infrastructure.Persistence.EntityConfigurations
{
  public  class ElectionPositionEntityConfiguration: IEntityTypeConfiguration<ElectionPosition>
    {//configuration of  how the entity will be created in the database
        public void Configure(EntityTypeBuilder<ElectionPosition> builder)  {
            #region Basic configuration
            builder.HasKey(ep => ep.Id);
            builder.ToTable("ElectionPosition");
            #endregion

          
            #region Relationship configuration
            builder.HasMany<Votes>(ep =>ep.Votes)
                .WithOne(v => v.ElectionPosition)
                .HasForeignKey(v => v.IdElectionPosition)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }


    }
}
