using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
  public class Checkout : ICheckout
  {
    private readonly IDisplay display;
    private readonly Dictionary<string, int> priceList;
    private int subTotal;
    private List<string> basket = new List<string>();
    private readonly Dictionary<string, (int Count, int Discount)> discountList;

    public Checkout(IDisplay display, Dictionary<string, int> priceList, Dictionary<string, (int Count, int Discount)> discountList)
    {
      this.display = display;
      this.priceList = priceList;
      this.discountList = discountList;
    }

    public void Scan(string item)
    {
      this.basket.Add(item);
      this.subTotal = basket.Sum(a => this.priceList[a]);

      this.subTotal -= discountList.Sum(x=> this.GetDiscount(x));

      this.display.ShowSubTotal(this.subTotal);
    }

    private int GetDiscount(KeyValuePair<string, (int Count, int Discount)> discountRule)
    {
      return (this.basket.Count(sku => sku.Equals(discountRule.Key)) / discountRule.Value.Count) * discountRule.Value.Discount;
    }
  }
}
