using System;
using System.Text;
using System.Collections.Generic;

namespace chitchat
{
    public class DialogueTokenizer
    {
        private static readonly int[] SINGLE_CHAR_DELINEATORS = { ' ', '{', '}', ':', '\n', ';'};
        private static readonly char OPTIONAL_CHAR = '#';
        private static readonly string OPTIONAL_STRING = "#optional";
        private static readonly HashSet<int> delins;

        // invalidate default constructor
        private DialogueTokenizer() { }

        static DialogueTokenizer()
        {
            delins = new HashSet<int>(SINGLE_CHAR_DELINEATORS);
        }

        private static BaseToken FlushBuffer(StringBuilder b)
        {
            if (b.Length > 0)
            {
                string wordval = b.ToString();
                double temp;
                if (Double.TryParse(wordval, out temp))
                {
                    return (new NumberToken(temp));
                }
                else
                {
                    return (new WordToken(wordval));
                }
            } else
            {
                return null;
            }
        }

        public static List<BaseToken> parse(string input)
        {
            StringStream stream = new StringStream(input);
            StringBuilder builder = new StringBuilder();
            List<BaseToken> tokens = new List<BaseToken>();

            // start consuming data
            int c;


            while (!stream.Eof())
            {
                c = stream.GetChar();
                if (c == -1)
                {
                    throw new InvalidOperationException("Stream exhausted unexpectedly");
                }

                if (delins.Contains(c))
                {

                    // if buffer non-empty, flush as word
                    if (builder.Length > 0)
                    {
                        // possible optional?
                        if (builder[0] == OPTIONAL_CHAR
                         && builder.ToString().Equals(OPTIONAL_STRING))
                        {
                            // reference class vs inst? whatever i will figure it out later
                            tokens.Add(new OptionalToken());
                        } else
                        {
                            BaseToken token = DialogueTokenizer.FlushBuffer(builder);
                            if (token != null)
                            {
                                tokens.Add(token);
                            }
                        }

                        builder.Clear();
                    }

                    // builder is empty -- handle delineator
                    switch ((TokenType)c)
                    {
                        case TokenType.CLOSECURLY:
                            tokens.Add(new CloseCurlyToken());
                            break;
                        case TokenType.OPENCURLY:
                            tokens.Add(new OpenCurlyToken());
                            break;
                        case TokenType.COLON:
                            tokens.Add(new ColonToken());
                            break;
                        case TokenType.NEWLINE:
                            tokens.Add(new NewLineToken());
                            break;
                        case TokenType.SEMICOLON:
                            tokens.Add(new SemiColonToken());
                            break;
                        default:
                            Console.Error.WriteLine("Invalid token encountered: " + c);
                            break;
                    }

                } else
                {
                    builder.Append((char)c);
                }
            }

            BaseToken b = FlushBuffer(builder);
            if (b != null)
            {
                tokens.Add(b);
            }

            return tokens;
        }
    }
}
