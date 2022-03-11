using FluentAssertions;
using Xunit;

namespace Kata.Tests
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
    public void Total_ShouldBe180()
    {
      this.total.Should().Be(180);
    } 
  }
}