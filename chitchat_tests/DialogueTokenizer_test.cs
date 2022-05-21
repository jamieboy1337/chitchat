using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

using chitchat;

using System.Collections.Generic;



public class DialogueTokenizer_test
{
    // A Test behaves as an ordinary method

    [Test]
    public void DialogueTokenizer_testCharEquality()
    {
        BaseToken a = new CloseCurlyToken();
        BaseToken b = new ColonToken();

        Assert.AreNotEqual(a, b);

        b = new OpenCurlyToken();

        Assert.AreNotEqual(a, b);

        a = new OpenCurlyToken();

        Assert.AreEqual(a, b);

        a = new NumberToken(314.5);

        Assert.AreNotEqual(a, b);

        b = new NumberToken(123.4);

        Assert.AreNotEqual(a, b);

        b = new NumberToken(314.5);

        Assert.AreEqual(a, b);

        a = new WordToken("test1");

        Assert.AreNotEqual(a, b);

        b = new WordToken("test1");

        Assert.AreEqual(a, b);
    }

    [Test]
    public void DialogueTokenizer_testSimplePhrases()
    {
        const string TEST_STRING_A = "hello;\n";
        // treat numbers as words?
        const string TEST_STRING_B = "#optional dingaling 36";

        const string TEST_STRING_C = ";{}\n  313:";

        BaseToken[] EXPECTED_A = { new WordToken("hello"), new SemiColonToken(), new NewLineToken() };
        BaseToken[] EXPECTED_B = { new OptionalToken(), new WordToken("dingaling"), new NumberToken(36) };
        BaseToken[] EXPECTED_C = { new SemiColonToken(), new OpenCurlyToken(), new CloseCurlyToken(), new NewLineToken(), new NumberToken(313), new ColonToken() };

        // Use the Assert class to test conditions
        IList<BaseToken> tokens_a = DialogueTokenizer.parse(TEST_STRING_A);
        IList<BaseToken> tokens_b = DialogueTokenizer.parse(TEST_STRING_B);
        IList<BaseToken> tokens_c = DialogueTokenizer.parse(TEST_STRING_C);

        Assert.AreEqual(EXPECTED_A.Length, tokens_a.Count);
        Assert.AreEqual(EXPECTED_B.Length, tokens_b.Count);
        Assert.AreEqual(EXPECTED_C.Length, tokens_c.Count);

        for (int i = 0; i < EXPECTED_A.Length; i++)
        {
            Assert.AreEqual(EXPECTED_A[i], tokens_a[i]);
        }

        for (int i = 0; i < EXPECTED_B.Length; i++)
        {
            Assert.AreEqual(EXPECTED_B[i], tokens_b[i]);
        }

        for (int i = 0; i < EXPECTED_C.Length; i++)
        {
            Assert.AreEqual(EXPECTED_C[i], tokens_c[i]);
        }
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
}

// todo: figure out testing framework, write dialogue parser tests