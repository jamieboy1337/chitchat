namespace chitchat
{
    public class SemiColonToken : BaseToken
    {
        public TokenType token => TokenType.SEMICOLON;

        public override string ToString()
        {
            return ";";
        }
    }
}