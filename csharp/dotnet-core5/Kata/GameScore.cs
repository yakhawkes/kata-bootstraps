using System.Collections.Generic;

namespace Kata
{
  internal interface IGameScore
  {
    void PlayerOneScores();
    void PlayerTwoScores();
  }

  internal class GameScore : IGameScore
  {
    internal const string Love = "Love";
    internal const string Fifteen = "15";
    internal const string Thirty = "30";
    private readonly IDisplay _display;
    private readonly List<string> scoreOrder = new ()
    {
      Love, Fifteen, Thirty
    };
    private int countPlayerOne;
    private int countPlayerTwo;
    public GameScore(IDisplay display)
    {
      _display = display;
      countPlayerOne = 0;
      countPlayerTwo = 0;
      BeautifyScore();
    }

    public void PlayerOneScores()
    {
      countPlayerOne++;
      BeautifyScore();
    }

    public void PlayerTwoScores()
    {
      countPlayerTwo++;
      BeautifyScore();
    }

    private void BeautifyScore()
    {
      _display.DisplayScore($"{scoreOrder[countPlayerOne]} - {scoreOrder[countPlayerTwo]}");
    }


  }
}
