using System.Collections.Generic;

namespace chitchat
{
    public class BasicConversationFragment : ConversationFragment
    {
        private IList<ConversationLine> lines;

        public BasicConversationFragment(IList<ConversationLine> lines)
        {
            this.lines = lines;
        }

        public IReadOnlyCollection<ConversationLine> GetConversationLines() => (IReadOnlyCollection<ConversationLine>)lines;
    }
}