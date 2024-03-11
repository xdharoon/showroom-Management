using Microsoft.EntityFrameworkCore;
using ShowroomManagementAPI.Data;
using ShowroomManagementAPI.Model;
using ShowroomManagementAPI.Repositoires;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_MyAllowSpecificOrigins";


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(m => m.UseSqlServer(builder.Configuration.GetConnectionString("deafultConnection")));

builder.Services.AddCors(option => option.AddPolicy(MyAllowSpecificOrigins, policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

//---------------------- MODEL DEPENDENCE ----------------------

builder.Services.AddScoped<IDepartment, DepartmentModel>();
builder.Services.AddScoped<IEmployee,EmployeeModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
