using Newtonsoft.Json;
using GraphQL_HotChocolate.Model;
using Xunit;
using Xunit.Priority;
using GraphQL_HotChocolate.GraphQL;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using HotChocolate.Execution;
using Snapshooter.Xunit;
using GreenDonut;
using Moq;
using GraphQL_HotChocolate.Services;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Net;
using Moq.Protected;

namespace GraphQL_XunitTest
{
    public class UnitTest1
    {

        public UnitTest1()
        {
        }

        [Fact, Priority(1)]
        public async Task GenerateSchema_MatchesExistingSnapshot()
        {
            // Arrange
            var schema = await new ServiceCollection()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .BuildSchemaAsync();

            // Act & Assert
            schema.ToString().MatchSnapshot();
        }


        [Fact, Priority(2)]
        public void GetSwapiPeople_Test()
        {
            // All requests made with HttpClient go through its handler's SendAsync() which we mock
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();


            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\MockFiles\SwapiPeople_DataResponse.txt");
            string sFilePath = Path.GetFullPath(sFile);
            var jsonData = System.IO.File.ReadAllText(sFilePath);

            var people = JsonConvert.DeserializeObject<SwapiPeople>(jsonData);

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonData),
            };
            
            // Set up the SendAsync method behavior.
            httpMessageHandlerMock
                .Protected() // <= here is the trick to set up protected!!!
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // create the HttpClient
            var httpClient = new HttpClient(httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://swapi.dev/api/people/")
            };

            var swapiPeopleService = new SwapiPeopleService(httpClient);

            var result = swapiPeopleService.GetSwapiPeople();

            Assert.Equal(people.Origin, result.Result.Origin);

            httpMessageHandlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(1),
               ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
               ItExpr.IsAny<CancellationToken>());
        }


        [Fact, Priority(3)]
        public void GetSwapiPersonId_Test()
        {
            // All requests made with HttpClient go through its handler's SendAsync() which we mock
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\MockFiles\SwapiPerson_DataResponse.txt");
            string sFilePath = Path.GetFullPath(sFile);
            var jsonData = System.IO.File.ReadAllText(sFilePath);

            var person = JsonConvert.DeserializeObject<SwapiPerson>(jsonData);

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonData),
            };

            // Set up the SendAsync method behavior.
            httpMessageHandlerMock
                .Protected() // <= here is the trick to set up protected!!!
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(m => m.RequestUri!.Equals("https://swapi.dev/api/people/23")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // create the HttpClient
            var httpClient = new HttpClient(httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://swapi.dev/api/people/")
            };

            var swapiPeopleService = new SwapiPeopleService(httpClient);

            var result = swapiPeopleService.GetSwapiPersonById(person.Id);

            Assert.NotNull(result.Result);

            httpMessageHandlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(1),
               ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
               ItExpr.IsAny<CancellationToken>());
        }

    }
}