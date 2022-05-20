using System.Collections.Generic;
using System.Linq;

namespace CsharpPoker
{
  public class Hand
  {
    public Hand()
    {
      Cards = new List<Card>();
    }

    public List<Card> Cards { get; }

    public void Draw(Card card) => Cards.Add(card);

    public Card HighCard()
      => Cards.Aggregate((highCard, nextCard)
        => nextCard.Value > highCard.Value
          ? nextCard
          : highCard); //return Cards.OrderByDescending(x => x.Value).First();

    public HandRank GetHandRank() =>
      IsRoyalFlush() ? HandRank.RoyalFlush :
      IsFlush() ? HandRank.Flush :
      HandRank.HighCard;

    //public HandRank GetHandRank()
    //{
    //  if (IsRoyalFlush())
    //  {
    //    return HandRank.RoyalFlush;
    //  }

    //  if (IsFlush())
    //  {
    //    return HandRank.Flush;
    //  }

    //  return HandRank.HighCard;
    //}

    private bool IsRoyalFlush() => IsFlush() && this.Cards.All(x => x.Value > CardValue.Nine);

    private bool IsFlush() => this.Cards.All(x => x.Suit == this.Cards.First().Suit);
  }
}