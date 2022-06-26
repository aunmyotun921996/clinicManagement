using Booking.Application;
using Booking.Application.Impl;
using Booking.DataAccess;
using Booking.DataAccess.Repositories;
using Booking.DataAccess.Repositories.Impl;
using Booking.Http;
using Booking.Http.config;
using Booking.Http.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddOptions();
builder.Services.Configure<ApiConfig>(builder.Configuration.GetSection("ApiConfig"));

var connectionString = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<BookingDbContext>(x => x.UseSqlServer(connectionString));

//Application Services
builder.Services.AddScoped<IBookingService, BookingService>();

//Db Services
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

//Api Services
builder.Services.AddScoped<IPatientServiceApi, PatientServiceApi>();

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
