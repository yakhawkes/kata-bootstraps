using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Kata.Tests.NoDiscountTests
{
  /*
           z$
         z$$F
        d$$$
       $$$$$
      J$$$$$
      $$$$$$
     .$$$$$$
     $$$$$$$b
    $$$$$$$$$c
   J$$$$$$$$$$$c
   $$$$ "$$$$$$$$$.
  $$$$P    "*$$$$$"                     .ze$$$$$bc
 .$$$$F                              z$$$$$$$$$$$$$b
 $$$$$                           .e$$$$$$$$$$$$$$$$$$.
 $$$$$                         z$$$$$$$$$$$$$$$$""$$$$
4$$$$$F                     .$$$$$$$$$$$$$$$$$$$  $$$$r
$$$$$$$                   z$$$$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$c                e$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
'$$$$$$$c            .d$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
 $$$$$$$$b          d$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
  *$$$$$$$$r      d$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ Gilo94'
      """"""      """"""""""""""""""""""""""""""""""""
   */
  public class ScanMixedBaskets : SetUpAbstract
  {
    [Theory]
    [InlineData("A", "B")]
    [InlineData("A","B","C", "D")]
    [InlineData("A","B","C", "D", "D")]
    [InlineData("A", "A", "C", "A", "D")]
    [InlineData("A", "A", "A", "B", "B", "A", "D", "B", "A", "B", "C", "C")]
    public void ScanProducts(params string[] skus)
    {
      int expectedTotal = 0;
      foreach (string sku in skus)
      {
        this.checkout.Scan(sku);
        expectedTotal += priceList[sku];
      }

      this.total.Should().Be(expectedTotal);
    }
  }
}
