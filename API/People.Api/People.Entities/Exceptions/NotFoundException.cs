using System;
using System.Collections.Generic;
using System.Text;

namespace People.Api.Entities.Exceptions
{
    public class NotFoundException : Exception
    {
        public override string Message => "The requested resource could not be found.";
        public Type ResourceType { get; set; }
        public Guid ResourceId { get; set; }

        public NotFoundException(Type resourceType,
            Guid resourceId)
        {
            ResourceType = resourceType;
            ResourceId = resourceId;
        }
    }
}
