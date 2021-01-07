using System;
using System.Collections.Generic;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Exo2();
            Console.ReadKey();
        }
        static void Exo1()
        {
            Node<string> last = new Node<string>("bonjour", null);
            Node<string> mid = new Node<string>("bye", last);
            Node<string> first = new Node<string>("hello", mid);
            CustomQueue<string> customQueue = new CustomQueue<string>(first);
            customQueue.EnQueue("coucou");
            foreach(Node<string> s in customQueue)
            {
                Console.WriteLine(s.Content);
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
    }
}
