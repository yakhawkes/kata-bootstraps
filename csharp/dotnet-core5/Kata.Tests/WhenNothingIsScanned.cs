using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Kata.Tests.NoDiscountTests;
using Moq;
using Xunit;

namespace Kata.Tests
{
  public class WhenNothingIsScanned: SetUpAbstract
  {
    [Fact]
    public void ShowSubTotal_ShouldBeNeverInvoked()
    {
      this.displayMock.Verify(display => display.ShowSubTotal(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
    }
  }
}
