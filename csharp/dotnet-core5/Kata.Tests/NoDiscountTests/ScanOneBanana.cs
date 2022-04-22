using FluentAssertions;
using Moq;
using Xunit;

namespace Kata.Tests.NoDiscountTests
{
  public class ScanOneBanana :SetUpAbstract
  {
    public ScanOneBanana()
    {
      this.checkout.Scan("B");
    }

    [Fact]
    public void ShowSubTotal_ShouldBeInvokedOnce()
    {
      this.displayMock.Verify(display => display.ShowSubTotal(It.IsAny<int>()), Times.Once);
    }
    [Fact]
    public void Total_ShouldBePriceOfBFromPriceList()
    {
      this.total.Should().Be(this.priceList["B"]);
    }
  }
}
