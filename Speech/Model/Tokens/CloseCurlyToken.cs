namespace chitchat
{
    public class CloseCurlyToken : BaseToken
    {
        public TokenType token => TokenType.CLOSECURLY;

        public override string ToString()
        {
            return "}";
        }
    }
}