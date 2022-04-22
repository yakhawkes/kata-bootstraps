using FluentAssertions;
using Xunit;

namespace Kata.Tests.NoDiscountTests
{
  public class ScanFourApples : SetUpAbstract
  {
    public ScanFourApples()
    {
      this.checkout.Scan("A");
      this.checkout.Scan("A");
      this.checkout.Scan("A");
      this.checkout.Scan("A");
    }

    [Fact]
    public void Total_ShouldBePriceOfAFromPriceListFourTimes()
    {
      this.total.Should().Be(priceList["A"] * 4);
    } 
  }
}