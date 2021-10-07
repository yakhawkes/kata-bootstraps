using FluentAssertions;
using Xunit;

namespace Kata.Tests
{
  public class TennisCounterTests
  {
    [Fact]
    public void Initial_ShouldBe_love_love()
    {
      // Arrange
      var counter = new Counter();
      // Act
      var score = counter.GetScore();
      // Assert
      score.Should().Be("love-love");
    }

    [Fact]
    public void PlayerOneScoresOnce_ShouldBe_15_love()
    {
      // Arrange
      var counter = new Counter();

      // Act
      counter.PlayerOneScored();
      var score = counter.GetScore();

      // Assert
      score.Should().Be("15-love");
    }

    [Fact]
    public void PlayerOneScoresTwice_ShouldBe_30_love()
    {
      // Arrange
      var counter = new Counter();

      // Act
      counter.PlayerOneScored();
      counter.PlayerOneScored();
      var score = counter.GetScore();

      // Assert
      score.Should().Be("30-love");
    }

    [Fact]
    public void PlayerOneScoresThreeTimes_ShouldBe_40_love()
    {
      // Arrange
      var counter = new Counter();

      // Act
      counter.PlayerOneScored();
      counter.PlayerOneScored();
      counter.PlayerOneScored();
      var score = counter.GetScore();

      // Assert
      score.Should().Be("40-love");
    }

    [Fact]
    public void PlayerOneScoresWinsToLove_ShouldBe_PlayerOneWins()
    {
      // Arrange
      var counter = new Counter();

      // Act
      counter.PlayerOneScored();
      counter.PlayerOneScored();
      counter.PlayerOneScored();
      counter.PlayerOneScored();
      var score = counter.GetScore();

      // Assert
      score.Should().Be("PlayerOne wins");
    }

    [Fact]
    public void PlayerTwoScoresOnce_ShouldBe_love_15()
    {
      // Arrange
      var counter = new Counter();

      // Act
      counter.PlayerTwoScored();
      var score = counter.GetScore();

      // Assert
      score.Should().Be("love-15");
    }
    [Fact]
    public void PlayerTwoScoresTwice_ShouldBe_love_30()
    {
      // Arrange
      var counter = new Counter();

      // Act
      counter.PlayerTwoScored();
      counter.PlayerTwoScored();
      var score = counter.GetScore();

      // Assert
      score.Should().Be("love-30");
    }
    [Fact]
    public void PlayerTwoScoresThreeTimes_ShouldBe_love_40()
    {
      // Arrange
      var counter = new Counter();

      // Act
      counter.PlayerTwoScored();
      counter.PlayerTwoScored();
      counter.PlayerTwoScored();
      var score = counter.GetScore();

      // Assert
      score.Should().Be("love-40");
    }

    [Fact]
    public void BothPlayersScoredTwice_ShouldBe_30_30()
    {
      // Arrange
      var counter = new Counter();

      // Act
      counter.PlayerTwoScored();
      counter.PlayerOneScored();
      counter.PlayerTwoScored();
      counter.PlayerOneScored();
      var score = counter.GetScore();

      // Assert
      score.Should().Be("30-30");
    }
  }
}

public class Counter
{
  // isn't that bad!
  private int _playerOneScoreIndex = 0;
  private int _playerTwoScoreIndex = 0;

  public string GetScore()
  {
    if (_playerOneScoreIndex < 4)
      return $"{ScoreArray[_playerOneScoreIndex]}-{ScoreArray[_playerTwoScoreIndex]}";
    return ScoreArray[_playerOneScoreIndex];
  }

  private readonly string[] ScoreArray = {
    "love","15","30","40","PlayerOne wins"
  };


  public void PlayerOneScored()
  {
    ++_playerOneScoreIndex;
  }

  public void PlayerTwoScored()
  {
    ++_playerTwoScoreIndex;
  }

}