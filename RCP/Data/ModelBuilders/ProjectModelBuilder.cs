using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCP.Models;

namespace RCP.Data.ModelBuilders
{
  public class ProjectModelBuilder
  {
    public static void Build(ModelBuilder builder)
    {
      var entity = builder.Entity<Project>();

      entity.ToTable("Projects");
      entity.HasKey(k => k.Id);
      entity.Property<int>(p => p.Id).IsRequired().HasColumnName("Id");
      entity.Property<string>(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(255);
      entity.Property<string>(p => p.Description).IsRequired().HasColumnName("Description").HasMaxLength(255);
      entity.Property<DateTime>(p => p.DateTimeStart).IsRequired().HasColumnName("DateTimeStart").HasColumnType("datetime");
      entity.Property<DateTime>(p => p.DateTimeEnd).IsRequired().HasColumnName("DateTimeEnd").HasColumnType("datetime");
    }
  }
}
