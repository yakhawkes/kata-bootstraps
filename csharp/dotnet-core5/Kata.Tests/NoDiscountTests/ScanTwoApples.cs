using FluentAssertions;
using Moq;
using Xunit;

namespace Kata.Tests.NoDiscountTests
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
      this.displayMock.Verify(display => display.ShowSubTotal(It.IsAny<int>(),It.IsAny<int>()), Times.Exactly(2));
    }

    [Fact]
    public void Total_ShouldBePriceOfAFromPriceListTimesTwo()
    {
      this.total.Should().Be(this.priceList["A"] * 2);
    }
  }
}