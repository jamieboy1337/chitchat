namespace chitchat
{
    public class NumberToken : BaseToken
    {
        public TokenType token => TokenType.NUMBER;

        public readonly double Value;

        public NumberToken(double val)
        {
            Value = val;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return this.Value == (obj as NumberToken).Value;
        }

        public override int GetHashCode()
        {
            return (int)(this.Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}