using System.Collections.Generic;

namespace chitchat
{
    public class BasicConversationLine : ConversationLine
    {
        private int speaker_id;
        private IList<SpeechSnippet> snippets;

        // i guess this is how you do interface impl???
        public int SpeakerId
        {
            get => speaker_id;
        }

        public BasicConversationLine(int SpeakerId, IList<SpeechSnippet> snippets)
        {
            this.speaker_id = SpeakerId;
            this.snippets = snippets;
        }

        public IReadOnlyCollection<SpeechSnippet> GetSpeechSnippets() => (IReadOnlyCollection<SpeechSnippet>)snippets;
    }
}