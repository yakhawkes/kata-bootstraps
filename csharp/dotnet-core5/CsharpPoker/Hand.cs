﻿using System.Collections.Generic;
using System.Linq;

/*
 * ⠀⠀⠀⠀⠀⠀⠀⢠⣞⣛⣿⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣴⠟⠉⢸⣿⣷⡈⠛⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⣰⡞⠛⢿⡇⠀⠀⣰⣟⣿⣾⢶⡄⢻⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣤⡶⠶⠶⠶⠶⠤⣤⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⢿⡀⢀⣼⣧⡀⠀⠻⠏⠁⠉⠛⠁⠀⡟⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣴⠟⠋⠁⠀⣀⣤⣤⣤⣤⣄⣀⠈⠙⠻⢶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠈⣻⡿⠗⠀⠉⣳⣄⠀⠀⠀⠀⠀⣼⡥⠟⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣋⣀⡶⢶⣶⡿⢋⣡⠴⠖⠶⢤⣍⠳⣦⠀⠀⠈⠙⢷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⢀⡾⠁⠀⠀⠀⢸⡏⠙⢷⡤⠤⠴⣞⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⠟⠲⠦⣼⣥⣿⠏⣠⣟⣷⡄⠀⠀⠀⠘⢷⡌⢳⣠⣤⡶⠶⠿⠷⢤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⣸⡇⠀⠀⠀⠀⠀⠛⣶⠾⣧⣀⢀⣼⠇⠀⠀⠀⠀⠀⠀⠀⠀⣸⡏⠛⠓⢶⣯⣿⡏⢠⡿⣿⣿⠃⠀⠀⠀⠀⠘⣿⠀⠋⣁⡤⠖⠒⠲⢶⣌⠻⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⡾⠁⠳⣄⠀⠀⠀⠀⢠⡟⠀⠉⢹⣏⠁⠀⠀⠀⠀⠀⠀⠀⠀⢠⡿⠀⠀⠀⠀⠉⣿⣇⠸⣟⠛⠋⠀⠀⠀⠀⠀⢠⣿⠀⣼⡛⣦⠀⠀⠀⠀⢹⣷⡘⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠻⢦⡴⠏⢹⡓⠒⢺⡏⠙⢷⡴⣏⡉⠛⢦⣄⡀⠀⠀⠀⠀⢠⣾⠁⠀⠀⠀⠀⠀⠘⣿⡄⠹⣆⠀⠀⠀⠀⠀⣠⡾⠃⢸⠿⣿⡿⠀⠀⠀⠀⠀⣿⡇⢻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠘⣧⣀⣠⡷⠀⠀⠀⠈⠙⢦⣄⠈⠙⠳⢦⣄⣰⡋⠘⣦⠀⠀⠀⠀⠀⠀⠘⠿⣦⣌⠙⠒⠶⠶⠚⢋⣠⡄⠸⡟⠉⠁⠀⠀⠀⠀⢀⣿⠃⣾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠈⠉⠉⠀⠀⠀⠀⠀⠀⠀⠉⠛⠶⣤⣀⠀⣸⢻⡄⠈⢧⡀⠀⠀⠀⢸⣻⣦⣄⠈⠙⠛⠒⠒⠛⠉⠙⣿⣄⠹⣦⡀⠀⠀⠀⣠⡾⢋⣴⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⣷⡏⠀⠻⡄⠈⢳⡀⠀⠀⢸⣏⠳⣬⣷⢦⣄⠀⠀⠀⠀⠀⠈⠻⢷⣄⡉⠙⠛⢉⣁⣴⠞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡟⠀⠀⠀⠹⣆⢀⣳⣤⣀⠀⠹⣦⡀⠈⠓⠮⢿⡦⣤⣀⡀⠀⠀⠀⠈⠉⠉⠉⠉⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⠁⠀⠀⠀⢀⡿⣿⣽⡿⠈⠛⠦⣄⡙⠲⢤⣄⣀⠉⠛⣻⣽⠇⠀⠀⠀⠀⠀⠀⣸⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠛⠶⣄⣀⣠⡟⠀⠈⠋⠀⠀⣠⣀⠀⠉⠛⠲⢤⣍⣉⡉⠉⠀⠀⠀⠀⠀⠀⠀⣠⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡄⠀⢀⣽⠋⠀⠀⠀⠀⠀⡾⠃⠈⠙⠲⢤⣀⡀⠀⡈⠉⠉⣳⣶⡤⠶⠒⠛⢉⣹⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⠛⠋⠁⠀⠀⠀⠀⠀⠸⣇⠀⠀⠀⠀⠀⠀⢉⡽⠃⠀⠀⣿⣧⣿⠤⠖⠛⠉⠉⠻⢦⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣧⣀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠲⠦⢤⣤⠴⠛⠁⠀⠀⠀⢠⡟⠀⠀⠀⣴⠶⠶⣤⣀⠀⠉⠛⠲⠦⣤⣀⣀⠀⠀⣀⡤⣄⣀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⠿⣦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣟⠀⠀⠀⣼⠇⠀⠀⠀⠉⠛⠳⠦⣤⣄⣀⢉⡿⢻⠋⠋⣀⡼⠉
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠉⠛⠶⣤⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡟⠈⠉⠙⢻⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠿⠷⠾⣄⣠⣿⣶⠞
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡞⠳⠦⢴⡞⠋⠉⠙⠛⠻⣶⣤⣤⣀⡀⠀⠀⠀⠀⠻⢤⣤⡶⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠁⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠧⠤⠶⠋⠀⠀⠀⠀⠀⠀⢹⡀⢈⣉⣉⣛⣿⣷⣶⠖⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣛⣻⠽⠟⠓⣻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣯⣽⣿⠖⠒⠚⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
 */
