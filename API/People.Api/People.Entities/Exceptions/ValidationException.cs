using System;
using System.Collections.Generic;
using System.Text;

namespace People.Api.Entities.Exceptions
{
    public class ValidationException : Exception
    {
        public override string Message => "One or more validation errors occured. Please fix these and try again.";
        public List<ValidationError> ValidationErrors { get; set; }

        public ValidationException(List<ValidationError> validationErrors)
        {
            ValidationErrors = validationErrors;
        }
    }
}
