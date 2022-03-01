using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCP.Models;

namespace RCP.Data.ModelBuilders
{
  public class UserProjectRoleModelBuilder
  {
    public static void Build(ModelBuilder builder)
    {
      var entity = builder.Entity<UserProjectRole>();

      entity.ToTable("UserProjectRoles");
      entity.HasKey(k => k.Id);
      entity.Property<int>(p => p.Id).IsRequired().HasColumnName("Id");
      entity.Property<string>(p => p.UserId).IsRequired().HasColumnName("UserId").HasMaxLength(8);
      entity.Property<int>(p => p.ProjectId).IsRequired().HasColumnName("ProjectId");
      entity.Property<int>(p => p.RoleId).IsRequired().HasColumnName("RoleId");
    }
  }
}
