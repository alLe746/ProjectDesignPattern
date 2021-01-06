using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class Node<T>
    {
        private T content;
        private Node<T> following;

        public Node()
        {
        }

        public Node(T content, Node<T> following)
        {
            this.content = content;
            this.following = following;
        }

        public T Content { get => content; set => content = value; }
        public Node<T> Following { get => following; set => following = value; }
        public Node<T> Next()
        {
            return following;
        }
        public void EnQueue(Node<T> newNode)
        {
            if (following==null)
            {
                following = newNode;
            }
            else
            {
                following.EnQueue(newNode);
            }
        }
    }
}
