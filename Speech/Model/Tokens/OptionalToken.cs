namespace chitchat
{
    public class OptionalToken : BaseToken
    {
        public TokenType token => TokenType.OPTIONAL;

        public override string ToString()
        {
            return "#optional";
        }
    }
}