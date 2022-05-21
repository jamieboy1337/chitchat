namespace chitchat
{
    public class NewLineToken : BaseToken
    {
        public TokenType token => TokenType.NEWLINE;

        public override string ToString()
        {
            return "\n";
        }
    }
}