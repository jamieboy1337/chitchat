using System.Collections.Generic;

namespace chitchat
{
    public class DialogueDataImpl : DialogueData
    {
        private List<ConversationFragment> conversationFragments;
        private Dictionary<int, string> speakerNames;

        public DialogueDataImpl(List<ConversationFragment> fragments, Dictionary<string, int> speakernames)
        {
            this.conversationFragments = fragments;
            this.speakerNames = DialogueData.reverseNamesDict(speakernames);
        }

        public IReadOnlyCollection<ConversationFragment> GetConversationFragments()
        {
            return this.conversationFragments;
        }

        public string GetSpeakerName(int speakerId)
        {
            return this.speakerNames.GetValueOrDefault(speakerId, null);
        }

        public IEnumerable<DialogueState> ReadDialogue()
        {
            return new SpeechSnippetReaderImpl(this);
        }
    }
}