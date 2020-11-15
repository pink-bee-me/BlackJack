using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TwentyOne
{
   public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)
        {
            Hand.Add(Deck.Cards.First()); // adding the card to the hand
            string card = String.Format(Deck.Cards.First().ToString() + "\n");
            Console.WriteLine(card); // writing  to console what card was added to the hand and then adding a new line (a space kind of)
            using (StreamWriter file = new StreamWriter(@"C:\Users\LaurieSue\Logs\log.txt", true))
            {
                file.WriteLine(card);
            } 
                Deck.Cards.RemoveAt(0);
        }

    }
}
