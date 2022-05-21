using System.Collections;
using System.Collections.Generic;

// base class which all parser tokens will implement
namespace chitchat
{
    public abstract class BaseToken
    {
        TokenType token { get; }

        public override bool Equals(object obj) {
            return (this.GetType() == obj.GetType());
        }

        // don't need to hash
        public override int GetHashCode()
        {
            return 0;
        }
    }
}

