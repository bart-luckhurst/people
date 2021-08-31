using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace People.Api.Entities
{
    /// <summary>
    /// Represents a Person.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// The unique ID of the Person.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        /// The DateTime at which the Person was added.
        /// </summary>
        public DateTime DateTimeCreated { get; set; }

        /// <summary>
        /// The DateTime at which the Person was last updated.
        /// </summary>
        public DateTime DateTimeUpdated { get; set; }
    }
}
