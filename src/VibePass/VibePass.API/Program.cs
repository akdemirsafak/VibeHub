using VibePass.Core.Repository;
using VibePass.Core.Service;
using VibePass.Repository.Repositories;
using VibePass.Service.Mappers;
using VibePass.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IEventyRepository, EventyRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IEventyService, EventyService>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.AddAutoMapper(typeof(CommonMapper));


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
