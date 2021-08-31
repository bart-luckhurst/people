using Microsoft.EntityFrameworkCore;
using People.Api.Entities;
using People.Api.Repositories.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace People.Api.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext personContext;

        public PersonRepository(PersonContext personContext)
        {
            this.personContext = personContext;
        }

        public async Task<Person> CreateAsync(string forename,
            string surname,
            DateTime dateTimeCreated,
            DateTime dateTimeUpdated)
        {
            Person person = new Person()
            {
                Forename = forename,
                Surname = surname,
                DateTimeCreated = dateTimeCreated,
                DateTimeUpdated = dateTimeUpdated
            };
            await personContext
                .People
                .AddAsync(person);
            await personContext.SaveChangesAsync();
            return person;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            IEnumerable<Person> allPeople = await personContext
                .People
                .ToListAsync();
            return allPeople;
        }

        public async Task<Person> GetSingleAsync(Guid personId)
        {
            Person person = await personContext
                .People
                .FindAsync(personId);
            return person;
        }

        public async Task<Person> UpdateAsync(Guid personId,
            string newForename,
            string newSurname,
            DateTime dateTimeUpdated)
        {
            Person personToUpdate = await personContext
                .People
                .FindAsync(personId);
            personToUpdate.Forename = newForename;
            personToUpdate.Surname = newSurname;
            personToUpdate.DateTimeUpdated = dateTimeUpdated;
            await personContext.SaveChangesAsync();
            return personToUpdate;
        }

        public async Task DeleteAsync(Guid personId)
        {
            Person personToRemove = await personContext
                .People
                .FindAsync(personId);
            personContext.Remove(personToRemove);
            await personContext.SaveChangesAsync();
        }
    }
}
