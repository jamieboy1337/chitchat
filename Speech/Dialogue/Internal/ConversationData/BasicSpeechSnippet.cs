namespace chitchat
{
    public class BasicSpeechSnippet : SpeechSnippet
    {
        private readonly string text;

        public string Text => text;

        public BasicSpeechSnippet(string Text)
        {
            this.text = Text;
        }
    }
}