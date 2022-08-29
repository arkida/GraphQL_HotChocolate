using GraphQL_HotChocolate.Services;
using GraphQL_HotChocolate.Repository;
using GraphQL_HotChocolate.Model;

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

        public People? List()
        {
            return   _service.List();
        }
        public async Task<SwapiPerson> SwapiPerson(int id)
        {
            var person = await _service.GetPersonFromApiById(id);
            
            return person;
        }
    }
}
