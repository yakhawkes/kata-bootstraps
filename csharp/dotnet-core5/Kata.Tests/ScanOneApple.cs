using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

namespace Kata.Tests
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
    public void Total_ShouldBePriceOfAFromPricelist()
    {
      this.total.Should().Be(this.priceList["A"]); 
      
    }
  }
}
