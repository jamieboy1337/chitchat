using System.Collections.Generic;

namespace chitchat
{
    /**
     *  Represents a single line of conversation.
     */ 
    public interface ConversationLine
    {
        // represents which speaker is participating.
        int SpeakerId { get; }   
        public IReadOnlyCollection<SpeechSnippet> GetSpeechSnippets();
    }
}