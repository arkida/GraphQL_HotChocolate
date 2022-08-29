using GraphQL_HotChocolate.Model;

namespace GraphQL_HotChocolate.Repository
{
    public interface ISwapiPeopleRepository
    {
        People? List();
        /// <summary>
        /// Get the person data (identifed by its ID) from the repository
        /// </summary>
        /// <param name="id">The person's ID</param>
        /// <returns>A person object linked to the ID</returns>
        Task<SwapiPerson> GetByID(int id);

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

        /// <summary>
        /// Check if a person of a specific ID exists in the repository
        /// </summary>
        /// <param name="id">The ID of the person to be checked</param>
        /// <returns>A boolean indicating if the user exists or not</returns>
        Task<bool> DoesExist(int id);


        /// <summary>
        /// Get object's count in the database
        /// </summary>
        /// <returns>The count of object in the database, zero if empty</returns>
        int Count();
    }
}
