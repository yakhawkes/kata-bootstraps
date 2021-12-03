using System.Collections.Generic;

namespace Kata
{
  internal class GameScore
  {
    internal const string Love = "Love";
    internal const string Fifteen = "15";
    internal const string Thirty = "30";
    internal const string Forty = "40";
    internal const string Deuce = "Deuce";
    internal const string PlayerOneAdvantage = "Advantage Player One";
    internal const string PlayerTwoAdvantage = "Advantage Player Two";
    internal const string PlayerOneWins = "Player One Wins!!!";
    internal const string PlayerTwoWins = "Player Two Wins!!!";
    private readonly IDisplay display;
    private readonly List<string> scoreOrder = new ()
    {
      Love, Fifteen, Thirty, Forty
    };
    private int countPlayerOne;
    private int countPlayerTwo;
    internal GameScore(IDisplay display)
    {
      this.display = display;
      countPlayerOne = 0;
      countPlayerTwo = 0;
      display.DisplayScore(GetScore());
    }

    internal void PlayerOneScores()
    {
      countPlayerOne++;
      display.DisplayScore(GetScore());
    }

    internal void PlayerTwoScores()
    {
      countPlayerTwo++;
      display.DisplayScore(GetScore());
    }
    /// <summary>
    /// Get the score from the game
    /// </summary>
    private string GetScore()
    {
      if (IsGameDeuce())
      {
        return Deuce;
      }
      if (IsGamePlayerOneAdvantage())
      {
        return PlayerOneAdvantage;
      }
      if (IsPlayerTwoAdvantage())
      {
        return PlayerTwoAdvantage;
      }
      if (IsPlayerOneWins())
      {
        return PlayerOneWins;
      }
      if (IsPlayerTwoWins())
      {
        return PlayerTwoWins;
      }
      return $"{scoreOrder[countPlayerOne]} - {scoreOrder[countPlayerTwo]}";
      
    }
    
    private bool IsPlayerTwoWins() => countPlayerTwo == 4 || countPlayerTwo > 4 && countPlayerTwo - countPlayerOne > 1;

    private bool IsPlayerOneWins() => countPlayerOne == 4 || countPlayerOne > 4 && countPlayerOne - countPlayerTwo > 1 ;

    private bool IsPlayerTwoAdvantage() => countPlayerTwo > 3 && (countPlayerTwo - countPlayerOne == 1);

    private bool IsGamePlayerOneAdvantage() => countPlayerOne > 3 && (countPlayerOne - countPlayerTwo == 1);

    private bool IsGameDeuce() => (countPlayerOne == countPlayerTwo) && countPlayerOne > 2;
  }
}
