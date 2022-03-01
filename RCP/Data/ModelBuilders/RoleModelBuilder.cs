using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCP.Models;

namespace RCP.Data.ModelBuilders
{
  public class RoleModelBuilder
  {
    public static void Build(ModelBuilder builder)
    {
      var entity = builder.Entity<Role>();

      entity.ToTable("Roles");
      entity.HasKey(k => k.Id);
      entity.Property<int>(p => p.Id).IsRequired().HasColumnName("Id");
      entity.Property<string>(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(30);
    }
  }
}
