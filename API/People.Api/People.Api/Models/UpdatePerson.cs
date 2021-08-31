using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Api.Models
{
    /// <summary>
    /// Represents a Person to be updated via a PUT request. 
    /// In this case it is indentical to a CreatePerson, but in real-world examples,
    /// you will often have extra parameters on the CreatePerson that cannot be changed
    /// later, ergo separate classes for POST and PUT.
    /// </summary>
    public class UpdatePerson
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
