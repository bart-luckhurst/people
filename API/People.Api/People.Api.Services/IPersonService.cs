using People.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace People.Api.Services
{
    /// <summary>
    /// Defines the interface for all PersonService implementations.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Creates a new Person.
        /// </summary>
        /// <param name="forename">The forename(s) of the Person.</param>
        /// <param name="surname">The surname(s) of the Person.</param>
        /// <returns>An awaitable Task of type Person.</returns>
        Task<Person> CreateAsync(string forename,
            string surname);

        /// <summary>
        /// Gets all People.
        /// </summary>
        /// <returns>An awaitable Task of type (IEnumerable of type Person).</returns>
        Task<IEnumerable<Person>> GetAllAsync();

        /// <summary>
        /// Gets a specified Person.
        /// </summary>
        /// <param name="personId">The ID of the specified Person.</param>
        /// <returns>An awaitable Task of type Person.</returns>
        Task<Person> GetSingleAsync(Guid personId);

        /// <summary>
        /// Updates the specified Person.
        /// </summary>
        /// <param name="personId">The ID of the specified Person.</param>
        /// <param name="forename">The new forename(s) of the Person.</param>
        /// <param name="surname">The new surname(s) of the Person.</param>
        /// <returns>An awaitable Task of type Person.</returns>
        Task<Person> UpdateAsync(Guid personId,
            string forename,
            string surname);

        /// <summary>
        /// Deletes the specified Person.
        /// </summary>
        /// <param name="personId">The ID of the Person to be deleted.</param>
        /// <returns>An awaitable Task.</returns>
        Task DeleteAsync(Guid personId);
    }
}
