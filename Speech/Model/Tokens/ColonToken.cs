namespace chitchat
{
    public class ColonToken : BaseToken
    {
        public TokenType token => TokenType.COLON;

        public override string ToString()
        {
            return ":";
        }
    }
}