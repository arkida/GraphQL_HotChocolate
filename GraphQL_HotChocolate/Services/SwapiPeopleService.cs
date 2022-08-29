using GraphQL_HotChocolate.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net.Http.Json;

namespace GraphQL_HotChocolate.Services
{
    public class SwapiPeopleService : ISwapiPeopleService
    {
        private readonly HttpClient _client;
        public SwapiPeopleService(HttpClient client)
        {
            _client = client;
        }
        //public List<People> GetAll()
        //{

        //    return _client.GetFromJsonAsync<People>.Result.();
        //}

        public Task<SwapiPerson> GetPersonFromApiById(int id) =>
            this._client.GetFromJsonAsync<SwapiPerson>(id.ToString());

        public People? List()
        {
            var client = new RestClient("https://swapi.dev/api/people/");
            var request = new RestRequest();
            var response = client.Execute(request);


            try
            {
                return JsonConvert.DeserializeObject<People?>(response.Content);
            }
            catch (Exception ex)
            {

            }

            return null;
        }
    }
}
