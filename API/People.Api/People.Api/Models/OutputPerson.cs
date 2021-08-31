using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Api.Models
{
    /// <summary>
    /// Represents a Person as they are exposed in an API response.
    /// </summary>
    public class OutputPerson
    {
        /// <summary>
        /// The (public) ID of the Person, as exposed to users.
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// The forename(s) of the Person.
        /// </summary>
        public string Forename { get; set; }

        /// <summary>
        /// The surname(s) of the Person.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// The DateTime at which the Person was created.
        /// </summary>
        public DateTime DateTimeCreated { get; set; }

        /// <summary>
        /// The DateTime at which the Person was last updated.
        /// </summary>
        public DateTime DateTimeUpdated { get; set; }
    }
}
