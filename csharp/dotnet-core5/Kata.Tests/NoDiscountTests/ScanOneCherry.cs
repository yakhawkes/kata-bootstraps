using FluentAssertions;
using Moq;
using Xunit;

namespace Kata.Tests.NoDiscountTests
{
  public class ScanOneCherry :SetUpAbstract
  {
    public ScanOneCherry()
    {
      checkout.Scan("C");
    }

    [Fact]
    public void ShowSubTotal_ShouldBeInvokedOnce()
    {
      this.displayMock.Verify(display => display.ShowSubTotal(It.IsAny<int>()), Times.Once);
    }
    [Fact]
    public void Total_ShouldBePriceOfCFromPriceList()
    {
      this.total.Should().Be(this.priceList["C"]);

    }
  }
}
