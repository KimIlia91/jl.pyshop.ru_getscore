using static Task1.Program;

namespace GameTests
{
    public class UnitGameTests
    {
        #region GetScoreUseWhile
        [Fact]
        public void GetScore_ValidOffset_ReturnsCorrectScore()
        {
            // Arrange
            Game game = Game.generateGame();

            // Act
            Score score = game.getScore(10);

            // Assert
            Assert.NotEqual(-1, score.home);
            Assert.NotEqual(-1, score.away);
        }

        [Fact]
        public void GetScore_InvalidOffset_ReturnsZeroScore()
        {
            // Arrange
            Game game = Game.generateGame();

            // Act
            Score score = game.getScore(-10);

            // Assert
            Assert.Equal(-1, score.home);
            Assert.Equal(-1, score.away);
        }

        [Fact]
        public void GetScore_OffsetAtStartOfGame_ReturnsInitialScore()
        {
            // Arrange
            Game game = Game.generateGame();

            // Act
            Score score = game.getScore(0);

            // Assert
            Assert.Equal(0, score.home);
            Assert.Equal(0, score.away);
        }

        [Fact]
        public void GetScore_OffsetAtEndOfGame_ReturnsFinalScore()
        {
            // Arrange
            Game game = Game.generateGame();
            Score finalScore = game.gameStamps[game.gameStamps.Length - 1].score;

            // Act
            Score score = game.getScore(game.gameStamps[game.gameStamps.Length - 1].offset);

            // Assert
            Assert.Equal(finalScore.home, score.home);
            Assert.Equal(finalScore.away, score.away);
        }

        #endregion

        #region GetScoreUseLINQ
        [Fact]
        public void GetScoreUseLINQ_OffsetAtEndOfGame_ReturnsFinalScore()
        {
            // Arrange
            Game game = Game.generateGame();
            Score finalScore = game.gameStamps[game.gameStamps.Length - 1].score;

            // Act
            var score = game.getScoreUseLINQ(game.gameStamps[game.gameStamps.Length - 1].offset);

            // Assert
            Assert.Equal(finalScore.home, score.home);
            Assert.Equal(finalScore.away, score.away);
        }

        [Fact]
        public void GetScoreUseLINQ_OffsetAtStartOfGame_ReturnsInitialScore()
        {
            // Arrange
            Game game = Game.generateGame();

            // Act
            Score score = game.getScoreUseLINQ(0);

            // Assert
            Assert.Equal(0, score.home);
            Assert.Equal(0, score.away);
        }

        [Fact]
        public void GetScoreUseLINQ_InvalidOffset_ReturnsZeroScore()
        {
            // Arrange
            Game game = Game.generateGame();

            // Act
            Score score = game.getScoreUseLINQ(-10);

            // Assert
            Assert.Equal(-1, score.home);
            Assert.Equal(-1, score.away);
        }

        [Fact]
        public void GetScoreUseLINQ_ValidOffset_ReturnsCorrectScore()
        {
            // Arrange
            Game game = Game.generateGame();

            // Act
            Score score = game.getScoreUseLINQ(10);

            // Assert
            Assert.NotEqual(-1, score.home);
            Assert.NotEqual(-1, score.away);
        }

        #endregion
    }
}