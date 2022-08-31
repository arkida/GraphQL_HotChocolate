using Microsoft.EntityFrameworkCore;
using GraphQL_HotChocolate.DAL;
using GraphQL_HotChocolate.GraphQL;
using GraphQL_HotChocolate.Repository;
using GraphQL_HotChocolate.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
Uri uri = new(configuration.GetConnectionString("SwapiEndpoint"));


builder.Services.AddPooledDbContextFactory<DatabaseContext>(opt => opt.UseInMemoryDatabase(databaseName: "SwapiPeople"));
builder.Services.AddScoped<ISwapiPeopleRepository, SwapiPeopleRepository>();
builder.Services.AddHttpClient<ISwapiPeopleService, SwapiPeopleService>("swapi", client =>
{
    client.BaseAddress = uri;
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<GraphQL_HotChocolate.GraphQL.Query>()
    .AddMutationType<Mutation>();


var app = builder.Build();

app.MapGraphQL();

app.MapGet("/", () => "Hello World!");

app.Run();
