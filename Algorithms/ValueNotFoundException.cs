using System;

namespace Algorithms
{
    public class ValueNotFoundException : Exception
    {
        public ValueNotFoundException()
            : base()
        {
        }

        public ValueNotFoundException(string message)
            : base(message)
        {
        }
    }
}
