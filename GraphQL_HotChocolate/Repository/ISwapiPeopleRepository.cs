using GraphQL_HotChocolate.Model;

namespace GraphQL_HotChocolate.Repository
{
    public interface ISwapiPeopleRepository
    {
        /// <summary>
        /// Get the all data from the people pages
        /// </summary>
        /// <returns>The person object, if exists, NULL otherwise</returns>
        Task<List<SwapiPeople>> GetSwapiPeople();

        /// <summary>
        /// Get swapi person specifieing the id 
        /// </summary>
        /// <param name="id">The ID of the the person</param>
        /// <returns>It will return the person object or null</returns>
        Task<SwapiPerson> GetSwapiPersonByID(int id);

        /// <summary>
        /// Add a person to the repository
        /// </summary>
        /// <param name="person">The person's object</param>
        /// <returns>Returns the same data object inserted into the repository</returns>
        Task<SwapiPerson> Add(SwapiPerson person);

        /// <summary>
        /// Update person data
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<SwapiPerson> Update(SwapiPerson person);


    }
}
