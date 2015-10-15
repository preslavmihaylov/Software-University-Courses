#ifndef HEAP_H
#define HEAP_H

#include <vector>

#define mSwap(first, second)  \
    T old = first;            \
    first = second;           \
    second = old;

using namespace std;

/* CLASS DECLARATION */
template <class T>
class Heap
{
    public:
        Heap()
        {
        };
        Heap(T * elements, int elementsCount)
        {
            for (int index = 0; index < elementsCount; index++)
            {
                this->heap.push_back(elements[index]);
            }

            for (int index = this->heap.size() / 2; index >= 0; index--)
            {
                this->HeapifyDown(index);
            }
        };
        virtual ~Heap()
        {
            delete &this->heap;
        };
        int Count();
        T ExtractMin();
        T PeekMin();
        void Insert(T node);
    protected:
    private:
        vector<T> heap;
        void HeapifyDown(int i);
        void HeapifyUp(int i);
};

/* FUNCTION DEFINITIONS */
template <class T>
int Heap<T>::Count()
{
    return this->heap.size();
}

template <class T>
T Heap<T>::ExtractMin()
{
    T max = this->heap.at(0);
    this->heap.at(0) = this->heap.at(this->heap.size() - 1);
    this->heap.pop_back();
    if (this->heap.size() > 0)
    {
        this->HeapifyDown(0);
    }

    return max;
}

template <class T>
T Heap<T>::PeekMin()
{
    T max = this->heap.at(0);
    return max;
}

template <class T>
void Heap<T>::Insert(T node)
{
    this->heap.push_back(node);
    this->HeapifyUp(this->heap.size() - 1);
}

template <class T>
void Heap<T>::HeapifyDown(int i)
{
    int left = 2 * i + 1;
    int right = 2 * i + 2;
    int smallest = i;

    if (left < this->heap.size() &&
        this->heap.at(left) < this->heap.at(smallest))
    {
        smallest = left;
    }

    if (right < this->heap.size() &&
        this->heap.at(right) < this->heap.at(smallest))
    {
        smallest = right;
    }

    if (smallest != i)
    {
        mSwap(this->heap.at(i), this->heap.at(smallest));
        HeapifyDown(smallest);
    }
}

template <class T>
void Heap<T>::HeapifyUp(int i)
{
    int parentIndex = (i - 1) / 2;

    while (i > 0 &&
           this->heap.at(i) < this->heap.at(parentIndex))
    {
        mSwap(this->heap.at(i), this->heap.at(parentIndex));
        i = parentIndex;
        parentIndex = (i - 1) / 2;
    }
}

#endif // HEAP_H
