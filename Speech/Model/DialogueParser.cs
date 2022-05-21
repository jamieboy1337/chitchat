using System.Collections.Generic;

namespace chitchat
{
    public interface DialogueParser
    {
        DialogueData parseTokens(IReadOnlyCollection<BaseToken> tokens);
    }
}