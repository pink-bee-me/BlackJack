using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{                       // THREE CLASSES IN THIS FILE!!!

    public struct Card // CLASS CARD


    {
        public Suit Suit { get; set; }
        public Face Face { get; set; }
    }

    public enum Suit  // Class enum SUIT
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Face // Class enum FACE
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Sev,
        Eight,
        Nine,
        Ten,
        Jack,
        King,
        Queen,
        Ace
    }
}
