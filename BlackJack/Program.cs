using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
               Game game = new Game();
               game.Dealer = "Jesse";
               game.Name = "Twenty-One";
             Deck deck = new Deck();  //create deck of cards / instanciate a  new deck object
             deck.Shuffle(3); // shuffle that deck 3 times
           

           // deck.Shuffle(3); //Shuffle method called , with out param used to keep track of how many times shuffled,  and 3 for  three times to shuffle deck

            foreach (Card card in deck.Cards) //foreach loop used to display the deck of cards on the console
            {
                Console.WriteLine(card.Face + " of " + card.Suit); //format the way to display the cards
            }
            Console.WriteLine(deck.Cards.Count); //actually write to console the count of cards in the deck ( should be 52 /deck;
            Console.ReadLine();
        }



        
       // {
           // for (int i = 0; i< times; i++) 
           // {
        //
             //   deck = Shuffle(deck);
           // }
          //  return deck
      //  }
    }
}
