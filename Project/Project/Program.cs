using System;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex1();
            Console.ReadKey();
        }
        static void Ex1()
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
    }
}
