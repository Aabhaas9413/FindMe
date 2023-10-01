using DataAccess.Common.Interface;
using DataAccess.Services.SearchDataAccess;
using DataAccess.Services.SearchService;
using SearchServer.Controller;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ISearchService, SearchService>();
builder.Services.AddSingleton(typeof(IGetData<>), typeof(DataAccessFromJSON<>));

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

