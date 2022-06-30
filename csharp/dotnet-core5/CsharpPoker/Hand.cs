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
      IsFourOfAKind() ? HandRank.FourOfAKind :
      IsFullHouse() ? HandRank.FullHouse :
      IsFlush() ? HandRank.Flush :
      IsThreeOfAKind() ? HandRank.ThreeOfAKind :
      IsPair() ? HandRank.Pair :
      HandRank.HighCard;


    private bool IsRoyalFlush() => IsFlush() && this.Cards.All(x => x.Value > CardValue.Nine);

    private bool IsFlush() => this.Cards.All(x => x.Suit == this.Cards.First().Suit);

    private bool IsPair() => IsMultipleOfKind(2);

    private bool IsThreeOfAKind() => IsMultipleOfKind(3);

    private bool IsFourOfAKind() => IsMultipleOfKind(4);

    private bool IsMultipleOfKind(int multiple) => Cards.GroupBy(p => p.Value).Where(o => o.Count() == multiple).SingleOrDefault() != default;

    private bool IsFullHouse() => IsPair() && IsThreeOfAKind();

    private bool IsStraight()
    {
      return this.Cards.All(x => x.Value > CardValue.Nine) && !IsPair() && !IsThreeOfAKind() && !IsFourOfAKind();
    }

    // We leave this out for now, as there is no need to implement this. The TwoPairs-test will come later in the tutorial. We will then do a big refactoring :) 
    //private int CountOfAKind(int num) => cards.ToKindAndQuantities().Count(c => c.Value == num);
  }
}