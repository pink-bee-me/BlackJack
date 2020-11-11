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
            //Lambda Expression section
            Deck deck = new Deck();

            int count = deck.Cards.Count(x => x.Face == Face.Ace);

            List<Card> newList = deck.Cards.Where(x => x.Face == Face.King).ToList();

            List<int> numberList = new List<int>() { 1, 2, 3, 535, 342, 23 };
            int sum = numberList.Where(x => x > 20 ).Sum();
            Console.WriteLine(sum);
            Console.ReadLine();
        // Lambda expression sECTION



            Card card1 = new Card();
            Card card2 = card1;
            card1.Face = Face.Eight;
            card2.Face = Face.King;

            Console.WriteLine("Card 1 = " + card1.Face);
            Console.WriteLine("Card 2 = " + card2.Face);
            Console.ReadLine();

            Game game = new BlackJackGame();
            game.Players = new List<Player>(); // instanciating the Players List in this game so that I can add a player to the list
            Player player = new Player(); // adding new player object to the Players List
            player.Name = "Jesse";
            game += player; // used operator overloading concept to add player to the game
            game -= player; // used operator overloading to remove a player from the game
            Deck deck = new Deck();
            

            foreach (Card card in deck.Cards)                       //foreach loop used to display the deck of cards on the console
            {
                Console.WriteLine(card.Face + " of " + card.Suit); //format the way to display the cards
            }
            Console.WriteLine(deck.Cards.Count);                   //actually write to console the count of cards in the deck ( should be 52 /deck;
            Console.ReadLine();




           
        // Notes Section:

            // example of polymorphism; you do this so that you can have all the different games as the same type; you can also polymorph 
            
            // game = game + player can be written as "game += player"
            // game = game - player same as "game -= player"
            
            // Deck deck = new Deck();  creates deck of cards / instantiate a  new deck object
            // deck.Shuffle(3); shuffles that deck 3 times
           

            // deck.Shuffle(3); //Shuffle method called , with out param used to keep track of how many times shuffled,  and 3 for  three times to shuffle deck

            
        }

        

       
    }
}
