using Microsoft.AspNetCore.Identity;
using Project.Application;
using Project.Infrastructiure;
using Project.Infrastructure.DataContext;
using Project.Infrastructure.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();
            



// Include Application Dependency
builder.Services.AddApplication();
// Include Infrastructur Dependency
builder.Services.AddInfrastructure(builder.Configuration);



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
