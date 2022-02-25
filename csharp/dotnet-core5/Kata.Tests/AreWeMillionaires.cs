using FluentAssertions;
using Moq;
using Xunit;

namespace Kata.Tests
{
  public class AreWeMillionaires
  {
    private ICheckout checkout;
    private int total;
    private readonly Mock<IDisplay> DisplayMock;

    public AreWeMillionaires()
    {
      // Arrange
      DisplayMock = new Mock<IDisplay>();
      DisplayMock.Setup(d => d
                   .ShowSubTotal(It.IsAny<int>()))
                 .Callback<int>(t => total = t);
      // Act
      // checkout.Scan("A");
    }

    [Fact]
    public void Yet()
    {
      // Assert
      total.Should().Be(100000, "we are millionaires!");
    }
  }
}