using GraphQL_HotChocolate.Services;
using GraphQL_HotChocolate.Repository;
using GraphQL_HotChocolate.Model;
using HotChocolate.AspNetCore.Authorization;

namespace GraphQL_HotChocolate.GraphQL
{
    public class Query
    {
        private readonly ISwapiPeopleService _service;
        private readonly ISwapiPeopleRepository _repo;
        public Query(ISwapiPeopleService service, ISwapiPeopleRepository repo)
        {
            _service = service;
            _repo = repo;
        }

        [Authorize(Policy = "Admin")]
        public Task<SwapiPeople> GetSwapiPeople()
        {
            return _service.GetSwapiPeople();
        }


        public async Task<SwapiPerson> GetSwapiPerson(int id)
        {
            var person = await _service.GetSwapiPersonById(id);
            
            return person;
        }
    }
}
