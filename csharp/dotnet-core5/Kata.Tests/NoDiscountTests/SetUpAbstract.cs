using System.Collections.Generic;
using Moq;

namespace Kata.Tests.NoDiscountTests
{
  public abstract class SetUpAbstract
  {
    protected int total;
    protected int discountAmount;
    protected Mock<IDisplay> displayMock;
    protected ICheckout checkout;
    protected Dictionary<string, int> priceList = new Dictionary<string, int>()
    {
      {"A", 50},
      {"B", 30},
      {"C", 20},
      {"D", 15}
    };

    protected Dictionary<string, (int Count, int Discount)> discountList = new Dictionary<string, (int Count, int Discount)>()
    {
    };

  protected SetUpAbstract()
    {
      this.displayMock = new Mock<IDisplay>();
      this.displayMock.Setup(d => d.ShowSubTotal(It.IsAny<int>(), It.IsAny<int>())).Callback<int, int>((t, s) => this.total = t);
      this.checkout = new Checkout(this.displayMock.Object, priceList, discountList);
    }
  }
}
