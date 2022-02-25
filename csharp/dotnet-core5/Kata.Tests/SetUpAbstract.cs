using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Kata.Tests
{
  public abstract class SetUpAbstract
  {
    protected int total;
    protected Mock<IDisplay> displayMock;
    protected ICheckout checkout;
    protected Dictionary<string, int> priceList = new Dictionary<string, int>()
    {
      {"A", 50},
      {"B", 30},
      {"C", 20},
      {"D", 15}
    };

  protected SetUpAbstract()
    {
      this.displayMock = new Mock<IDisplay>(); 
      this.displayMock.Setup(d => d.ShowSubTotal(It.IsAny<int>())).Callback<int>(t => this.total = t);
      this.checkout = new Checkout(this.displayMock.Object, priceList);

    }
  }
}
