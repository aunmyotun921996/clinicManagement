using System.Text.Json;
using Application;
using DataAccess;
using DataAccess.Impl;
using Host.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = false;
    options.SerializerOptions.PropertyNamingPolicy = null;
    options.SerializerOptions.WriteIndented = true;
});
// Add services to the container.
builder.Services.AddScoped<IPatientService, PatientService>();

//Repository
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
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

app.MapGet("/patients/all", async (IPatientService patientService) =>
{
    var results = await patientService.GetAllPatients();
    return Results.Ok(results);
});

app.MapPost("/patients/add", async (IPatientService patientService, PatientModel model) =>
{
    var results = await patientService.AddNewPatient(model.PatientName,model.Gender,model.DateOfBirth,model.PhoneNumber);
    return Results.Ok(results);
});
app.MapPost("/patients/all/ids", async (IPatientService patientService, PatientIdsModel model) =>
{
    var results = await patientService.GetPatientByIds(model.PatientIds);
    return Results.Ok(results);
});

app.Run();

