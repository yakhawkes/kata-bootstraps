using System.Collections.Generic;
using System.Linq;

namespace CsharpPoker
{
  public static class FiveCardPokerScorer
  {
    public static bool IsRoyalFlush(IEnumerable<Card> cards) => IsFlush(cards) && cards.All(x => x.Value > CardValue.Nine);

    public static bool IsFlush(IEnumerable<Card> cards) => cards.All(x => x.Suit == cards.First().Suit);

    public static bool IsPair(IEnumerable<Card> cards) => IsMultipleOfKind(cards, 2);

    public static bool IsThreeOfAKind(IEnumerable<Card> cards) => IsMultipleOfKind(cards, 3);

    public static bool IsFourOfAKind(IEnumerable<Card> cards) => IsMultipleOfKind(cards, 4);

    public static bool IsMultipleOfKind(IEnumerable<Card> cards, int multiple)
      => cards.GroupBy(p => p.Value).Where(o => o.Count() == multiple).SingleOrDefault() != default;

    public static bool IsFullHouse(IEnumerable<Card> cards) => IsPair(cards) && IsThreeOfAKind(cards);

    public static bool IsStraight(IEnumerable<Card> cards)
    {
      return cards.OrderBy(x => x.Value).Zip(cards.OrderBy(x => x.Value).Skip(1),
        (card, nextcard) => card.Value + 1 == nextcard.Value).All(x => x);
    }
  }
}