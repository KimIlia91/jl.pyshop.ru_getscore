﻿namespace Task1
{
    public partial class Program
    {
        public struct GameStamp
        {
            public int offset;
            public Score score;
            public GameStamp(int offset, int home, int away)
            {
                this.offset = offset;
                this.score = new Score(home, away);
            }
        }
    }
}