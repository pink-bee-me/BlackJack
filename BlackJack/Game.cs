﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
   public abstract class Game // all other games inherit properties from the game class but we will never make an instance of the game class
    {
        public List<string> Players { get; set; }
        public string Name { get; set; }
        public string Dealer { get; set; }



        public abstract void Play(); //abstract method: states that any class inheriting this class(game) MUST implement this method(Play())

        public virtual void ListPlayers() // virtual methods in abstract class: means that this method gets inherited but can be overriden to alter the workings of the method or the implementation or makes it customizable.
        {
            foreach (string player in Players)
            {
                Console.WriteLine(player);
            }
        }
    }
}
