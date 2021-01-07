using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Game
    {
        private Player[] players;

        public Player[] Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        public Game(Player[] players)
        {
            this.Players = players;
        }

        public void Game_Launch()
        {
            bool stop = false;

            while (stop == false)
            {
                foreach (Player p in Players)
                {
                    Console.WriteLine("it's the turn of " + p.Name);
                    p.Turn();
                }
                Console.WriteLine("everyone did a turn, would you like to continue or stop?");
                Console.Write("Write s if you want to stop or anything else if not : ");
                String read = Console.ReadLine();
                if (read == "s")
                {
                    stop = true;
                }
                else
                {
                    Console.WriteLine("_______________________________");
                }
            }
        }

    }
}
