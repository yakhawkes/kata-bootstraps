using FluentAssertions;
using Xunit;

namespace CsharpPoker.Tests
{
  public class CardTests
  {
    [Fact]
    public void CanCreateCard()
    {
      Card card = new Card(CardValue.Ace, CardSuit.Clubs);

      Assert.NotNull(card);
      card.Should().NotBeNull();
    }

    [Fact]
    public void ValuesSetViaConstructorAreCorrect()
    {
      Card card = new Card(CardValue.Ace, CardSuit.Clubs);

      //Assert.Equal(CardSuit.Clubs, card.Suit);
      //Assert.Equal(CardValue.Ace, card.Value);
      card.Suit.Should().Be(CardSuit.Clubs);
      card.Value.Should().Be(CardValue.Ace);
    }

    [Fact]
    public void CanDescribeCard()
    {
      CardValue cardValue = CardValue.Ace;
      CardSuit cardSuit = CardSuit.Spades;

      Card card = new Card(CardValue.Ace, CardSuit.Spades);

      //Assert.Equal("Ace of Spades", card.ToString());
      card.ToString().Should().Be($"{cardValue} of {cardSuit}");

    }
  }
}