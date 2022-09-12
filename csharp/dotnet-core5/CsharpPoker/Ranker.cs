using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpPoker 
{
  public class Ranker
  {
    public static HandRank GetHandRank(IEnumerable<Card> cards) =>
      Rankings()
        .OrderByDescending(x => x.rank)
        .First(x => x.eval(cards))
        .rank;

    private static List<(Func<IEnumerable<Card>, bool> eval, HandRank rank)> Rankings()
    {
      return new List<(Func<IEnumerable<Card>, bool> eval, HandRank rank)>
      {
        ((cards)=>FiveCardPokerScorer.IsThreeOfAKind(cards), HandRank.ThreeOfAKind),
        ((cards)=>FiveCardPokerScorer.IsRoyalFlush(cards), HandRank.RoyalFlush),
        ((cards)=>FiveCardPokerScorer.IsPair(cards), HandRank.Pair),
        ((cards)=>FiveCardPokerScorer.IsFourOfAKind(cards), HandRank.FourOfAKind),
        ((cards)=>FiveCardPokerScorer.IsFlush(cards), HandRank.Flush),
        ((cards)=>FiveCardPokerScorer.IsStraight(cards), HandRank.Straight),
        ((cards)=>FiveCardPokerScorer.IsFullHouse(cards), HandRank.FullHouse),
        ((cards)=>true, HandRank.HighCard),
        ((cards)=>FiveCardPokerScorer.IsTwoPair(cards), HandRank.TwoPair),
      };
    }
  }
}