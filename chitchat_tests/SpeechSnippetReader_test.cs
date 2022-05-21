using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using System.Linq;

using chitchat;

class DialogueDataStub : DialogueData
{

    private IList<ConversationFragment> frags;

    public DialogueDataStub(IList<ConversationFragment> fragments)
    {
        this.frags = fragments;
    }

    public IReadOnlyCollection<ConversationFragment> GetConversationFragments()
    {
        return (IReadOnlyCollection<ConversationFragment>)this.frags;
    }

    public string GetSpeakerName(int speakerId)
    {
        return "";
    }

    public IEnumerable<DialogueState> ReadDialogue()
    {
        // nop
        return null;
    }
}

public class SpeechSnippetReader_test1
{
    // A Test behaves as an ordinary method
    [Test]
    public void SpeechSnippetReader_ensureSpeechSnippetReaderReadsDialogueSequentially()
    {
        string[] sentencea = { "hello there", "friend" };
        string[] sentenceb = { "hello", "to you", "too" };

        List<string> sentences = new List<string>();
        sentences.AddRange(sentencea);
        sentences.AddRange(sentenceb);

        List<int> speakers = new List<int>() { 0, 0, 1, 1, 1 };

        ConversationLine linea = new BasicConversationLine(0, sentencea.Select(frag => (SpeechSnippet)(new BasicSpeechSnippet(frag))).ToList());
        ConversationLine lineb = new BasicConversationLine(1, sentenceb.Select(frag => (SpeechSnippet)(new BasicSpeechSnippet(frag))).ToList());

        ConversationFragment fragment = new BasicConversationFragment(new List<ConversationLine>() { linea, lineb });

        SpeechSnippetReader reader = new SpeechSnippetReaderImpl(new DialogueDataStub(new List<ConversationFragment>() { fragment }));

        int cursor = 0;
        foreach (DialogueState state in reader)
        {
            Assert.AreEqual(speakers[cursor], state.SpeakerId);
            Assert.AreEqual(sentences[cursor], state.DialogueText);
            cursor++;
        }

        Assert.AreEqual(5, cursor);
    }
}
