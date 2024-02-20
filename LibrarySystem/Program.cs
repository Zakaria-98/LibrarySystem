using LibrarySystem.Models;
using LibrarySystem.Services;
using LibrarySystem.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers().AddJsonOptions(options =>
{



    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddTransient<ICategoriesService, CategoriesService>();
builder.Services.AddTransient<IBooksServices, BooksService>();
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IOrdersService, OrdersService>();
builder.Services.AddTransient<IRestorationService, RestorationService>();

///repository pattern & unit of work 

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();




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
