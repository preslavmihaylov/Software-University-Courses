#include <iostream>

#define mSwap(first, second)  \
    T old = first;            \
    first = second;           \
    second = old;

/*
template <class T>
Heap<T>::Heap()
{
}


template <class T>
Heap<T>::Heap(T * elements, int elementsCount)
{
    for (int index = 0; index < elementsCount; index++)
    {
        this->heap.push_back(elements[index]);
    }

    for (int index = this->heap.size() / 2; index >= 0; index--)
    {
        this->HeapifyDown(index);
    }
}


template <class T>
Heap<T>::~Heap()
{
    delete &this->heap;
    cout << "deleted" << endl;
}


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
    int largest = i;

    if (left < this->heap.size() &&
        this->heap.at(left) > this->heap.at(largest))
    {
        largest = left;
    }

    if (right < this->heap.size() &&
        this->heap.at(right) > this->heap.at(largest))
    {
        largest = right;
    }

    if (largest != i)
    {
        mSwap(this->heap.at(i), this->heap.at(largest));
    }
}

template <class T>
void Heap<T>::HeapifyUp(int i)
{
    int parentIndex = (i - 1) / 2;

    while (i > 0 &&
           this->heap.at(i) > this->heap.at(parentIndex))
    {
        mSwap(this->heap.at(i), this->heap.at(parentIndex));
        i = parentIndex;
        parentIndex = (i - 1) / 2;
    }
}
*/
