using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class Player
    {
        private string name;
        private int position;
        private bool in_Prison;
        private int compteur_Prison;

        public string Name 
        {
            get { return this.name; }
            set { this.name = value; } 
        }
        public int Position 
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public bool In_Prison 
        {
            get { return this.in_Prison; }
            set { this.in_Prison = value; }
        }
        public int Compteur_Prison
        {
            get { return this.compteur_Prison; }
            set { this.compteur_Prison = value; }
        }

        public Player(string name)
        {
            this.Name = name;
            this.Position = 0;
            this.In_Prison = false;
            this.Compteur_Prison = 0;
        }

        public int[] Draw_Dice()
        {
            var rand = new Random();
            int dice1 = rand.Next(1, 6);
            int dice2 = rand.Next(1, 6);
            return new int[] { dice1, dice2 };
        }

        public void Turn()
        {
            Console.WriteLine("Turn of " + this.Name);
            int counter = 0;
            while (counter < 3)
            {
                int[] dices = this.Draw_Dice();
                Console.WriteLine("you drawed : " + dices[0] + " and " + dices[1] + " which is equal to " + (dices[0] + dices[1]));

                if (this.In_Prison == false)
                {
                    this.Position += dices[0] + dices[1];
                    if (this.Position > 39)
                    {
                        this.Position -= 40;
                    }

                    if (this.Position == 30)
                    {
                        Console.WriteLine("you arrived on the case 'to the prison', you are hence sent to it at the case 10");
                        this.Position = 10;
                        this.In_Prison = true;
                        counter = 3;
                    }

                    if (dices[0] == dices[1])
                    {
                        Console.WriteLine("you rolled a double! ");
                        if (counter == 2)
                        {
                            Console.WriteLine("but it's the third time you did it so you go in prison (sorry)");
                            this.Position = 10;
                            this.In_Prison = true;
                        }
                        counter += 1;
                    }

                    else
                    {
                        counter = 3;
                    }
                }

                else
                {
                    if (dices[0] == dices[1] || Compteur_Prison == 3)
                    {
                        Console.WriteLine("you get out of prison");
                        this.In_Prison = false;
                        this.Compteur_Prison = 0;
                        this.Position += dices[0] + dices[1];
                        counter = 3;
                    }
                    else
                    {
                        Console.WriteLine("you stay in prison");
                        this.Compteur_Prison += 1;
                        counter = 3;
                    }
                }
            }
            Console.WriteLine("You are at the case " + this.Position);
        }
    }
}
