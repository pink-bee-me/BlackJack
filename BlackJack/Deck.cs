using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    //CREATING A DECK OF CARDS
    public class Deck
    {
        public Deck()
        {
          Cards = new List<Card>();

            for (int i = 0; i < 13; i++) // iterate through the Faces enum
            {
                for (int j = 0; j < 4; j++)// iterate through the Suits enum
                {
                    Card card = new Card();
                    card.Face = (Face)i;// casting Face to i
                    card.Suit = (Suit)j;
                    Cards.Add(card);
                }
            }
        }





        //Card cardOne = new Card();
        //cardOne.Face = "Two";
        //cardOne.Suit = "Hearts";
        //Cards.Add(cardOne);



        public void Shuffle(int times = 1)
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

        



        // Deck class has one property called List<Card> Cards
        public List<Card> Cards { get; set; }

        //public void Shuffle(int times = 1) // create SHUFFLE METHOD 
        //{
        //    for (int i = 0; i < times; i++)
        //    {
        //        List<Card> TempList = new List<Card>();
        //        Random random = new Random();

        //        while (Cards.Count > 0)
        //        {
        //            int randomIndex = random.Next(0, Cards.Count);
        //            TempList.Add(Cards[randomIndex]);
        //            Cards.RemoveAt(randomIndex);
        //        }
        //        Cards = TempList;


        //    }
    }
}
