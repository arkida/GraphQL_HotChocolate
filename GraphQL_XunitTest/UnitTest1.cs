using Newtonsoft.Json;
using GraphQL_HotChocolate.Model;
using GraphQL_HotChocolate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using static System.Collections.Specialized.BitVector32;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace GraphQL_XunitTest
{
    public class UnitTest1
    {
        protected IServiceProvider Services { get; }

        public UnitTest1()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            Services = services.BuildServiceProvider();
        }
        protected virtual void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<SwapiPeopleRepository>()
             .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .BuildSchemaAsync();

            var swapiMock = new Mock<ISwapiPeopleService>();

            services.AddSingleton(swapiMock.Object);
        }

        [Fact, Priority(1)]
        public async Task GenerateSchema_MatchesExistingSnapshot()
        {
            // Arrange
            var schema = await new ServiceCollection()
                .AddSingleton<SwapiPeopleRepository>()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .BuildSchemaAsync();

            // Act & Assert
            schema.ToString().MatchSnapshot();
        }

        [Fact, Priority(2)]
        public void GetSwapiPeople_Test()
        {
            var mock = new Mock<ISwapiPeopleService>();
            var jsonData = System.IO.File.ReadAllText("C:\\Users\\arkid\\source\\repos\\GraphQL_HotChocolate\\GraphQL_XunitTest\\MockFiles\\SwapiPeople_DataResponse.txt");
            var people = JsonConvert.DeserializeObject<SwapiPeople>(jsonData);

            mock.Setup(x => x.GetSwapiPeople()).Returns(Task.FromResult(people));

            var result = mock.Object.GetSwapiPeople();
            string test = result.Result.Origin;
            Assert.Equal(people.Origin, result.Result.Origin);
        }


        [Fact, Priority(3)]
        public void GetSwapiPersonId_Test()
        {
            var mock = new Mock<ISwapiPeopleService>();
            var jsonData = System.IO.File.ReadAllText("C:\\Users\\arkid\\source\\repos\\GraphQL_HotChocolate\\GraphQL_XunitTest\\MockFiles\\SwapiPerson_DataResponse.txt");
            var person = JsonConvert.DeserializeObject<SwapiPerson>(jsonData);
            
            mock.Setup(x => x.GetSwapiPersonById(person.Id)).Returns(Task.FromResult(person));

            var result = mock.Object.GetSwapiPersonById(person.Id); 

            Assert.Equal(person.Id, result.Result.Id);
        }




    }
}