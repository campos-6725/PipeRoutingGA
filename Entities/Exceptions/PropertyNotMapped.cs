using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Entities.Exceptions
{

    [Serializable]
    public class PropertyNotMapped : Exception
    {
        public PropertyNotMapped()
        {
        }

        public PropertyNotMapped(string message) : base(message)
        {
        }

        public PropertyNotMapped(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PropertyNotMapped(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}
