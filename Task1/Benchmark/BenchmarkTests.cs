
using BenchmarkDotNet.Attributes;
using static Task1.Program;

namespace Benchmark
{
    /// <summary>
    /// Тесты на производительность двух методов GetScore
    /// </summary>
    [MemoryDiagnoser]
    [RankColumn]
    public class BenchmarkTests
    {
        private const int testOffset = 23252;
        private const int testInvaliInput = -20;

        //Этот метод работает быстрей незначительно
        [Benchmark]
        public void GetScoreUseWhile()
        {
            Game game = Game.generateGame();
            game.getScore(testOffset);

        }

        [Benchmark]
        public void GetScoreUseLinq()
        {
            Game game = Game.generateGame();
            game.getScoreUseLINQ(testOffset);
        }

        [Benchmark]
        public void GetScoreUseWhile_InvalidInput()
        {
            Game game = Game.generateGame();
            game.getScore(testInvaliInput);
        }

        [Benchmark]
        public void GetScoreUseLinq_InvalidInput()
        {
            Game game = Game.generateGame();
            game.getScoreUseLINQ(testInvaliInput);
        }

    }
}
