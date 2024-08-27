using imsmasterApi.Contexts;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbEmployee>();
builder.Services.AddDbContext<DbIoTFac1>();
builder.Services.AddDbContext<DbIoTFac2>();
builder.Services.AddDbContext<DbIoTFac3Line6>();
builder.Services.AddDbContext<DbIoTFac3Line8>();
builder.Services.AddDbContext<DBSCM>();
builder.Services.AddDbContext<DbHRM>();
//builder.Services.AddDbContext<DbEtdMstProgram>(options =>
//        options.UseSqlServer(builder.Configuration.GetConnectionString("dbIoTFac2")));

builder.Services.AddCors(options => options.AddPolicy("Cors", builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));
var app = builder.Build();
app.UseCors("Cors");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseDeveloperExceptionPage();
app.MapControllers();

app.Run();
