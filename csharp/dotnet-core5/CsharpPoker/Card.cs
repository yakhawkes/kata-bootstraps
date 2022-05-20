namespace CsharpPoker
{
  public class Card
  {
    public Card(CardValue value, CardSuit suit)
    {
      Value = value;
      Suit = suit;
    }

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => $"{Value} of {Suit}";

    public CardValue Value { get; }
    public CardSuit Suit { get; }
  }
}