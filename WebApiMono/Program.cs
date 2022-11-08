using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApiMono;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MonobankDbContext>(x =>
                    x.UseSqlServer(builder.Configuration.GetConnectionString("monobankConnectionString")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddIdentity<IdentityUser,IdentityRole>()
        .AddEntityFrameworkStores<MonobankDbContext>()
        .AddDefaultTokenProviders();
    
// validator
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ITransactionService, TransactionService>(); // Services for work with transactions
builder.Services.AddScoped<IAccountServices, AccountServices>();       // Identity


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

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
