using People.Api.Entities;
using People.Api.Entities.Exceptions;
using People.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Api.Services
{
    /// <summary>
    /// Default implementation of IPersonService.
    /// </summary>
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        /// <summary>
        /// Creates a new Person.
        /// </summary>
        /// <param name="forename">The forename(s) of the Person.</param>
        /// <param name="surname">The surname(s) of the Person.</param>
        /// <returns>An awaitable Task of type Person.</returns>
        public async Task<Person> CreateAsync(string forename,
            string surname)
        {
            //validate names
            List<ValidationError> validationErrors = ValidateNames(forename,
                surname);
            if (validationErrors.Any())
            {
                throw new ValidationException(validationErrors);
            }
            //call repository
            DateTime createUpdateTime = DateTime.UtcNow;
            Person createdPerson = await personRepository.CreateAsync(forename,
                surname,
                createUpdateTime,
                createUpdateTime);
            return createdPerson;
        }

        /// <summary>
        /// Gets all People.
        /// </summary>
        /// <returns>An awaitable Task of type (IEnumerable of type Person).</returns>
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            IEnumerable<Person> allPeople = await personRepository.GetAllAsync();
            return allPeople;
        }

        /// <summary>
        /// Gets a specified Person.
        /// </summary>
        /// <param name="personId">The ID of the specified Person.</param>
        /// <returns>An awaitable Task of type Person.</returns>
        public async Task<Person> GetSingleAsync(Guid personId)
        {
            Person person = await personRepository.GetSingleAsync(personId);
            if (person == null)
            {
                throw new NotFoundException(typeof(Person),
                    personId);
            }
            return person;
        }

        /// <summary>
        /// Updates the specified Person.
        /// </summary>
        /// <param name="personId">The ID of the specified Person.</param>
        /// <param name="forename">The new forename(s) of the Person.</param>
        /// <param name="surname">The new surname(s) of the Person.</param>
        /// <returns>An awaitable Task of type Person.</returns>
        public async Task<Person> UpdateAsync(Guid personId,
            string forename,
            string surname)
        {
            //check Person exists
            Person person = await personRepository.GetSingleAsync(personId);
            if (person == null)
            {
                throw new NotFoundException(typeof(Person),
                    personId);
            }
            //validate names
            List<ValidationError> validationErrors = ValidateNames(forename,
                surname);
            if (validationErrors.Any())
            {
                throw new ValidationException(validationErrors);
            }
            //update
            Person updatedPerson = await personRepository.UpdateAsync(personId,
                forename,
                surname,
                DateTime.UtcNow);
            return updatedPerson;
        }

        /// <summary>
        /// Deletes the specified Person.
        /// </summary>
        /// <param name="personId">The ID of the Person to be deleted.</param>
        /// <returns>An awaitable Task.</returns>
        public async Task DeleteAsync(Guid personId)
        {
            //check Person exists
            Person person = await personRepository.GetSingleAsync(personId);
            if (person == null)
            {
                throw new NotFoundException(typeof(Person),
                    personId);
            }
            //delete
            await personRepository.DeleteAsync(personId);
        }

        private List<ValidationError> ValidateNames(string forename,
            string surname)
        {
            List<ValidationError> valedationErrors = new List<ValidationError>();
            //not null, empty, or whitespace
            if (string.IsNullOrWhiteSpace(forename))
            {
                valedationErrors.Add(new ValidationError("forename", "Value cannot be null, empty, or whitespace."));
            }
            if (string.IsNullOrWhiteSpace(surname))
            {
                valedationErrors.Add(new ValidationError("surname", "Value cannot be null, empty, or whitespace."));
            }
            //not more than 64 characters long
            if (forename?.Length > 64)
            {
                valedationErrors.Add(new ValidationError("forename", "Value must be less than 64 characters long."));
            }
            if (surname?.Length > 64)
            {
                valedationErrors.Add(new ValidationError("surname", "Value must be less than 64 characters long."));
            }
            return valedationErrors;
        }
    }
}
