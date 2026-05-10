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
            .HasForeignKey(a=>a.IdSender)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Recruter)
           .WithMany(pp => pp.AllianceIdRecruter)
           .HasForeignKey(a => a.IdRecruter)
           .OnDelete(DeleteBehavior.Cascade);


            #endregion
        }


    }
}