// WHERE IS THE BUTCHER???
// This is poker, no weapons allowed!
// No, this is patrick.

/*
 *                                                                                                                         
                                                                               .                                        
                                                                             ::                                         
                                                                           ::    :.                                     
                                                              .::        .+.   ::                                       
                                                    ..         .--.      *    =       ..                                
                                                   ..:::        =.::    +:   +      :::..                               
                                                      ::+:       # :=  .%   #     -+::                                  
                                               ..:::.   :*+    ..+::++:-=..-*    +*.   .::::.                           
                                              ..    .-=+::*+-----::--*::::::::::=-  ---.    ..                          
                                                .::::  -*===-:::::::::::::::::::::-+.  ::::.                            
                                                ...  +==--::::::::::::::::::::::::::::=  ...                            
                                                  .=*=--::::::::::::::::::::::::::::::-=:.                              
                                                  ==---:::::::::::::::::::::::::::::::::::                              
                                                .=----:::::::::::::::::::::::::::::::::::::                             
                                               .=-------------------::::-------:::::::::::::                            
                                               ==--==+++**##%##++++=====+=+++***#%%#*+-::::::                           
                                              -==+#=-.:-----=*##**+###%%%#+=:---==++**+**=-:::                          
                                             -==*-.---=*#%%%#***+==##%@%=.----+*#%%#**+=--==-:.                         
                                            .=++ =--*#*+++**#%@@%**++*::=-:++:...--=+#@@++-.+=-                         
         .                                  -=* *.%%-          .+%-*@%%= #%:           :+:-+ =-.                        
       =@@%-                               :=@-*.%@#:            +. *@@ *@%: :+*=:      :. -- *-.                       
      *@@@@@+                             .%*@=*:@@+:    =*%#=     ..@# @@#:*@@@@@=         + +.=                       
     %@@@@@@@-                           =@@#@@*:%+:..  *@@@@%%   :=:@# @%*-%@@@@@*.....::-:+ =:@@=                     
     =%@@@@@@@                           *@@==*% #+:.   +@@@@@#..=#+*@@ #@@%%#**+++==--+*%#:= .-#@*                     
     -.%@@@@@@=                          #@@==-=*.@@@%%**###**+++#*-@@@= %@@%##*+++====+##:+  +=%@#                     
      + %@@@@@%                          .+##%+--+=#@@%%##*+++++*-=+: .-=:+@@%##**++++**=--  :====.                     
      ::.@@@@@@=                          =++***=-==+*#%@%%**=-=--..+#%*----+*%%%%#*+==-- .:-:::::                      
       + =@@@@@@.                         ===+**#+==--==-------..=+@@@@@%#*=-=--==----..::::::::::                      
        + %@@@@@#                         ===++**#%#*#+*#****##%@@#%%@@@@%@@@%#**+++==+=--::::::::                      
        :-.@@@@@@+                        ==++++**#%%@@%%%%#%@%%#*+++++**#%%%%@%**++=-::::::::::::                      
         =.-@@@@@@-                       ==++++++****###%%##**+==---------======--:::::::::::::::                      
          +.+@@@@@@                      .+++++++++++++*****++=----:::::::::::::::::::::::::::::::                      
          .*:#@@@@@#                     :++++++++=+++++++++==--------=---:------:::::::::::::::::.                     
           .+=@@@@@@=                    -*+++++++==+=+..:.          =+             .=-:::::::::::=                     
            -=#@@@@@@:                   .:***+*++====#**%#****#*===*@@*===*#****##**#-:::::::::-.                      
             +*@@@@@@@:                 :*::+#***+===+=#%%#+-.:+*=-=*@@-   -#****%%%*-::::::::=-  .:                    
              *@@@@@@@@@:             :+**%=::#%**++=+++==-:..       --       ..::--::::::::-+.  :::.                   
              .%@@@@@@@@@**=:      :-+++**#%*-=+%#*+++++===--:----------------::::::::::::-+-  ::::::                   
               .@@@@@@@@@@@@@*.:-=+===+*#%%%%%*::#%**++====--:::::::::::::::::::::::::::-==  .:::::::                   
                :@@@@@@@@@@@@#====++*#%@@@@%%%%#=.=%%*+++==---::::::+**+:::::::::::::::-+.  :::---:::.                  
                 :#@@@@@@@@@@#+*##%#**+-:. .###%+  .=%#**++=--:::::-#@@=::::::::::::-=+-   :::-##+-:::                  
                  :@@@@@@@@@@@=-:           +**#%.    -*%##*+=---::=#@@-:::::::::--+=:    .:::-%@#=-::                  
                   .%@@@@@@@@%              =***#-     ..=+*#*+==---=+=::::::-----:       ::::=.%@*-::.                 
                     =%@@@@@@@-             :***#-    -+    .::-===--------::.            ::::= :@%=::.                 
                       .==+@@@#             :****-    .=:                                 ::::-  *@*-::                 
                           +#%-             -**##+    -:                                  ::::-.  @#-::                 
                                           .*###%+                                        ---==+  +@+::.                
                                           =@@@@@#...                                     @@@@@@: .@#-:.                
                                           *@@@@@#                                        @@@@@@=  %%=::                
                                           %@@@@@#                                        @@@@@@+  +@+::                
                                           @@@@@@#                                        @@@@@@#  -@*::.               
                                           @@@@@@#                                        @@@@@@*  :@#-::               
                                           *@@@@@#         .                              @@@@@@=   @#-::               
                                           =@@@@@#                                        @@@@@@.   @%+-:.              
                                            %@@@@+       .          ..         .         .%@@@@*   :@@%*++:             
                                            :@@@@=       . .                              *@@@%   *@@@@@@@:             
                                              #@@:           .:.                          =@@#    +@@@@@@#              
                                               =@.   .      ..                            -%= .+*#@@@@@@@:              
                                                   ....     ..    ..                         -@@@@@@@@@@#               
                                                   .::..        ...:: .   ..                 -@@@@@@@@@@=               
                                                  .         ..          .-*+      .:      .   =**+*@@@@@=               
                                                . .     ..             .-::#.    .        .       .@@@@@+               
                                                ...                       .*    =+:  ..           :@@@@@+               
                                                .*@@@%##+=..        .-..  :%. ...:=+*#%@@@+       :@@@@@:               
                                      ...::---==%@@@@@@@@@%%@@%%##***#****#@%@@@%%@@@@@@@%*#=--::.-@@@@=                
                                 .::--=++*##%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%+**%@@@%%#%%#=:.               
                                 ..::--=++**##%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%%%###**+=-:                 
                                           ....:::-----=========++++==+=======-----::::....                             
                                                                                                                        

 */

