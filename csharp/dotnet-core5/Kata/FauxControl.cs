using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
  public class FauxControl
  {
    private readonly IGameScore game;

    public FauxControl(IGameScore game)
    {
      this.game = game;
    }
    
  }
}
