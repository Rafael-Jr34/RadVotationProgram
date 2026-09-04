using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RVP.Core.Domain.Entities;


namespace RVP.Infrastructure.Persistence.EntityConfigurations
{
  public  class VotesEntityConfiguration: IEntityTypeConfiguration<Votes>
    {//configuration of  how the entity will be created in the database
        public void Configure(EntityTypeBuilder<Votes> builder)  {
            #region Basic configuration
            builder.HasKey(u => u.Id);
            builder.ToTable("Votes");
            #endregion

           
         
        }


    }
}
