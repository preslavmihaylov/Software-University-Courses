namespace _04.OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T> where T : IComparable<T>
    {

        private OrderedSetNode<T> root; 

        public int Count { get; set; }

        public void Add(T element)
        {
            if (this.root == null)
            {
                this.root = new OrderedSetNode<T>(element);
            }
            else
            {
                this.root.Add(element);
            }

            this.Count++;

            CheckBalance();
        }

        public bool Contains(T element)
        {
            return this.root.Contains(element);
        }

        public bool Remove(T element)
        {
            bool result = this.HandleRemovingRootNode(element);

            if (result)
            {
                this.Count--;
                CheckBalance();
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in this.root)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private bool HandleRemovingRootNode(T element)
        {
            if (this.root == null)
            {
                return false;
            }

            if (this.root.Value.CompareTo(element) == 0)
            {
                if (this.root.RightNode == null)
                {
                    this.root = this.root.LeftNode;
                    return true;
                }
                else
                {
                    if (this.root.RightNode.LeftNode == null)
                    {
                        this.root.RightNode.LeftNode = this.root.LeftNode;
                        this.root = this.root.RightNode;
                        return true;
                    }

                    OrderedSetNode<T> replaceNode = this.root.RightNode.FindReplacingNode();

                    this.root.Value = replaceNode.Value;

                    return true;
                }
            }
            else
            {
                return this.root.Remove(element);
            }
        }

        private void CheckBalance()
        {
            int balance = this.root.Balance;
            if (Math.Abs(balance) > 1)
            {
                OrderedSetNode<T>.BalanceNode(ref this.root, balance);
            }
        }
    }
}