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
    public void Total_ShouldBe20()
    {
      this.total.Should().Be(this.priceList["C"]);

    }
  }
}
