namespace _01.AA_Tree
{
    using System;

    public class AATree<T> where T : IComparable<T>
    {
        #region node
        internal class Node<T> where T : IComparable<T>
        {
            internal Node<T> left;
            internal Node<T> right;
            internal int level;
            internal T value;

            internal Node()
            {
                this.level = 0;
                this.left = this;
                this.right = this;
            }

            internal Node(T value, Node<T> sentinel)
            {
                this.value = value;
                this.level = 1;
                this.left = sentinel;
                this.right = sentinel;
            }

            internal void Print(string indent)
            {
                if (this.left.level != 0)
                {
                    this.left.Print(indent + "   ");
                }

                Console.WriteLine(indent + this.value);

                if (this.right.level != 0)
                {
                    this.right.Print(indent + "   ");
                }
            }
        }
        #endregion

        private Node<T> root;
        private readonly Node<T> sentinel;

        public AATree()
        {
            this.sentinel = new Node<T>();
            this.root = sentinel;
        }

        public bool Add(T element)
        {
            return this.Insert(ref this.root, element);
        }

        public bool Remove(T element)
        {
            return this.Delete(ref this.root, element);
        }

        public bool Find(T element)
        {
            return this.Search(this.root, element);
        }

        public void Print()
        {
            this.root.Print("");
        }

        private bool Insert(ref Node<T> currentNode, T element)
        {
            bool result = false;

            if (currentNode == sentinel)
            {
                currentNode = new Node<T>(element, sentinel);
                return true;
            }

            if (currentNode.value.CompareTo(element) < 0)
            {
                result = this.Insert(ref currentNode.right, element);
            }
            else if (currentNode.value.CompareTo(element) > 0)
            {
                result = this.Insert(ref currentNode.left, element);
            }
            else
            {
                result = false;
            }

            if (result)
            {
                this.Skew(ref currentNode);
                this.Split(ref currentNode);    
            }
            
            return result;
        }

        private bool Delete(ref Node<T> currentNode, T element)
        {
            if (currentNode == sentinel)
            {
                return false;
            }

            bool result = false;

            if (currentNode.value.CompareTo(element) < 0)
            {
                result = this.Delete(ref currentNode.right, element);
            }
            else if (currentNode.value.CompareTo(element) > 0)
            {
                result = this.Delete(ref currentNode.left, element);
            }
            else
            {
                FindSuccessorValue(ref currentNode);
                result = true;
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

        private bool Search(Node<T> currentNode, T element)
        {
            while (currentNode != sentinel)
            {
                if (currentNode.value.CompareTo(element) > 0)
                {
                    currentNode = currentNode.left;
                }
                else if (currentNode.value.CompareTo(element) < 0)
                {
                    currentNode = currentNode.right;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        private void Skew(ref Node<T> node)
        {
            if (node != sentinel && node.left.level == node.level)
            {
                var leftNode = node.left;
                node.left = leftNode.right;
                leftNode.right = node;
                node = leftNode;
            }
        }

        private void Split(ref Node<T> node)
        {
            if (node != sentinel && node.right.right.level == node.level)
            {
                var rightNode = node.right;
                node.right = rightNode.left;
                rightNode.left = node;
                node = rightNode;
                node.level++;
            }
        }

        private void DecreaseLevel(ref Node<T> node)
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

        private void FindSuccessorValue(ref Node<T> node)
        {
            T result;

            if (node.left != sentinel)
            {
                var lastNode = node.left;
                var currentNode = node.left;

                while (currentNode.right != sentinel)
                {
                    lastNode = currentNode;
                    currentNode = currentNode.right;
                }

                result = currentNode.value;

                if (lastNode != currentNode)
                {
                    lastNode.right = currentNode.left;
                }
                else
                {
                    node.left = currentNode.left;
                }

                node.value = result;
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

                result = currentNode.value;

                if (lastNode != currentNode)
                {
                    lastNode.left = currentNode.right;
                }
                else
                {
                    node.right = currentNode.right;
                }

                node.value = result;
            }
            else
            {
                node = sentinel;
            }
        }
    }
}