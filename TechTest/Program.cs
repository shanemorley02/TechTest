using TechTest.API;
using TechTest.Repository.Data.AddressBook;
using TechTest.Shared.Interface;
using TechTest.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IAddressBookRepository, AddressBookRepository>();
builder.Services.AddSingleton<IReader, JsonReader>();
builder.Services.AddSingleton<IWriter, JsonWriter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureApi();

app.Run();