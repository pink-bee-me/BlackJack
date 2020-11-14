using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class TwentyOneRules // business logic layer ( holds methods that are essentially the rules of the game)
    {
        private static Dictionary<Face, int> _cardValues = new Dictionary<Face, int>()
        {
            [Face.Two] = 2,
            [Face.Three] = 3,
            [Face.Four] = 4,
            [Face.Five] = 5,
            [Face.Six] = 6,
            [Face.Seven] = 7,
            [Face.Eight] = 8,
            [Face.Nine] = 9,
            [Face.Ten] = 10,
            [Face.Jack] = 10,
            [Face.Queen] = 10,
            [Face.King] = 10,
            [Face.Ace] = 1,
        };

        private static int[] GetAllPossibleHandValues(List<Card> Hand) // aces can equal (1) or (11), this is where we are checking our hand and dealing with this issue
        {


            /* Explanation of Lanbda Expression:
              - (x) is used to represent each item in the Hand list 
                ( in this case, that would be each Card in the Hand)
              - then, it says we will check what the Face value of each item is (x.Face)...
              - then, we will see if the Face value of that card is an Ace ( == Face.Ace) 
              - then, however many of them are Aces, that number (or value) 
                is stored in the int variable aceCount that we just created*/

            int aceCount = Hand.Count(x => x.Face == Face.Ace);

            int[] result = new int[aceCount + 1]; /* we then can create result[] which is aceCount plus 1
                                                    ( if there are two card there are three possibilities:
                                                        one Ace = 1 or 11; two Aces = 1+11  and two Aces 1+1 or 11+11; two Aces: one Ace = one and one Ace = 11*/
            int value = Hand.Sum(x => _cardValues[x.Face]);
            result[0] = value;
            if (result.Length == 1)
            {
                return result;
            }
            for (int i = 1; i < result.Length; i++)
            {
                value += (i * 10); //value is the lowest possible "value"
                result[i] = value;
            }
            return result;
        }

        public static bool CheckForBlackJack(List<Card> Hand)
        {
            int[] possibleHandValues = GetAllPossibleHandValues(Hand);
            int value = possibleHandValues.Max();
            if (value == 21) return true; //then "yes" player has BlackJack!! 
            else return false;
        }

        public static bool IsBusted(List<Card> Hand)
        {
            int value = GetAllPossibleHandValues(Hand).Min();
            if (value > 21) return true;
            else return false;
        }

        public static bool ShouldDealerStay(List<Card> Hand)
        {
            int[] possibleHandValues = GetAllPossibleHandValues(Hand);
            foreach (int value in possibleHandValues)
            {
                if (value > 16 && value < 22)
                {
                    return true;
                }
            }
            return false;
        }


        // a bool method can return three values ( as a struct it can return true , false, and null)
        // the syntax for this usage : < bool? > (example below; we are using the null value to represent a tie between the players' hands and dealer's hand)
        public static bool? CompareHands(List<Card> PlayerHand, List<Card> DealerHand)
        {
            int[] playerResults = GetAllPossibleHandValues(PlayerHand);
            int[] dealerResults = GetAllPossibleHandValues(DealerHand);

            int playerScore = playerResults.Where(x => x < 22).Max();
            int dealerScore = dealerResults.Where(x => x < 22).Max();

            if (playerScore > dealerScore) return true;
            if (playerScore < dealerScore) return false;
            else return null;
        }
    }
}
