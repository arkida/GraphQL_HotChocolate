using GraphQL_HotChocolate.Model;
using System;

namespace GraphQL_HotChocolate.Services
{
    public interface ISwapiPeopleService
    {
        /// <summary>
        /// Get the all data from the people pages
        /// </summary>
        /// <returns>The person object, if exists, NULL otherwise</returns>
        Task<SwapiPeople> GetSwapiPeople();

        /// <summary>
        /// Get swapi person specifieing the id 
        /// </summary>
        /// <param name="id">The ID of the the person</param>
        /// <returns>It will return the person object or null</returns>
        Task<SwapiPerson> GetSwapiPersonById(int id);

        /// <summary>
        /// Get swapi person specifieing the id 
        /// </summary>
        /// <param name="id">The ID of the the person</param>
        /// <returns>It will return the person object or null</returns>
  
        //Task AddSwapiPerson(SwapiPerson person);

    }
}
