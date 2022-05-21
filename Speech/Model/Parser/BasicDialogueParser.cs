using System;
using System.Collections.Generic;

namespace chitchat
{

    // probably need a dialogue parser builder, so that we can pass named placeholders in the future
    public class BasicDialogueParser : DialogueParser
    {
        public DialogueData parseTokens(IReadOnlyCollection<BaseToken> tokens)
        {
            // each line: "name" <colon> "words and numbers, concatenated" <newline>
            List<ConversationLine> fraglist = new List<ConversationLine>();

            List<string> tokenStore = new List<string>();

            string speakerName = "";
            string phrase = "";

            Dictionary<string, int> speakernames = new Dictionary<string, int>();

            bool readingSpeakerName = true;

            foreach (BaseToken token in tokens) {
                if (token.GetType() == typeof(ColonToken) || token.GetType() == typeof(NewLineToken))
                {
                    if (token.GetType() == typeof(ColonToken))
                    {
                        if (!readingSpeakerName)
                        {
                            throw new InvalidOperationException("Encountered colon while reading dialogue");
                        }

                        speakerName = string.Join(' ', tokenStore);
                    } else
                    {
                        if (readingSpeakerName)
                        {
                            throw new InvalidOperationException("Encountered newline while reading speaker name");
                        }

                        phrase = string.Join(' ', tokenStore);
                    }

                    tokenStore.Clear();
                    readingSpeakerName = !readingSpeakerName;

                    if (readingSpeakerName)
                    {   // just finished reading a dialogue line
                        int speakerid = (speakernames.ContainsKey(speakerName) ? speakernames[speakerName] : speakernames.Count);
                        if (!speakernames.ContainsKey(speakerName))
                        {
                            speakernames.Add(speakerName, speakerid);
                        }

                        fraglist.Add(new BasicConversationLine(speakerid, new List<SpeechSnippet>() { new BasicSpeechSnippet(phrase) }));

                    }
                } else
                {
                    // punctuation should be appended to latest string in list
                    tokenStore.Add(token.ToString());
                }
            }

            return new DialogueDataImpl(new List<ConversationFragment>() { new BasicConversationFragment(fraglist) }, speakernames);
        }
    }
}