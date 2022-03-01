using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCP.Models;

namespace RCP.Data.ModelBuilders
{
  public class ActivityModelBuilder
  {
    public static void Build(ModelBuilder builder)
    {
      var entity = builder.Entity<Activity>();

      entity.ToTable("Activities");
      entity.HasKey(k => k.Id);
      entity.Property<int>(p => p.Id).IsRequired().HasColumnName("Id");
      entity.Property<string>(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(255);
      entity.Property<string>(p => p.Description).IsRequired().HasColumnName("Description").HasMaxLength(255);
      entity.Property<int>(p => p.ProjectId).IsRequired().HasColumnName("ProjectId");
      entity.Property<int>(p => p.QuestionnaireId).IsRequired().HasColumnName("QuestionnaireId");
    }
  }
}
