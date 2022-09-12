﻿using FluentAssertions;
using Xunit;

namespace CsharpPoker.Tests
{
  public class FiveCardPokerScorerTests
  {
    [Fact]
    public void CanGetHighCard()
    {
      Hand hand = new Hand();
      hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
      hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
      hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
      hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));

      // Assert.Equal(CardValue.King, hand.HighCard().Value);
      hand.HighCard().Value.Should().Be(CardValue.King);
    }

    [Fact]
    public void CanScoreHighCard()
    {
      Hand hand = new Hand();
      hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
      hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
      hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
      hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));

      //Assert.Equal(HandRank.HighCard, hand.GetHandRank());
      Ranker.GetHandRank(hand.Cards).Should().Be(HandRank.HighCard);

    }

    [Fact]
    public void CanScoreFlush()
    {
      Hand hand = new Hand();
      hand.Draw(new Card(CardValue.Two, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Three, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Five, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Six, CardSuit.Spades));
      //Assert.Equal(HandRank.Flush, hand.GetHandRank());
      Ranker.GetHandRank(hand.Cards).Should().Be(HandRank.Flush);
    }

    [Fact]
    public void CanScoreRoyalFlush()
    {
      Hand hand = new Hand();
      hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Queen, CardSuit.Spades));
      hand.Draw(new Card(CardValue.King, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));
      //Assert.Equal(HandRank.RoyalFlush, hand.GetHandRank());
      Ranker.GetHandRank(hand.Cards).Should().Be(HandRank.RoyalFlush);

    }

    [Fact]
    public void CanScorePair()
    {
      Hand hand = new Hand();
      hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
      hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Nine, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
      hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));


      Ranker.GetHandRank(hand.Cards).Should().Be(HandRank.Pair);
    }

    [Fact]
    public void CanScoreThreeOfAKind()
    {
      Hand hand = new Hand();
      hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
      hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Nine, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
      Ranker.GetHandRank(hand.Cards).Should().Be(HandRank.ThreeOfAKind);
    }

    [Fact]
    public void CanScoreFourOfAKind()
    {
      Hand hand = new Hand();
      hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
      hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
      Ranker.GetHandRank(hand.Cards).Should().Be(HandRank.FourOfAKind);

    }

    [Fact]
    public void CanScoreFullHouse()
    {
      Hand hand = new Hand();
      hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
      hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Jack, CardSuit.Hearts));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
      Ranker.GetHandRank(hand.Cards).Should().Be(HandRank.FullHouse);

    }

    [Fact]
    public void CanScoreStraight()
    {
      var hand = new Hand();
      hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
      hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Queen, CardSuit.Spades));
      hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
      hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));

      Ranker.GetHandRank(hand.Cards).Should().Be(HandRank.Straight);
    }

    [Fact]
    public void CanScoreStraightThatContainsTwo()
    {
      var hand = new Hand();
      hand.Draw(new Card(CardValue.Four, CardSuit.Clubs));
      hand.Draw(new Card(CardValue.Five, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Two, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Six, CardSuit.Hearts));
      hand.Draw(new Card(CardValue.Three, CardSuit.Spades));

      Ranker.GetHandRank(hand.Cards).Should().Be(HandRank.Straight);
    }

    [Fact]
    public void CanScoreStraightUnordered()
    {
      var hand = new Hand();
      hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Queen, CardSuit.Clubs));
      hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
      hand.Draw(new Card(CardValue.King, CardSuit.Hearts));

      Ranker.GetHandRank(hand.Cards).Should().Be(HandRank.Straight);
    }

    [Fact]
    public void CanScoreTwoPair()
    {
      var hand = new Hand();
      hand.Draw(new Card(CardValue.Ace, CardSuit.Clubs));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Nine, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
      hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));

      Ranker.GetHandRank(hand.Cards).Should().Be(HandRank.TwoPair);

    }
  }
}