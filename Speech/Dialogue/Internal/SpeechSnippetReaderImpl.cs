using System;
using System.Collections;
using System.Collections.Generic;

namespace chitchat
{
    public class SpeechSnippetReaderImpl : SpeechSnippetReader
    {
        private DialogueData data;
        private DialogueStateImpl state;

        // abstract this
        private Dictionary<Type, Delegate> actions = new Dictionary<Type, Delegate>
        {
            { typeof(BasicSpeechSnippet), new Action<BasicSpeechSnippet>(i => { }) }
        };

        public SpeechSnippetReaderImpl(DialogueData data)
        {
            this.data = data;
            this.state = new DialogueStateImpl();
        }

        public IEnumerator<DialogueState> GetEnumerator()
        {
            DialogueStateImpl state = new DialogueStateImpl();
            foreach (ConversationFragment frag in data.GetConversationFragments())
            {
                IReadOnlyCollection<ConversationLine> lines = frag.GetConversationLines();
                foreach (ConversationLine line in lines)
                {
                    state.SpeakerId = line.SpeakerId;
                    state.SpeakerName = this.data.GetSpeakerName(state.SpeakerId);
                    foreach (SpeechSnippet speechfrag in line.GetSpeechSnippets())
                    {
                        DialogueStateUpdateHandler.handleSnippet(speechfrag, state);
                        yield return state;
                    }

                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}