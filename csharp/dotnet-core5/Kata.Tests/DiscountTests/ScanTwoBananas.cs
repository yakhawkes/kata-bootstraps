using FluentAssertions;
using Xunit;

/*
 *
──────────▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
────────█═════════════════█
──────█═════════════════════█
─────█════════▄▄▄▄▄▄▄════════█
────█════════█████████════════█
────█═══════██▀─────▀██═══════█
───███████████──█▀█──███████████
───███████████──▀▀▀──███████████
────█═══════▀█▄─────▄█▀═══════█
────█═════════▀█████▀═════════█
────█═════════════════════════█
────█══════▀▄▄▄▄▄▄▄▄▄▀════════█
───▐▓▓▌═════════════════════▐▓▓▌
───▐▐▓▓▌▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▐▓▓▌▌
───█══▐▓▄▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▄▓▌══█
──█══▌═▐▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▌═▐══█
──█══█═▐▓▓▓▓▓▓▄▄▄▄▄▄▄▓▓▓▓▓▓▌═█══█
──█══█═▐▓▓▓▓▓▓▐██▀██▌▓▓▓▓▓▓▌═█══█
──█══█═▐▓▓▓▓▓▓▓▀▀▀▀▀▓▓▓▓▓▓▓▌═█══█
──█══█▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█══█
─▄█══█▐▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▌█══█▄
─█████▐▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▌─█████
─██████▐▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▌─██████
──▀█▀█──▐▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▌───█▀█▀
─────────▐▓▓▓▓▓▓▌▐▓▓▓▓▓▓▌
──────────▐▓▓▓▓▌──▐▓▓▓▓▌
─────────▄████▀────▀████▄
─────────▀▀▀▀────────▀▀▀▀
 wooooooooooooooooooooooooooooot
*/

namespace Kata.Tests.DiscountTests
{
  public class ScanTwoBananas : SetUpAbstract
  {
    public ScanTwoBananas()
    {
      this.checkout.Scan("B");
      this.checkout.Scan("B");
    }
    
    [Fact]
    public void SubTotal_ShouldApplyCorrectTotalAmount()
    {
      int discount = 2 / discountList["B"].Count * discountList["B"].Discount;
      this.total.Should().Be(priceList["B"] * 2 - discount);
    }

    [Fact]
    public void SubTotal_ShouldApplyCorrectDiscount()
    {
      int discount = 2 / discountList["B"].Count * discountList["B"].Discount;
      this.discountAmount.Should().Be(discount);
    }
  }
}
