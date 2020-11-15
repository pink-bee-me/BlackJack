using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class TwentyOneGame : Game
    {


        public TwentyOneDealer Dealer { get; set; }


        public override void Play() /* have to use the override keyword because it is an inherited 
                                       abstract method from the Game Class */
        {

            Dealer = new TwentyOneDealer();
            foreach (Player player in Players)
            {
                player.Hand = new List<Card>();
                player.Stay = false; /* because if it was true at the end of a previous game we would 
                                      not want that value to carry over into the beginning of the next 
                                      game and effect game play */
            }
            Dealer.Hand = new List<Card>();
            Dealer.Stay = false;
            Dealer.Deck = new Deck();
            Dealer.Deck.Shuffle();
            Dictionary<Player, int> Bets = new Dictionary<Player, int>();
           
            foreach (Player player in Players)
            {
                Console.WriteLine("Place your bet:");
                int bet = Convert.ToInt32(Console.ReadLine());
                bool successfullyBet = player.Bet(bet); //passing the "bet"(amount) into the "Bet" method (found in Player Class)
                if (!successfullyBet) // this says if the bet is not successful (or false instead of true)
                {
                    return; // this just ends the method if it is not successful
                }
                // no need for an else statement here just move on to the next step in dealing with the bets for each player


                Bets.Add(player, bet);
                player.PlayerBet = bet;
                // added Entry into our Bets Dictionary ( in Game class) to keep track of each players bet per hand of TwentyOne
                ListPlayers();
            }
            
        
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Dealing...");

                foreach (Player player in Players)
                {
                    Console.Write("{0}: ", player.Name);// using Console.Write (instead of WriteLine because we don't want a new line)
                    Dealer.Deal(player.Hand);// to say each players name as they are getting delt their cards
                    if (i == 2)
                    {
                        bool blackJack = TwentyOneRules.CheckForBlackJack(player.Hand);
                        if (blackJack)
                        {
                            Console.WriteLine("Blackjack! {0} wins {1}", player.Name, Bets[player]);// announce winner
                            player.Balance += Convert.ToInt32((Bets[player] * 1.5) + Bets[player]); //pay winning players the amount they bet PLUS the bet amount times 1.5
                            return; //ends the round of play
                        }
                    }

                    Console.Write("Dealer: ");
                    Dealer.Deal(Dealer.Hand);
                    if (i == 1)
                    {
                        bool blackJack = TwentyOneRules.CheckForBlackJack(Dealer.Hand);
                        if (blackJack)
                        {
                            Console.WriteLine("Dealer has Blackjack! Everyone loses!");

                            foreach (KeyValuePair<Player, int> entry in Bets)
                            {
                           
                                Dealer.Balance += entry.Value;
                            }
                            return;
                        }
                    }
                }

                foreach (Player player in Players)
                {
                    while (!player.Stay)
                    {
                        Console.WriteLine("Your cards are: ");
                        foreach (Card card in player.Hand)
                        {
                            Console.WriteLine("{0} ", card.ToString());
                        }
                        Console.WriteLine("\n\nHit or Stay?");
                        string answer = Console.ReadLine().ToLower();
                        if (answer == "stay")
                        {
                            player.Stay = true;
                            break;
                        }
                        else if (answer == "hit")
                        {
                            Dealer.Deal(player.Hand);
                        }
                        bool busted = TwentyOneRules.IsBusted(player.Hand);
                        if (busted)
                        {
                            Dealer.Balance += Bets[player];
                            Console.WriteLine("{0} Busted! You lose your bet of {1}. Your balance is now {2}.", player.Name, Bets[player], player.Balance);
                            Console.WriteLine("Do you want to play again?");
                            answer = Console.ReadLine().ToLower();
                            if (answer == "yes" || answer == "yeah")
                            {
                                player.isActivelyPlaying = true;
                            }
                            else
                            {
                                player.isActivelyPlaying = false;
                            }
                        }

                    }
                    Dealer.isBusted = TwentyOneRules.IsBusted(Dealer.Hand);
                    Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
                    while (!Dealer.Stay && !Dealer.isBusted)
                    {
                        Console.WriteLine("Dealer is hitting...");
                        Dealer.Deal(Dealer.Hand);
                        Dealer.isBusted = TwentyOneRules.IsBusted(Dealer.Hand);
                        Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
                    }
                    if (Dealer.Stay)
                    {
                        Console.WriteLine("Dealer is staying.");
                    }
                    if (Dealer.isBusted)
                    {
                        Console.WriteLine("Dealer Busted!");

                        foreach (KeyValuePair<Player, int> entry in Bets)
                        {
                            Console.WriteLine("{0} won {1} !", entry.Key.Name, entry.Value);
                            Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2);
                            /* Lambda Expression: get the List of Players..WHERE(where produces a list) that player's name == the
                              entry Name in the Dictionary and the balance amount that goes with that name.
                              The list we are grabbing is the First() List  then we add .Balance to get the
                              amount and we are adding to the balance amount the entry amount times 2 */
                            Dealer.Balance -= entry.Value;
                            Dealer.Balance -= entry.Value;
                            return;
                        }
                    }
                }

                foreach (Player player in Players) //booleans are structs : they can be true , false , or null.
                {
                    bool? playerWon = TwentyOneRules.CompareHands(player.Hand, Dealer.Hand);
                    if (playerWon == null)
                    {
                        Console.WriteLine("Push! No one wins.");
                        player.Balance += Bets[player];
                    }
                    else if (playerWon == true)
                    {
                        Console.WriteLine("{0} won {1}!", player.Name, Bets[player]);
                        player.Balance += (Bets[player] * 2);
                        Dealer.Balance -= Bets[player];
                    }
                    else
                    {
                        Console.WriteLine("Dealer wins {0}!", Bets[player]);
                        Dealer.Balance += Bets[player];
                    }
                    Console.WriteLine("Play again?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes" || answer == "yeah")
                    {
                        player.isActivelyPlaying = true;
                    }
                    else
                    {
                        player.isActivelyPlaying = false;
                    }
                }

            }
        }

                public override void ListPlayers()
                    {
                        Console.WriteLine("21 Players:");
                        base.ListPlayers(); /* means keeping the base code of the method ListPlayers() 
                                            that was inherited from the Game Class */
                    }


                }   
             }

