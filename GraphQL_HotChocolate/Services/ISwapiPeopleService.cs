using GraphQL_HotChocolate.Model;
using System;

namespace GraphQL_HotChocolate.Services
{
    public interface ISwapiPeopleService
    {
        /// <summary>
        /// Get the person, identified by its ID, from the remote API service
        /// </summary>
        /// <param name="id">The ID of the desired person to be retrieved</param>
        /// <returns>The person object, if exists, NULL otherwise</returns>
        Task<SwapiPerson> GetPersonFromApiById(int id);
        People? List();
    }
}
