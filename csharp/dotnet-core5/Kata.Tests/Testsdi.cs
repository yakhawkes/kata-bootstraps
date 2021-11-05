using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using FluentAssertions;
using FluentValidation.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.Tests
{
  public class Testsdi
  {
    private readonly Mock<IDisplay> _displayMock;
    private readonly IGameScore _gameScore;

    private enum Player
    {
      One = 1,
      Two = 2
    };

    public Testsdi()
    {
      _displayMock = new Mock<IDisplay>();
      var services = new ServiceCollection();
      services.AddSingleton<IDisplay>(_ => _displayMock.Object)
              .AddTransient<IGameScore, GameScore>();


      var serviceProvider = services.BuildServiceProvider();
      
      _gameScore = serviceProvider.GetService<IGameScore>();
    }

    [Fact]
    public void InitializeGameScore_ShouldBeLove()
    {
      _displayMock.Verify(x => x.DisplayScore($"{GameScore.Love} - {GameScore.Love}"), Times.Once);
    }

    [Fact]
    public void PlayerScores_ShouldCallDisplayScoreTwice()
    {
      SimulateGame(Player.One);
      _displayMock.Verify(x => x.DisplayScore(It.IsAny<string>()), Times.Exactly(2));
    }

    [Fact]
    public void PlayerOneScoresOnce_ShouldBe15Love()
    {
      SimulateGame(Player.One);
      _displayMock.Verify(x => x.DisplayScore($"{GameScore.Fifteen} - {GameScore.Love}"), Times.Once);
    }

    [Fact]
    public void PlayerOneScoresTwice_ShouldBe30Love()
    {
      SimulateGame(Player.One, Player.One);
      _displayMock.Verify(x => x.DisplayScore($"{GameScore.Thirty} - {GameScore.Love}"), Times.Once);
    }

    [Fact]
    public void PlayerTwoScoresOnce_ShouldBeLove15()
    {
      SimulateGame(Player.Two);
      _displayMock.Verify(x => x.DisplayScore($"{GameScore.Love} - {GameScore.Fifteen}"), Times.Once);
    }

    [Fact]
    public void PlayerTwoScoresTwice_ShouldBeLove30()
    {
      SimulateGame(Player.Two, Player.Two);
      _displayMock.Verify(x => x.DisplayScore($"{GameScore.Love} - {GameScore.Thirty}"), Times.Once);
    }

    [Fact]
    public void PlayerOneScoresOnce_PlayerTwoScoresOnce_ShouldBeLove30()
    {
      SimulateGame(Player.One, Player.Two);
      _displayMock.Verify(x => x.DisplayScore($"{GameScore.Fifteen} - {GameScore.Fifteen}"), Times.Once);
    }

    private void SimulateGame(params Player[] playerScores)
    {
      foreach (Player player in playerScores)
      {
        if (player == Player.One)
        {
          _gameScore.PlayerOneScores();
        }
        else if (player == Player.Two)
        {
          _gameScore.PlayerTwoScores();
        }
      }
    }
  }
}