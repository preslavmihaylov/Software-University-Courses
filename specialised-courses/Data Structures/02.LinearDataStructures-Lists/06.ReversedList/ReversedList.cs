using System;
using System.Collections;
using System.Collections.Generic;

class ReversedList<T> : IEnumerable<T>
{
    private T[] elements;

    public ReversedList()
    {
        this.elements = new T[0];
        this.Count = 0;
        this.Capacity = 0;
    } 

    public int Count
    {
        get;
        private set;
    }

    public int Capacity
    {
        get;
        private set;
    }

    public T this[int index]
    {
        get
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("The specified index is out of range");
            }

            return this.elements[this.Count - (index + 1)];
        }
        set
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("The specified index is out of range");
            }

            this.elements[this.Count - (index + 1)] = value;
        }
    }

    public void Add(T element)
    {
        if (this.Count >= this.Capacity)
        {
            if (this.Count != 0)
            {
                this.Capacity *= 2;
                this.elements = this.ExtendElementsArray(this.elements, this.Capacity);
                this.elements[this.Count] = element;
                this.Count++;
            }
            else
            {
                this.Capacity = 4;
                this.elements = this.ExtendElementsArray(this.elements, this.Capacity);
                this.elements[this.Count] = element;
                this.Count++;
            }
        }
        else
        {
            this.elements[this.Count] = element;
            this.Count++;
        }
    }
    
    public void Remove(int index)
    {
        this.elements[this.Count - (index + 1)] = default(T);

        for (int currentIndex = this.Count - (index + 1);
            currentIndex < this.Count - 1;
            currentIndex++)
        {
            this.elements[currentIndex] = this.elements[currentIndex + 1];
        }

        this.Count--;
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int index = this.Count - 1; index >= 0; index--)
        {
            yield return this.elements[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private T[] ExtendElementsArray(T[] oldElements, int newSize)
    {
        T[] newArray = new T[newSize];
        for (int index = 0; index < oldElements.Length; index++)
        {
            newArray[index] = oldElements[index];
        }

        return newArray;
    }
}