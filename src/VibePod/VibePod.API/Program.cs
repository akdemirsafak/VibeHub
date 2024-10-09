using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using VibePod.Core.Entities;
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

string postgresqlConnectionString = builder.Configuration.GetConnectionString("PostgreConnection")!;
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

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IVibeRepository, VibeRepository>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(PlanService)));



builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IVibeService, VibeService>();
builder.Services.AddScoped<IContentService, ContentService>();

builder.Host.UseSerilog();



Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341/")
            //.WriteTo.File("logs/myBeatifulLog-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
