using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VibePod.Core.Entities;
using VibePod.Core.Models.Request;
using VibePod.Core.Repositories;
using VibePod.Core.Services;
using VibePod.Repository.DbContexts;
using VibePod.Repository.Repositories;
using VibePod.Service.Services;
using VibePod.Service.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/////////
//builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
/////////////////
///builder.Services.AddValidatorsFromAssembly(typeof(CreatePlanRequestValidator).Assembly);
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreatePlanRequestValidator>());

builder.Services.AddFluentValidationAutoValidation();

string postgresqlConnectionString=builder.Configuration.GetConnectionString("PostgreConnection")!;
builder.Services.AddDbContext<VibePodDbContext>((sp, opt) =>
{

    opt.UseNpgsql(postgresqlConnectionString,
    option => { option.MigrationsAssembly(Assembly.GetAssembly(typeof(VibePodDbContext))!.GetName().Name); });
});
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<VibePodDbContext>();

builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(PlanService)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();