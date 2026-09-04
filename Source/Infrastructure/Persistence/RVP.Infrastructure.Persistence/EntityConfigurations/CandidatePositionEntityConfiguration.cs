using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RVP.Core.Domain.Entities;

namespace RVP.Infrastructure.Persistence.EntityConfigurations
{
  public  class CandidatePositionEntityConfiguration: IEntityTypeConfiguration<CandidatePosition>
    {//configuration of  how the entity will be created in the database
        public void Configure(EntityTypeBuilder<CandidatePosition> builder)  {
            #region Basic configuration
            builder.HasKey(u => u.Id);
            builder.ToTable("CandidatePositions");
            #endregion

        }


    }
}
