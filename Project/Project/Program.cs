using System;
using System.Collections.Generic;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1: First Example");
            Exo1();
            Console.WriteLine("1: Second Example");
            Exo1Bis();
            Console.WriteLine("2:");
            Exo2();
            Console.WriteLine("3:");
            Exo3();
            Console.ReadKey();
        }
        static void Exo1()
        {
            Node<string> first = new Node<string>("hello", null);
            CustomQueue<string> customQueue = new CustomQueue<string>(first);
            customQueue.EnQueue("bye");
            customQueue.EnQueue("hello again");
            Console.WriteLine("first Dequeue : " + customQueue.DeQueue().Content);
            customQueue.EnQueue("bye again");
            foreach(Node<string> s in customQueue)
            {
                Console.WriteLine("in foreach loop: " + s.Content);
            }
        }
        static void Exo1Bis()
        {
            CustomQueue<int> customQueue = new CustomQueue<int>();
            customQueue.EnQueue(1);
            customQueue.EnQueue(6);
            customQueue.EnQueue(8);
            customQueue.EnQueue(3);
            foreach (Node<int> s in customQueue)
            {
                Console.WriteLine("in foreach loop: " + s.Content);
            }
        }
        static void Exo2()
        {
            Ex2 ex2 = new Ex2();
            List<(string, int)> retour = ex2.Run();
            foreach((string,int) value in retour)
            {
                Console.WriteLine(value.Item1 + " with value: " + value.Item2);
            }
        }
        
        static void Exo3()
        {
            Player baptiste = new Player("Baptiste");
            Player alexis = new Player("Alexis");

            Player[] gamers = { baptiste, alexis };

            Game monopoly = new Game(gamers);

            monopoly.Game_Launch();
        }
    }
}
