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
  public  class UserEntityConfiguration: IEntityTypeConfiguration<User>
    {//configuration of  how the entity will be created in the database
        public void Configure(EntityTypeBuilder<User> builder)  {
            #region Basic configuration
            builder.HasKey(u => u.Id);
            builder.ToTable("Users");
            #endregion

            #region Property configuration
            builder.Property(u => u.username).IsRequired().HasMaxLength(90);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(200);   
            #endregion
            #region Relationship configuration
            builder.HasOne(u => u.PoliticalLeaders)
                .WithOne(pl => pl.Leader)
                .HasForeignKey<PoliticalLeaders>(pl => pl.IdLeader)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }


    }
}
