namespace _02.IntervalTree
{
    using System;

    class IntervalTree
    {

        #region node
        internal class Node
        {
            private int highestSubtreeEndpoint;

            internal Node left;
            internal Node right;
            internal int level;
            internal int key;
            internal Interval value;
            internal bool isRebalanced;

            internal int HighestSubtreeEndpoint
            {
                get
                {
                    if (isRebalanced && this.level != 0)
                    {
                        double childrenMaxEndpoint =
                            Math.Max(this.left.HighestSubtreeEndpoint, this.right.HighestSubtreeEndpoint);

                        this.highestSubtreeEndpoint = 
                            Math.Max(this.value.End, (int)childrenMaxEndpoint);
                    }

                    return this.highestSubtreeEndpoint;
                }
            }

            internal Node()
            {
                this.level = 0;
                this.left = this;
                this.right = this;
                this.highestSubtreeEndpoint = int.MinValue;
            }

            internal Node(Interval value, Node sentinel)
            {
                this.level = 1;
                this.key = value.Start;
                this.left = sentinel;
                this.right = sentinel;
                this.highestSubtreeEndpoint = value.End;
                this.value = value;
            }

            internal void Print(string indent)
            {
                if (this.left.level != 0)
                {
                    this.left.Print(indent + "     ");
                }

                Console.WriteLine(indent + "Key: " + this.key);
                Console.WriteLine(indent + "Value: " + this.value);
                Console.WriteLine(indent + "Highest endpoint: " + this.HighestSubtreeEndpoint);

                if (this.right.level != 0)
                {
                    this.right.Print(indent + "     ");
                }
            }
        }
        #endregion

        private Node root;
        private readonly Node sentinel;

        public IntervalTree()
        {
            this.sentinel = new Node();
            this.root = sentinel;
        }

        public bool Add(Interval element)
        {
            return this.Insert(ref this.root, element);
        }

        public bool Remove(Interval element)
        {
            return this.Delete(ref this.root, element);
        }

        public Interval FindOverlappingInterval(Interval element)
        {
            return this.SearchOverlappingInterval(ref this.root, element);
        }

        public void Print()
        {
            this.root.Print("");
        }

        private bool Insert(ref Node currentNode, Interval element)
        {
            bool result = false;

            if (currentNode == sentinel)
            {
                currentNode = new Node(element, sentinel);
                return true;
            }

            if (currentNode.key.CompareTo(element.Start) < 0)
            {
                result = this.Insert(ref currentNode.right, element);
            }
            else if (currentNode.key.CompareTo(element.Start) > 0)
            {
                result = this.Insert(ref currentNode.left, element);
            }
            else
            {
                result = false;
            }

            if (result)
            {
                currentNode.isRebalanced = true;
                this.Skew(ref currentNode);
                this.Split(ref currentNode);
            }

            return result;
        }

        private bool Delete(ref Node currentNode, Interval element)
        {
            if (currentNode == sentinel)
            {
                return false;
            }

            bool result = false;

            if (currentNode.key.CompareTo(element.Start) < 0)
            {
                result = this.Delete(ref currentNode.right, element);
            }
            else if (currentNode.key.CompareTo(element.Start) > 0)
            {
                result = this.Delete(ref currentNode.left, element);
            }
            else
            {
                FindSuccessorValue(ref currentNode);
                result = true;
            }

            if (result)
            {
                currentNode.isRebalanced = true;
            }

            this.DecreaseLevel(ref currentNode);
            this.Skew(ref currentNode);
            this.Skew(ref currentNode.right);

            if (currentNode.right != sentinel)
            {
                this.Skew(ref currentNode.right.right);
            }

            this.Split(ref currentNode);
            this.Split(ref currentNode.right);

            return result;
        }

        private Interval SearchOverlappingInterval(ref Node currentNode, Interval interval)
        {
            if (currentNode == sentinel)
            {
                return null;
            }
            else if ((interval.Start >= currentNode.value.Start && interval.Start <= currentNode.value.End) ||
                (interval.End >= currentNode.value.Start && interval.End <= currentNode.value.End))
            {
                // Intersects
                return currentNode.value;
            }

            if (interval.Start <= currentNode.left.HighestSubtreeEndpoint)
            {
                return this.SearchOverlappingInterval(ref currentNode.left, interval);
            }
            else
            {
                return this.SearchOverlappingInterval(ref currentNode.right, interval);
            }
        }

        private void Skew(ref Node node)
        {
            if (node != sentinel && node.left.level == node.level)
            {
                var leftNode = node.left;
                leftNode.isRebalanced = true;
                node.isRebalanced = true;

                node.left = leftNode.right;
                leftNode.right = node;
                node = leftNode;
            }
        }

        private void Split(ref Node node)
        {
            if (node != sentinel && node.right.right.level == node.level)
            {
                var rightNode = node.right;
                rightNode.isRebalanced = true;
                node.isRebalanced = true;

                node.right = rightNode.left;
                rightNode.left = node;
                node = rightNode;
                node.level++;
            }
        }

        private void DecreaseLevel(ref Node node)
        {
            int desiredLevel = Math.Min(node.left.level, node.right.level) + 1;
            if (desiredLevel < node.level)
            {
                node.level = desiredLevel;
                if (desiredLevel < node.right.level)
                {
                    node.right.level = desiredLevel;
                }
            }
        }

        private void FindSuccessorValue(ref Node node)
        {
            int result;

            if (node.left != sentinel)
            {
                var lastNode = node.left;
                var currentNode = node.left;

                while (currentNode.right != sentinel)
                {
                    lastNode = currentNode;
                    currentNode = currentNode.right;
                }

                result = currentNode.key;

                if (lastNode != currentNode)
                {
                    lastNode.right = currentNode.left;
                }
                else
                {
                    node.left = currentNode.left;
                }

                node.key = result;
            }
            else if (node.right != sentinel)
            {
                var lastNode = node.right;
                var currentNode = node.right;

                while (currentNode.left != sentinel)
                {
                    lastNode = currentNode;
                    currentNode = currentNode.left;
                }

                result = currentNode.key;

                if (lastNode != currentNode)
                {
                    lastNode.left = currentNode.right;
                }
                else
                {
                    node.right = currentNode.right;
                }

                node.key = result;
            }
            else
            {
                node = sentinel;
            }
        }
    }
}