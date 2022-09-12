using System.Linq;
using Xunit;
using FluentAssertions;

namespace CsharpPoker.Tests
{
  public class HandTests
  {
    private readonly FiveCardPokerScorerTests fiveCardPokerScorerTests = new FiveCardPokerScorerTests();

    [Fact]
    public void CanCreateHand()
    {
      Hand hand = new Hand();
      //Assert.False(hand.Cards.Any());
      hand.Cards.Should().BeEmpty();
    }

    [Fact]
    public void CanHandDrawCard()
    {
      Card card = new Card(CardValue.Ace, CardSuit.Spades);
      Hand hand = new Hand();

      hand.Draw(card);

      //Assert.Equal(hand.Cards.First(), card);
      hand.Cards.First().Should().Be(card);
    }
  }
}