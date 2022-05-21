using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using chitchat;

public class BasicDialogueParser_test
{
    // A Test behaves as an ordinary method
    [Test]
    public void BasicDialogueParser_testSimplePasses()
    {
        const string SAMPLE_A = "a: Hello there old chap.\nb: Likewise, sir, likewise.";
        string[] SAMPLE_A_EXPECTED_DIALOGUE = { "Hello there old chap.", "Likewise, sir, likewise." };
        string[] SAMPLE_A_SPEAKER_NAMES = { "a", "b" };
        List<BaseToken> tokenList = DialogueTokenizer.parse(SAMPLE_A);

        DialogueParser parser = new BasicDialogueParser();
        DialogueData data = parser.parseTokens(tokenList);

        int cursor = 0;

        foreach (DialogueState state in data.ReadDialogue()) {
            Assert.AreEqual(cursor, state.SpeakerId);
            Assert.AreEqual(SAMPLE_A_EXPECTED_DIALOGUE[cursor], state.DialogueText);
            Assert.AreEqual(SAMPLE_A_SPEAKER_NAMES[cursor], state.SpeakerName);
        }
    }
}
