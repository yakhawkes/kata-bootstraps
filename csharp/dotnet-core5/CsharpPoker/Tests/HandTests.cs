﻿using System.Linq;
using Xunit;
using FluentAssertions;

namespace CsharpPoker.Tests
{
  // TODO Refactor all tests to use Fluent Assertions.
  // TODO To be continued https://edcharbeneau.com/csharp-functional-workshop-instructions/#chapter3.5
  public class HandTests
  {
    [Fact]
    public void CanCreateHand()
    {
      var hand = new Hand();
      Assert.False(hand.Cards.Any());
    }

    [Fact]
    public void CanHandDrawCard()
    {
      var card = new Card(CardValue.Ace, CardSuit.Spades);
      var hand = new Hand();

      hand.Draw(card);

      Assert.Equal(hand.Cards.First(), card);
    }

    [Fact]
    public void CanGetHighCard()
    {
      var hand = new Hand();
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
      var hand = new Hand();
      hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
      hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
      hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
      hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));

      Assert.Equal(HandRank.HighCard, hand.GetHandRank());
    }

    [Fact]
    public void CanScoreFlush()
    {
      var hand = new Hand();
      hand.Draw(new Card(CardValue.Two, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Three, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Five, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Six, CardSuit.Spades));
      Assert.Equal(HandRank.Flush, hand.GetHandRank());
    }

    [Fact]
    public void CanScoreRoyalFlush()
    {
      var hand = new Hand();
      hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Queen, CardSuit.Spades));
      hand.Draw(new Card(CardValue.King, CardSuit.Spades));
      hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));
      Assert.Equal(HandRank.RoyalFlush, hand.GetHandRank());
    }
  }
}