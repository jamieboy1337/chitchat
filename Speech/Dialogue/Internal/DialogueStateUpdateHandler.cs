using System;
using System.Collections.Generic;

namespace chitchat
{

    // accounts for speechsnippet types and updates DialogueState accordingly
    public class DialogueStateUpdateHandler
    {
        static Dictionary<Type, SnippetType> snippetHandlers = new Dictionary<Type, SnippetType>
        {
            { typeof(BasicSpeechSnippet), SnippetType.BASIC }
        };

        public static void handleSnippet(SpeechSnippet s, DialogueStateImpl state)
        {
            SnippetType type = snippetHandlers.GetValueOrDefault(s.GetType(), SnippetType.UNKNOWN);
            switch (type)
            {
                case SnippetType.BASIC:
                    DialogueStateUpdateHandler.handleBasicSnippet((BasicSpeechSnippet)s, state);
                    break;
                default:
                    Console.Error.WriteLineAsync("StateUpdateHandler encountered unknown type: " + type);
                    break;
            }
        }



        private static void handleBasicSnippet(BasicSpeechSnippet s, DialogueStateImpl state)
        {
            state.DialogueText = s.Text;
        }
    }
}