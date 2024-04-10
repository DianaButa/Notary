using Microsoft.EntityFrameworkCore;
using Notary.Configurations;
using Notary.Database;
using Notary.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, userService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IFilesService, FilesService>();
builder.Services.AddScoped<IDocumentsService, DocumentsService>();
builder.Services.AddScoped<IFilesService, FilesService>();
builder.Services.AddScoped<IDocumentsService, DocumentsService>();
builder.Services.AddScoped<ICompanyClientService, CompanyClientService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
  options.EnableSensitiveDataLogging();
  options.LogTo(Console.WriteLine, LogLevel.Information);
});

// Configure CORS
builder.Services.ConfigureCors();

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

// Apply CORS middleware
app.UseCors();

app.MapControllers();

app.Run();
