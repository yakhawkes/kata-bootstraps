using FluentAssertions;
using Xunit;

namespace Kata.Tests.DiscountTests
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
    public void Total_ShouldApplyCorrectDiscount()
    {
      int discount = 3 / discountList["A"].Count * discountList["A"].Discount;
      this.total.Should().Be(priceList["A"] * 3 - discount);
    }
  }
}