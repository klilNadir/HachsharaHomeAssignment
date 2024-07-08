using HachsharaHomeAssignment.Implementations;
using HachsharaHomeAssignment.Interfaces;
using HachsharaHomeAssignment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<InsurancePolicyService>();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<InsurancePolicyRepository>();
builder.Services.AddScoped<IUserRepository>(c => c.GetRequiredService<UserRepository>());
builder.Services.AddScoped<IInsurancePolicyRepository>(c => c.GetRequiredService <InsurancePolicyRepository>());
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
