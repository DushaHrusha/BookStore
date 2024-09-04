using BookStore.Core.Abstractions;
using BookStore.Data.Access.Repositories;
using BookStore.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookStoreDbContext>(options =>
{
    //options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(BookStoreDbContext)));
    options.UseNpgsql("User ID=postgres; Password=123; Host=localhost;Port=5432;Database=bookstoredb;");
});
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBooksService, BooksService>();

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
