using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCP.Models;

namespace RCP.Data.ModelBuilders
{
  public class QuestionnaireModelBuilder
  {
    public static void Build(ModelBuilder builder)
    {
      var entity = builder.Entity<Questionnaire>();

      entity.ToTable("Questionnaires");
      entity.HasKey(k => k.Id);
      entity.Property<int>(p => p.Id).IsRequired().HasColumnName("Id");
      entity.Property<string>(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(255);
      entity.Property<string>(p => p.Description).IsRequired().HasColumnName("Description").HasMaxLength(255);
      entity.Property<string>(p => p.QuestionValue).IsRequired().HasColumnName("QuestionValue");
      entity.Property<Enumerators.Enumerators.QuestionType>(p => p.QuestionType).IsRequired().HasColumnName("QuestionType").HasColumnType("int");
      entity.Property<bool>(p => p.QuestionRequired).IsRequired().HasColumnName("QuestionRequired").HasColumnType("bit");
      entity.Property<int>(p => p.ProjectId).IsRequired().HasColumnName("ProjectId");
    }
  }
}
