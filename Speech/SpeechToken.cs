// Speech lib will contain datqa for parsing dialogue trees and turning them
// into dialogue items

// runtime scripts will inherit monobehaviour, and
// will allow expression of speech through game objects

public enum SpeechToken {
  OPENCURLY,
  CLOSECURLY,
  COLON,
  NEWLINE,
  OPTIONAL,
  SEMICOLON,
  WORD
}