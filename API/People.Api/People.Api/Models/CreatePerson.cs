using People.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Api.Models
{
    /// <summary>
    /// Represents a Person to be created via a POST request.
    /// </summary>
    public class CreatePerson
    {
        /// <summary>
        /// The forename(s) of the Person.
        /// </summary>
        public string Forename { get; set; }

        /// <summary>
        /// The surname(s) of the Person.
        /// </summary>
        public string Surname { get; set; }
    }
}
