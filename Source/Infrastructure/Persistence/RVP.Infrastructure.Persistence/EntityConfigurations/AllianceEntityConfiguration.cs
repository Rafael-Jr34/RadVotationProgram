using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RVP.Core.Domain.Entities;


namespace RVP.Infrastructure.Persistence.EntityConfigurations
{
  public  class AllianceEntityConfiguration: IEntityTypeConfiguration<Alliance>
    {//configuration of  how the entity will be created in the database
        public void Configure(EntityTypeBuilder<Alliance> builder)  {
            #region Basic configuration
            builder.HasKey(a => a.Id);
            builder.ToTable("Aliances");
            #endregion


            #region Relationship configuration
            builder.HasOne(a => a.Sender)
            .WithMany(pp => pp.AllianceIdSender)
            .HasForeignKey(a => a.IdSender)
            .OnDelete(DeleteBehavior.NoAction);



            builder.HasOne(a => a.Recruter)
           .WithMany(pp => pp.AllianceIdRecruter)
           .HasForeignKey(a => a.IdRecruter)
           .OnDelete(DeleteBehavior.NoAction);
                       


            #endregion
        }


    }
}
