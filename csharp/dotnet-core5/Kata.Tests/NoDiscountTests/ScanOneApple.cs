using FluentAssertions;
using Moq;
using Xunit;

namespace Kata.Tests.NoDiscountTests
{
  public class ScanOneApple : SetUpAbstract
  {
    public ScanOneApple()
    {
      this.checkout.Scan("A");
    }

    [Fact]
    public void ShowSubTotal_ShouldBeInvokedOnce()
    {
      this.displayMock.Verify(display => display.ShowSubTotal(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void Total_ShouldBePriceOfAFromPriceList()
    {
      this.total.Should().Be(this.priceList["A"]); 
      
    }
  }
}
