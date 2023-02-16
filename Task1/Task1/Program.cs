namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game.task1();
        }

        
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

        public class Game
        {
            const int TIMESTAMPS_COUNT = 50000;

            const double PROBABILITY_SCORE_CHANGED = 0.0001;

            const double PROBABILITY_HOME_SCORE = 0.45;

            const int OFFSET_MAX_STEP = 3;

            public GameStamp[] gameStamps;

            public Game()
            {
                this.gameStamps = new GameStamp[] { };
            }

            public Game(GameStamp[] gameStamps)
            {
                this.gameStamps = gameStamps;
            }

            GameStamp generateGameStamp(GameStamp previousValue)
            {
                Random rand = new Random();

                bool scoreChanged = rand.NextDouble() > 1 - PROBABILITY_SCORE_CHANGED;
                int homeScoreChange = scoreChanged && rand.NextDouble() > 1 - PROBABILITY_HOME_SCORE ? 1 : 0;
                int awayScoreChange = scoreChanged && homeScoreChange == 0 ? 1 : 0;
                int offsetChange = (int)(Math.Floor(rand.NextDouble() * OFFSET_MAX_STEP)) + 1;

                return new GameStamp(
                    previousValue.offset + offsetChange,
                    previousValue.score.home + homeScoreChange,
                    previousValue.score.away + awayScoreChange
                    );
            }

            public static Game generateGame()
            {
                Game game = new Game();
                game.gameStamps = new GameStamp[TIMESTAMPS_COUNT];

                GameStamp currentStamp = new GameStamp(0, 0, 0);
                for (int i = 0; i < TIMESTAMPS_COUNT; i++)
                {
                    game.gameStamps[i] = currentStamp;
                    currentStamp = game.generateGameStamp(currentStamp);
                }

                return game;
            }

            public static void task1()
            {
                Game game = generateGame();
                game.printGameStamps();
            }

            public void printGameStamps()
            {
                foreach (GameStamp stamp in this.gameStamps)
                {
                    Console.WriteLine($"{stamp.offset}: {stamp.score.home}-{stamp.score.away}");
                }
            }

            /// <summary>
            /// Реализация метода GetScore согласно заданию бинарный поиск
            /// </summary>
            /// <param name="offset"></param>
            /// <returns></returns>
            public Score getScore(int offset)
            {
                if (offset < 0)
                    return new Score(-1, -1);
                int start = 0;
                int end = this.gameStamps.Length - 1;

                while (start <= end)
                {
                    int middle = (start + end) / 2;

                    if (this.gameStamps[middle].offset == offset)
                    {
                        return this.gameStamps[middle].score;
                    }
                    else if (this.gameStamps[middle].offset < offset)
                    {
                        start = middle + 1;
                    }
                    else
                    {
                        end = middle - 1;
                    }
                }
                //Либо offset не был найден return Score(0,0)
                return new Score(0, 0);
            }

            /// <summary>
            /// Реализация метода GetScore через LINQ запрос
            /// </summary>
            /// <param name="offset"></param>
            /// <returns></returns>
            public Score getScoreUseLINQ(int offset)
            {
                //Если offset введено не валидное значение offset < 0, то return Score(-1, -1)
                if (offset < 0)
                    return new Score(-1, -1);
                //Если offset не был найден возврощает Score(0, 0)
                Score score = gameStamps.LastOrDefault(x => x.offset <= offset).score;
                return score;
            }
        }
    }
}