namespace CsharpPoker
{
  public class Hand
  {
    public Hand()
    {
      Cards = new List<Card>();
    }

    public List<Card> Cards { get; }

    public void Draw(Card card) => Cards.Add(card);

    public Card HighCard()
      => Cards.Aggregate((highCard, nextCard)
        => nextCard.Value > highCard.Value
          ? nextCard
          : highCard); //return Cards.OrderByDescending(x => x.Value).First();

    public HandRank GetHandRank() =>
      FiveCardPokerScorer.IsRoyalFlush(Cards) ? HandRank.RoyalFlush :
      FiveCardPokerScorer.IsFourOfAKind(Cards) ? HandRank.FourOfAKind :
      FiveCardPokerScorer.IsFullHouse(Cards) ? HandRank.FullHouse :
      FiveCardPokerScorer.IsFlush(Cards) ? HandRank.Flush :
      FiveCardPokerScorer.IsStraight(Cards) ? HandRank.Straight :
      FiveCardPokerScorer.IsThreeOfAKind(Cards) ? HandRank.ThreeOfAKind :
      FiveCardPokerScorer.IsPair(Cards) ? HandRank.Pair :
      HandRank.HighCard;

    // We leave this out for now, as there is no need to implement this. The TwoPairs-test will come later in the tutorial. We will then do a big refactoring :) 
    //private int CountOfAKind(int num) => cards.ToKindAndQuantities().Count(c => c.Value == num);
  }
}