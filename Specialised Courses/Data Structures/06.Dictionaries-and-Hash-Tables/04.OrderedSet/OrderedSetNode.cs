namespace _04.OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSetNode<K> : IEnumerable<K> where K : IComparable<K>
    {
        private OrderedSetNode<K> leftNode;
        private OrderedSetNode<K> rightNode; 

        public OrderedSetNode(K value)
        {
            this.Value = value;
        }

        public OrderedSetNode<K> LeftNode
        {
            get { return this.leftNode; }
            set { this.leftNode = value; }
        }
        public OrderedSetNode<K> RightNode
        {
            get { return this.rightNode; }
            set { this.rightNode = value; }
        }

        public K Value
        {
            get;
            set;
        }

        public int Height
        {
            get
            {
                if (this.LeftNode == null && this.RightNode == null)
                {
                    return 1;
                }
                else if (this.LeftNode == null)
                {
                    return this.RightNode.Height + 1;
                }
                else if (this.RightNode == null)
                {
                    return this.LeftNode.Height + 1;
                }
                else
                {
                    return Math.Max(this.LeftNode.Height, this.RightNode.Height) + 1;
                }
            }
        }

        public int Balance
        {
            get
            {
                if (this.LeftNode == null && this.RightNode == null)
                {
                    return 0;
                }
                else if (this.LeftNode == null)
                {
                    return -this.RightNode.Height;
                }
                else if (this.RightNode == null)
                {
                    return this.LeftNode.Height;
                }
                else
                {
                    return this.LeftNode.Height - this.RightNode.Height;
                }
            }
        }

        public void Add(K element)
        {
            // element is less than value
            if (this.Value.CompareTo(element) < 0)
            {
                if (this.RightNode == null)
                {
                    this.RightNode = new OrderedSetNode<K>(element);
                }
                else
                {
                    this.RightNode.Add(element);
                }
            }
            // element is greater than value
            else if (this.Value.CompareTo(element) > 0)
            {
                if (this.LeftNode == null)
                {
                    this.LeftNode = new OrderedSetNode<K>(element);
                }
                else
                {
                    this.LeftNode.Add(element);
                }
            }

            CheckBalance();
        }

        public bool Contains(K element)
        {
            // are equal
            if (this.Value.CompareTo(element) == 0)
            {
                return true;
            }
            // element is greater than value
            else if (this.Value.CompareTo(element) < 0)
            {
                if (this.RightNode == null)
                {
                    return false;
                }
                else
                {
                    return this.RightNode.Contains(element);
                }
            }
            // element is less than value
            else
            {
                if (this.LeftNode == null)
                {
                    return false;
                }
                else
                {
                    return this.LeftNode.Contains(element);
                }
            }
        }

        public bool Remove(K element)
        {
            // element is greater than value
            if (this.Value.CompareTo(element) < 0)
            {
                bool result = HandleRemovingNode(ref this.rightNode, element);

                if (result)
                {
                    this.CheckBalance();    
                }

                return result;
            }
            // element is less than value
            else if (this.Value.CompareTo(element) > 0)
            {
                bool result = HandleRemovingNode(ref this.leftNode, element);

                if (result)
                {
                    this.CheckBalance();
                }

                return result;
            }
            else
            {
                throw new InvalidOperationException("A node cannot self-remove itself.");
            }


        }

        public IEnumerator<K> GetEnumerator()
        {
            if (this.LeftNode != null)
            {
                foreach (var element in this.LeftNode)
                {
                    yield return element;
                }
            }

            yield return this.Value;

            if (this.RightNode != null)
            {
                foreach (var element in this.RightNode)
                {
                    yield return element;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public OrderedSetNode<K> FindReplacingNode()
        {
            if (this.LeftNode == null)
            {
                throw new InvalidOperationException("a node cannot replace itself.");
            }

            if (this.LeftNode.LeftNode != null)
            {
                return this.LeftNode.FindReplacingNode();
            }
            else
            {
                var leftNode = this.LeftNode;
                this.LeftNode = null;
                return leftNode;
            }
        }

        public static void BalanceNode(ref OrderedSetNode<K> node, int balance)
        {
            // The tree is right heavy
            if (balance < 0)
            {
                // right subtree is heavy
                if (node.RightNode.Balance < 0)
                {
                    OrderedSetNode<K> root = node.PerformLeftRotation();
                    node = root;
                }
                // left subtree is heavy
                else
                {
                    OrderedSetNode<K> rightSubtreeRoot = node.RightNode.PerformRightRotation();
                    node.RightNode = rightSubtreeRoot;

                    OrderedSetNode<K> root = node.PerformLeftRotation();
                    node = root;
                }
            }
            // The tree is left heavy
            else
            {
                // right subtree is heavy
                if (node.LeftNode.Balance < 0)
                {
                    OrderedSetNode<K> leftSubtreeRoot = node.LeftNode.PerformLeftRotation();
                    node.LeftNode = leftSubtreeRoot;

                    OrderedSetNode<K> root = node.PerformRightRotation();
                    node = root;
                }
                // left subtree is heavy
                else
                {
                    OrderedSetNode<K> root = node.PerformRightRotation();
                    node = root;
                }
            }
        }

        private OrderedSetNode<K> PerformLeftRotation()
        {
            /*
             * the right node becomes the new root.
             * this node takes ownership of the right node's left child as its right child.             * the right node takes ownership of this node as its left child.              */

            OrderedSetNode<K> root = this.RightNode;
            this.RightNode = root.LeftNode;
            root.LeftNode = this;

            return root;
        }

        private OrderedSetNode<K> PerformRightRotation()
        {
            /*
             * the left node becomes the new root.
             * this node takes ownership of the left node's right child, as its left child.
             * the left node takes ownership of this node, as it's right child. 
             */

            OrderedSetNode<K> root = this.LeftNode;
            this.LeftNode = root.RightNode;
            root.RightNode = this;

            return root;
        }

        private static bool HandleRemovingNode(ref OrderedSetNode<K> node, K element)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value.CompareTo(element) == 0)
            {
                if (node.RightNode == null)
                {
                    node = node.LeftNode;
                    return true;
                }

                OrderedSetNode<K> replaceNode;
                if (node.RightNode.LeftNode == null)
                {
                    node.RightNode.LeftNode = node.LeftNode;
                    node = node.RightNode;
                    return true;
                }

                replaceNode = node.RightNode.FindReplacingNode();

                node.Value = replaceNode.Value;

                return true;
            }
            else
            {
                return node.Remove(element);
            }
        }

        private void CheckBalance()
        {
            if (this.LeftNode != null)
            {
                int leftBalance = this.LeftNode.Balance;

                if (Math.Abs(leftBalance) > 1)
                {
                    BalanceNode(ref this.leftNode, leftBalance);
                }
            }

            if (this.RightNode != null)
            {
                int rightBalance = this.RightNode.Balance;

                if (Math.Abs(rightBalance) > 1)
                {
                    BalanceNode(ref this.rightNode, rightBalance);
                }
            }
        }
    }
}
