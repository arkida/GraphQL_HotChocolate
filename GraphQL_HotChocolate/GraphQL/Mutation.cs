using GraphQL_HotChocolate.Model;
using GraphQL_HotChocolate.Repository;
using GraphQL_HotChocolate.Services;
using GreenDonut;
using HotChocolate.AspNetCore.Authorization;

namespace GraphQL_HotChocolate.GraphQL
{
    public class Mutation
    {
        private readonly ISwapiPeopleService _service;
        private readonly ISwapiPeopleRepository _repo;
        public Mutation(ISwapiPeopleService service, ISwapiPeopleRepository repo)
        {
            _service = service;
            _repo = repo;
        }

        //[Authorize(Policy = "Admin")]
        public async Task<SwapiPerson> AddSwapiPerson(SwapiPerson sperson)
        {          
            await _repo.Add(sperson);
            return sperson;
        }
    }
}
