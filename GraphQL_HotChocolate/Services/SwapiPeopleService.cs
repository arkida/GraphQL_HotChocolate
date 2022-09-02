using GraphQL_HotChocolate.Common.Exceptions;
using GraphQL_HotChocolate.Model;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Data.Common;
using System.IO;
using System.Net.Http.Json;
using static GraphQL_HotChocolate.Common.Exceptions.BaseException;
using static HotChocolate.ErrorCodes;

namespace GraphQL_HotChocolate.Services
{
    public class SwapiPeopleService : ISwapiPeopleService
    {
        private readonly HttpClient _client;
        public SwapiPeopleService(HttpClient client)
        {
            _client = client;
        }

        public Task<SwapiPeople> GetSwapiPeople()
        {
            Task<SwapiPeople> people;
            try
            {
                people = _client.GetFromJsonAsync<SwapiPeople>("");
            }
            catch (Exception ex)
            {
                throw new NotFoundException(ex.Message);
            }

            return people;
        }

        public Task<SwapiPerson> GetSwapiPersonById(int id)
        {
            Task<SwapiPerson> person;

            try
            {
                person = _client.GetFromJsonAsync<SwapiPerson>(id.ToString());

            }
            catch (Exception ex)
            {
                throw new NotFoundException(ex.Message);
            }

            return person;
        }


    }
}
