using FluentAssertions;
using Xunit;

namespace Kata.Tests.NoDiscountTests
{
  public class ScanThreeApples : SetUpAbstract
  {
    public ScanThreeApples()
    {
      this.checkout.Scan("A");
      this.checkout.Scan("A");
      this.checkout.Scan("A");
    }
    
    [Fact]
    public void Total_ShouldBePriceOfAFromPriceListTimesThree()
    { 
      this.total.Should().Be(priceList["A"] * 3);
    }
  }
}