using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCP.Models;

namespace RCP.Data.ModelBuilders
{
  public class MeasurementQuestionnaireAnswerModelBuilder
  {
    public static void Build(ModelBuilder builder)
    {
      var entity = builder.Entity<MeasurementQuestionnaireAnswer>();

      entity.ToTable("MeasurementQuestionnaireAnswers");
      entity.HasKey(k => k.Id);
      entity.Property<int>(p => p.Id).IsRequired().HasColumnName("Id");
      entity.Property<int>(p => p.MeasurementId).IsRequired().HasColumnName("MeasurementId");
      entity.Property<string>(p => p.Value).IsRequired().HasColumnName("Value");
    }
  }
}
