using FluentAssertions;
using Moq;
using Xunit;

namespace Kata.Tests.NoDiscountTests
{
  public class ScanOneDate :SetUpAbstract
  {
    public ScanOneDate()
    {
      checkout.Scan("D");
    }

    [Fact]
    public void ShowSubTotal_ShouldBeInvokedOnce()
    {
      this.displayMock.Verify(display => display.ShowSubTotal(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
    }
    [Fact]
    public void Total_ShouldBePriceOfDFromPriceList()
    {
      this.total.Should().Be(this.priceList["D"]);

    }
  }
}
