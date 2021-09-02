using System;
using System.Collections.Generic;
using System.Text;

namespace People.Api.Entities.Exceptions
{
    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string Problem { get; set; }

        public ValidationError(string propertyName,
            string problem)
        {
            PropertyName = propertyName;
            Problem = problem;
        }
    }
}
