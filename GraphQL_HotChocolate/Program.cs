using Microsoft.EntityFrameworkCore;
using GraphQL_HotChocolate.DAL;
//using GraphQL_HotChocolate.;
//using GraphQL_HotChocolate.Repository;
//using GraphQL_HotChocolate.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using GraphQL_HotChocolate.Services;
using GraphQL_HotChocolate.Repository;

var builder = WebApplication.CreateBuilder(args);

// Prepare the URI of the external API service (i.e., swapi.dev) from the config
IConfiguration configuration = builder.Configuration;
Uri uri = new(configuration.GetConnectionString("SwapiEndpoint"));

// Instantiate the in-memory DB
builder.Services.AddPooledDbContextFactory<DatabaseContext>(opt => opt.UseInMemoryDatabase(databaseName: "SwapiPeople"));
builder.Services.AddScoped<ISwapiPeopleRepository, SwapiPeopleRepository>();

// Register the external API service under the name "SWAPI"
builder.Services.AddHttpClient<ISwapiPeopleService, SwapiPeopleService>("query", client =>
{
    client.BaseAddress = uri;
});

// Register the GraphQL on the external API serivce
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();


var app = builder.Build();

// Initialize the GraphQL service
app.MapGraphQL();

app.MapGet("/", () => "Hello World!");

app.Run();
