namespace Kata
{
  internal interface IDisplay
  {
    internal void DisplayScore(string score);
  }

  class Display : IDisplay
  {
    #region Implementation of IDisplay

    void IDisplay.DisplayScore(string score)
    {
    }

    #endregion
  }
}