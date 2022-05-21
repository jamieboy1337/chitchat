using System.Collections.Generic;

namespace chitchat
{
    public interface ConversationFragment
    {
        public IReadOnlyCollection<ConversationLine> GetConversationLines();
    }
}