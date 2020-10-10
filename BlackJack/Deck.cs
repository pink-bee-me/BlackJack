using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    //CREATING A DECK OF CARDS
    public class Deck
    {
        public Deck()
        {//Cards = new List<Card>();
         //Card cardOne = new Card();
         //cardOne.Face = "Two";
         //cardOne.Suit = "Hearts";
         //Cards.Add(cardOne);

            //BETTER WAY WITH "NESTED FOREACH LOOP"

            //This is a constructor in the Deck Class * it is a method that is called as soon as an object is created

            Cards = new List<Card>(); //Fisrt thing it does: Instanciate its property of "Cards" as an empty list;
            //This "Cards" is referring to the property that already exist as part of the class "Deck", so you don't say it is a string type or whatever because it is not a variable it is a property of the class Deck
            List<string> Suits = new List<string>() //Then it Creates Two More Lists:  Suits and Faces and immediately instanciates the lists with values
            {
                "Clubs", "Hearts", "Diamonds", "Spades"
            };

            List<string> Faces = new List<string>()
            {
                "Two", "Three", "Four", "Five", "Six", "Seven",
                "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"
            };
            // you end up with a big list (Cards), made up of two smaller lists (Suits and Faces); Suits with 4  ( spades,hearts,etc....) and Faces with 13 ( 1,,2,3,...jack,queen,...ace); put those together you get 52 cards in the Cards List
            foreach (string face in Faces) //for each of these items (face) in the Faces List 
            {
                foreach (string suit in Suits) // we loop through four times one for each suit in the Suits List
                {
                    Card card = new Card(); // we create a new card
                    card.Suit = suit; // we assign a suit value to the new card
                    card.Face = face;// we assign a face value to the new card
                    Cards.Add(card); //then we add this newly created card to the Cards List Property in the Deck class 
                }
            }
        }// once this loop ends this variable card doesnt exist anymore.






        // Deck class has one property called List<Card> Cards
        public List<Card> Cards { get; set; }

        public void Shuffle(int times = 1) // create SHUFFLE METHOD 
        {
            for (int i = 0; i < times; i++)
            {
                List<Card> TempList = new List<Card>();
                Random random = new Random();

                while (Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, Cards.Count);
                    TempList.Add(Cards[randomIndex]);
                    Cards.RemoveAt(randomIndex);
                }
                Cards = TempList;


            }
        }
    }
}
