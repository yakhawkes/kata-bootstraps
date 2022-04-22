using FluentAssertions;
using Xunit;

namespace Kata.Tests.DiscountTests
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
    public void Total_ShouldApplyCorrectDiscount()
    {
      int discount = 4 / discountList["A"].Count * discountList["A"].Discount;
      this.total.Should().Be(priceList["A"] * 4 - discount);
    } 
  }
}