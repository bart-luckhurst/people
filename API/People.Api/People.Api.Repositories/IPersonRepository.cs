using People.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace People.Api.Repositories
{
    /// <summary>
    /// Defines the interface for PersonRepository implementations.
    /// </summary>
    public interface IPersonRepository
    {
        Task<Person> CreateAsync(string forename,
            string surname,
            DateTime dateTimeCreated,
            DateTime dateTimeUpdated);

        Task<IEnumerable<Person>> GetAllAsync();

        Task<Person> GetSingleAsync(Guid personId);

        Task<Person> UpdateAsync(Guid personId,
            string newForename,
            string newSurname,
            DateTime dateTimeUpdated);

        Task DeleteAsync(Guid personId);
    }
}
