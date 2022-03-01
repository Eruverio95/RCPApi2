using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using RCP.Data.ModelBuilders;
using RCP.Models;

namespace RCP.Data
{
  public class RCPDbContext : DbContext
  {
    public RCPDbContext(DbContextOptions<RCPDbContext> options) : base(options)
    {
    }

    private DbSet<ActiveMeasurement> ActiveMeasurements { get; set; }
    private DbSet<Activity> Activities { get; set; }
    private DbSet<Measurement> Measurements { get; set; }
    private DbSet<MeasurementQuestionnaireAnswer> MeasurementQuestionnaireAnswers { get; set; }
    private DbSet<Project> Projects { get; set; }
    private DbSet<Questionnaire> Questionnaires { get; set; }
    private DbSet<Role> Roles { get; set; }
    private DbSet<User> Users { get; set; }
    private DbSet<UserProjectRole> UserProjectRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      
      ActiveMeasurementModelBuilder.Build(modelBuilder);
      ActivityModelBuilder.Build(modelBuilder);
      MeasurementModelBuilder.Build(modelBuilder);
      MeasurementQuestionnaireAnswerModelBuilder.Build(modelBuilder);
      ProjectModelBuilder.Build(modelBuilder);
      QuestionnaireModelBuilder.Build(modelBuilder);
      RoleModelBuilder.Build(modelBuilder);
      UserModelBuilder.Build(modelBuilder);
      UserProjectRoleModelBuilder.Build(modelBuilder);

      modelBuilder.Entity<ActiveMeasurement>().HasIndex(x => x.UserId).IsUnique();
      modelBuilder.Entity<MeasurementQuestionnaireAnswer>().HasIndex(x => x.MeasurementId).IsUnique();
    }
  }
}
