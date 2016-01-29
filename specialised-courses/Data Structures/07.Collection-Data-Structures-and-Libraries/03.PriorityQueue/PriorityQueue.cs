namespace _03.PriorityQueue
{
    using System;

    class PriorityQueue<T> where T : IComparable
    {
        private T[] binaryHeap;
        private const int InitialCapacity = 2;
        private readonly int ComparatorNumber;

        public PriorityQueue()
            : this(false)
        {
        }

        public PriorityQueue(bool inversePriority)
        {
            this.binaryHeap = new T[InitialCapacity];
            if (inversePriority)
            {
                this.ComparatorNumber = -1;
            }
            else
            {
                this.ComparatorNumber = 1;
            }
        }

        public int Count { get; set; }

        public void Enqueue(T element)
        {
            if (this.Count >= this.binaryHeap.Length - 1)
            {
                this.DoubleHeapSize();
            }

            this.Count++;
            this.binaryHeap[this.Count] = element;
            PercolateUp();
        }

        public T Dequeue()
        {
            T elementToDeque = this.binaryHeap[1];
            this.binaryHeap[1] = this.binaryHeap[this.Count];
            this.binaryHeap[this.Count] = default(T);
            this.Count--;
            PercolateDown();

            return elementToDeque;
        }

        private void PercolateUp()
        {
            int currentIndex = this.Count;
            int parentIndex = currentIndex / 2;

            while (parentIndex != 0 && 
                this.binaryHeap[parentIndex].CompareTo(this.binaryHeap[currentIndex]) == ComparatorNumber)
            {
                SwapElements(parentIndex, currentIndex);
                currentIndex = parentIndex;
                parentIndex = currentIndex / 2;
            }
        }

        private void PercolateDown()
        {
            int largestIndex = 1;
            bool hasPercolated = true;

            while (hasPercolated)
            {
                hasPercolated = false;
                int leftChildIndex = largestIndex * 2;
                int rightChildIndex = (largestIndex * 2) + 1;

                if (leftChildIndex <= this.Count &&
                    this.binaryHeap[largestIndex].CompareTo(this.binaryHeap[leftChildIndex]) == ComparatorNumber)
                {
                    largestIndex = leftChildIndex;
                    hasPercolated = true;
                }
                
                if (rightChildIndex <= this.Count &&
                    this.binaryHeap[largestIndex].CompareTo(this.binaryHeap[rightChildIndex]) == ComparatorNumber)
                {
                    largestIndex = rightChildIndex;
                    hasPercolated = true;
                }

                if (hasPercolated)
                {
                    this.SwapElements(largestIndex, largestIndex / 2);
                }
            }
            

        }

        private void SwapElements(int firstIndex, int secondIndex)
        {
            T temp = this.binaryHeap[firstIndex];
            this.binaryHeap[firstIndex] = this.binaryHeap[secondIndex];
            this.binaryHeap[secondIndex] = temp;
        }

        private void DoubleHeapSize()
        {
            T[] newHeap = new T[this.binaryHeap.Length * 2];
            Array.Copy(this.binaryHeap, newHeap, this.binaryHeap.Length);
            this.binaryHeap = newHeap;
        }
    }
}