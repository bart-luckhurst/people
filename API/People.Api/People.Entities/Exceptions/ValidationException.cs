using System;
using System.Collections.Generic;
using System.Text;

namespace People.Api.Entities.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(List<ValidationError> validationErrors)
        {

        }
    }
}
