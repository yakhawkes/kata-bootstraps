using FluentAssertions;
using Moq;
using Xunit;

namespace Kata.Tests
{
  public class ScanTwoApples : SetUpAbstract
  {
    public ScanTwoApples()
    {
      this.checkout.Scan("A");
      this.checkout.Scan("A");
    }

    [Fact]
    public void ShowSubTotal_ShouldBeInvokedTwice()
    {
      this.displayMock.Verify(display => display.ShowSubTotal(It.IsAny<int>()), Times.Exactly(2));
    }

    [Fact]
    public void Total_ShouldBePriceOfAFromPricelistTimesTwo()
    {
      this.total.Should().Be(this.priceList["A"] * 2);
    }
  }
}