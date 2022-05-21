namespace chitchat
{
    public interface DialogueGenerator
    {
        /**
         *  Produces dialogue from a passed in string.
         */ 
        public DialogueData ParseDialogue(string input);
    }
}