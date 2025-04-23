using Microsoft.EntityFrameworkCore;
using WebAPI_NationalPark_1035.Data;
using WebAPI_NationalPark_1035.DtoMaping;
using WebAPI_NationalPark_1035.Repository;
using WebAPI_NationalPark_1035.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string cs = builder.Configuration.GetConnectionString("conStr");
builder.Services.AddDbContext<AppllicationDbContext>
    (option => option.UseSqlServer(cs));
builder.Services.AddScoped<ITrailRepository, TrailRepository>();
builder.Services.AddScoped<INationalParkRepository, NationalParkRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
 