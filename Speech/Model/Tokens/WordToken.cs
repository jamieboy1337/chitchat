namespace chitchat
{
    public class WordToken : BaseToken
    {
        public TokenType token => TokenType.WORD;

        public readonly string WordData;

        public WordToken(string word)
        {
            WordData = word;
        }

        public override string ToString()
        {
            return WordData;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            } else
            {
                return (obj as WordToken).WordData.Equals(this.WordData);
            }
        }

        public override int GetHashCode()
        {
            return WordData.GetHashCode();
        }
    }
}