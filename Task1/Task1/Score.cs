﻿namespace Task1
{
    public partial class Program
    {
        public struct Score
        {
            public int home;
            public int away;

            public Score(int home, int away)
            {
                this.home = home;
                this.away = away;
            }
        }
    }
}