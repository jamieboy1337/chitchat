using System.IO;
using System;

// stream-like class for interpreting string data.
// note: don't need a bona fide stream so i wont bother with inheritence

namespace chitchat
{
    public class StringStream
    {

        private readonly string Data;
        private int offset;

        public int Length
        {
            get => this.Data.Length;
        }

        public StringStream(string data)
        {
            this.Data = data;
            this.offset = 0;
        }

        public int GetChar()
        {
            if (this.offset >= this.Data.Length)
            {
                // invalid
                return -1;
            }

            return Data[this.offset++];
        }

        public void UngetChar()
        {
            this.offset = Math.Max(--this.offset, 0);
        }

        public bool Eof()
        {
            return (this.offset >= Data.Length);
        }
    }
}

