using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RCP.Data;
using AutoMapper;
using Microsoft.OpenApi.Models;
using RCP.Logic;
using RCP.Logic.Interfaces;
using RCP.Repository;
using RCP.Repository.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace RCP
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddDbContext<RCPDbContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("connRCP")));
      services.AddAutoMapper();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "RCP API .NET Core",
          Description = "RCP Web API dla projektu inżynierskiego",
          //TermsOfService = new Uri("None"),
          Contact = new OpenApiContact()
          {
            Name = "Mirosław Gąsior IP40pp",
            Email = "miroslaw.gasior95@gmail.com",
            Url = new Uri("https://github.com/Eruverio95")
          }
        });
      });

      services
        .AddScoped<IActivityLogic, ActivityLogic>()
        .AddScoped<IMeasurementLogic, MeasurementLogic>()
        .AddScoped<IProjectLogic, ProjectLogic>()
        .AddScoped<IQuestionnaireLogic, QuestionnaireLogic>()
        .AddScoped<IRoleLogic, RoleLogic>()
        .AddScoped<IUserLogic, UserLogic>()
        .AddTransient<IActiveMeasurementRepository, ActiveMeasurementRepository>()
        .AddTransient<IActivityRepository, ActivityRepository>()
        .AddTransient<IMeasurementRepository, MeasurementRepository>()
        .AddTransient<IMeasurementQuestionnaireAnswerRepository, MeasurementQuestionnaireAnswerRepository>()
        .AddTransient<IProjectRepository, ProjectRepository>()
        .AddTransient<IQuestionnaireRepository, QuestionnaireRepository>()
        .AddTransient<IRoleRepository, RoleRepository>()
        .AddTransient<IUserRepository, UserRepository>()
        .AddTransient<IUserProjectRoleRepository, UserProjectRoleRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseMvc();
      app.UseSwagger();
      app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "RCP API v1"); });
    }
  }
}
