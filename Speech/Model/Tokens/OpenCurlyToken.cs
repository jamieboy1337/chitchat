namespace chitchat
{
    public class OpenCurlyToken : BaseToken
    {
        public TokenType token => TokenType.OPENCURLY;

        public override string ToString()
        {
            return "{";
        }
    }
}