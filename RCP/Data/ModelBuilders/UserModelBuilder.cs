using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCP.Models;

namespace RCP.Data.ModelBuilders
{
  public static class UserModelBuilder
  {
    public static void Build(ModelBuilder builder)
    {
      var entity = builder.Entity<User>();

      entity.ToTable("Users");
      entity.HasKey(k => k.Id);
      entity.Property<string>(p => p.Id).IsRequired().HasColumnName("Id").HasMaxLength(8);
      entity.Property<string>(p => p.FirstName).IsRequired().HasColumnName("FirstName").HasMaxLength(20);
      entity.Property<string>(p => p.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(30);
    }
  }
}
