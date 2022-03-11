using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

namespace Kata.Tests
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
      this.displayMock.Verify(display => display.ShowSubTotal(It.IsAny<int>()), Times.Once);
    }
    [Fact]
    public void Total_ShouldBePriceOfDFromPricelist()
    {
      this.total.Should().Be(this.priceList["D"]);

    }
  }
}
