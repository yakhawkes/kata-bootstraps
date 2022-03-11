using FluentAssertions;
using Xunit;

namespace Kata.Tests
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
    public void Total_ShouldBe130()
    { 
      this.total.Should().Be(130);
    }
  }
}