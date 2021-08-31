using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using People.Api.Entities;
using People.Api.Models;
using People.Api.Services;

namespace People.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService personService;
        private readonly IMapper mapper;

        public PeopleController(IPersonService personService,
            IMapper mapper)
        {
            this.personService = personService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Creates a new Person object.
        /// </summary>
        /// <param name="createPerson">The CreatePerson that represents the Person to be created.</param>
        /// <returns>The created Person.</returns>
        [HttpPost]
        public async Task<ActionResult<OutputPerson>> CreateAsync([FromBody] CreatePerson createPerson)
        {
            Person createdPerson = await personService.CreateAsync(createPerson.Forename,
                createPerson.Surname);
            OutputPerson outputPerson = mapper.Map<OutputPerson>(createdPerson);
            return CreatedAtAction(nameof(GetSingleAsync),
                new { outputPerson.PersonId },
                outputPerson);
        }

        /// <summary>
        /// Gets all People.
        /// </summary>
        /// <returns>A List of all People.</returns>
        [HttpGet]
        public async Task<ActionResult<List<OutputPerson>>> GetAllAsync()
        {
            IEnumerable<Person> allPeople = await personService.GetAllAsync();
            List<OutputPerson> outputPeople = mapper.Map<IEnumerable<Person>, List<OutputPerson>>(allPeople);
            return Ok(outputPeople);
        }

        /// <summary>
        /// Gets a specified Person.
        /// </summary>
        /// <param name="personId">The ID of the Person.</param>
        /// <returns>The specified Person.</returns>
        [HttpGet("{personId}")]
        [ActionName(nameof(GetSingleAsync))]
        public async Task<ActionResult<OutputPerson>> GetSingleAsync(Guid personId)
        {
            Person specifiedPerson = await personService.GetSingleAsync(personId);
            OutputPerson outputPerson = mapper.Map<Person, OutputPerson>(specifiedPerson);
            return outputPerson;
        }

        /// <summary>
        /// Updates a specified Person.
        /// </summary>
        /// <param name="personId">The ID of the Person to update.</param>
        /// <param name="updatePerson">The UpdatePerson that represents the Person in their new state.</param>
        /// <returns>The updated Person.</returns>
        [HttpPut("{personId}")]
        public async Task<ActionResult<OutputPerson>> UpdateAsync(Guid personId,
            UpdatePerson updatePerson)
        {
            Person updatedPerson = await personService.UpdateAsync(personId,
                updatePerson.Forename,
                updatePerson.Surname);
            OutputPerson outputPerson = mapper.Map<Person, OutputPerson>(updatedPerson);
            return outputPerson;
        }

        /// <summary>
        /// Deletes the specified Person.
        /// </summary>
        /// <param name="personId">The ID of the Person to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{personId}")]
        public async Task<ActionResult> DeleteAsync(Guid personId)
        {
            await personService.DeleteAsync(personId);
            return NoContent();
        }
    }
}
