using GraphQL_HotChocolate.Services;
using GraphQL_HotChocolate.Model;

namespace GraphQL_HotChocolate.GraphQL
{
    public class Query
    {
        private readonly ISwapiPeopleService _service;
        public Query(ISwapiPeopleService service)
        {
            _service = service;
        }

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
