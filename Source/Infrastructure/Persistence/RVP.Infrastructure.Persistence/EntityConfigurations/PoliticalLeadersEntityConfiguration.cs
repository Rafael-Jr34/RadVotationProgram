using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RVP.Core.Domain.Entities;


namespace RVP.Infrastructure.Persistence.EntityConfigurations
{
  public  class PoliticalLeadersEntityConfiguration : IEntityTypeConfiguration<PoliticalLeaders>
    {//configuration of  how the entity will be created in the database
        public void Configure(EntityTypeBuilder<PoliticalLeaders> builder)  {
            #region Basic configuration
            builder.HasKey(pl => pl.Id);
            builder.ToTable("PoliticalLeaders");
            #endregion

           
        }


    }
}
