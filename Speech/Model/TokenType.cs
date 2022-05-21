// Speech lib will contain datqa for parsing dialogue trees and turning them
// into dialogue items

// runtime scripts will inherit monobehaviour, and
// will allow expression of speech through game objects

namespace chitchat
{
    public enum TokenType
    {
        OPENCURLY = '{',
        CLOSECURLY = '}',
        COLON = ':',
        NEWLINE = '\n',
        SEMICOLON = ';',
        OPTIONAL,
        WORD,
        NUMBER
    }
}
