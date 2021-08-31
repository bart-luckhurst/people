using System;
using System.Collections.Generic;
using System.Text;

namespace People.Api.Entities.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Type resourceType,
            Guid resourceId)
        {

        }
    }
}
