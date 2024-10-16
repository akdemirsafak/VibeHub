using FluentValidation.AspNetCore;
using VibePass.Core.Repository;
using VibePass.Core.Service;
using VibePass.Repository.Repositories;
using VibePass.Service.Mappers;
using VibePass.Service.Services;
using VibePass.Service.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IEventyRepository, EventyRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IPerformerRepository, PerformerRepository>();


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IEventyService, EventyService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IPerformerService, PerformerService>();

builder.Services.AddAutoMapper(typeof(CommonMapper));


builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCategoryRequestValidator>());

builder.Services.AddFluentValidationAutoValidation();



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
