using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Project
{
    public class CustomQueue<T> : IEnumerable,IEnumerator
    {
        private Node<T> firstNode;

        public CustomQueue(Node<T> firstNode)
        {
            this.firstNode = firstNode;
        }

        public CustomQueue()
        {
        }

        public Node<T> FirstNode { get => firstNode; set => firstNode = value; }
        /// <summary>
        /// Method for accessing the desired object
        /// </summary>
        /// <param name="index">Index of the desired object (start at 0 for first node)</param>
        /// <returns>
        /// The Method throws an IndexOutOfRangeException if the index is not within boundaries
        /// </returns>
        public void EnQueue(T value)
        {
            Node<T> newNode = new Node<T>(value, null);
            if (firstNode==null)
            {
                firstNode = newNode;
            }
            else
            {
                firstNode.EnQueue(newNode);
            }
        }
        public Node<T> DeQueue()
        {
            if (firstNode==null)
            {
                return null;
            }
            else
            {
                Node<T> retour = new Node<T>(firstNode.Content,null);
                firstNode = firstNode.Following;
                return retour;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            if (firstNode==null)
            {
                return false;
            }
            return true;
        }
        public void Reset()
        {

        }
        public object Current
        {
            get { return DeQueue(); }
        }

    }
}
