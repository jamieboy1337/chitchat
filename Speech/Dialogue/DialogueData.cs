using System;
using System.Collections.Generic;


// represents DialogueData which may be contained within a file.
namespace chitchat
{
    public interface DialogueData {
        // dialogue data should contain
        // - optional data, as dicts or numbers or string
        // - actual speech data
        // we need, at some point, the following features
        // - stochastic events
        // - skill checks, stochastic events plus player capabilities
        // - named placeholders, which can be swapped trivially
        // - data for locations, positions

        // to this effect:
        // dialogue will be composed of multiple `conversation fragments`
        // conversation fragments will contain `dialogue`
        // `dialogue` will consist of one or more `speech strings` spoken by an individual

        // stochastic events and skill checks can be built on top of conversation fragments
        // speaker lines can be built out of dialogue
        // intonation, placeholders, emotes, etc can be built out of speech strings
        // we'll build emotes into speech lines
        // caveat: what about successive emotes?
        // handle contextually -- emotes might be replayed, emotions might be sustained

        // we'll use some final component to convert this dialogue data into a more usable form
        // the final form needs dialogue and speech strings, we can handle them together



        /**
         *  @returns enumerable over dialogue states
         */ 
        public IEnumerable<DialogueState> ReadDialogue();

        /**
         *  @returns list of conversation fragments.
         */ 
        public IReadOnlyCollection<ConversationFragment> GetConversationFragments();

        /**
         *  Maps speaker IDs to speaker names.
         *  @param speakerId - id of speaker attached to dialogue state.
         *  @returns string representing character's name, if available.
         */ 
        public string GetSpeakerName(int speakerId);

        protected static Dictionary<int, string> reverseNamesDict(IDictionary<string, int> namesOld)
        {
            Dictionary<int, string> res = new Dictionary<int, string>();
            foreach (KeyValuePair<string, int> pair in namesOld)
            {
                if (res.ContainsKey(pair.Value))
                {
                    throw new ArgumentException("Parser generated two names with the same ID!");
                }

                res.Add(pair.Value, pair.Key);
            }

            return res;
        }
    }
}