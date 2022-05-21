namespace chitchat
{
    /**
     *  Represents the state of a dialog within a stream.
     *  DialogueState accumulates any defined values within a dialogue
     *  and allows them to be read sequentially.
     */ 
    public interface DialogueState
    {
        // the text being spoken in current state
        public string DialogueText { get; }

        // id of the current speaker
        public int SpeakerId { get; }

        public string SpeakerName { get; }

    }
}