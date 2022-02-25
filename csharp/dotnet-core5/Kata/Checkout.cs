using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
  public class Checkout :ICheckout
  {
    private readonly IDisplay display;
    private readonly Dictionary<string, int> priceList;

    public Checkout(IDisplay display, Dictionary<string, int> priceList)
    {
      this.display = display;
      this.priceList = priceList;
    }

    public void Scan(string item)
    {
      display.ShowSubTotal(priceList[item]);
    }
    
  }
}
