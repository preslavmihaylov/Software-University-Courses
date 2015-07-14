using System;

public class ArrayStack<T>
{
    private T[] elements;

    public int Count { get; private set; }

    private const int InitialCapacity = 16;

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];   
    }

    public void Push(T element)
    {
        if (this.Count >= this.elements.Length)
        {
            this.Grow();
        }

        this.elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The stack is empty");
        }

        T elementToPop = this.elements[this.Count - 1];
        this.elements[this.Count - 1] = default(T);

        this.Count--;
        return elementToPop;
    }

    public T[] ToArray()
    {
        T[] result = new T[this.Count];

        int resultIndex = 0;
        for (int index = this.Count - 1; index >= 0; index--)
        {
            result[resultIndex] = this.elements[index];
            resultIndex++;
        }

        return result;
    }

    private void Grow()
    {
        T[] newArray = new T[this.elements.Length * 2];
        for (int index = 0; index < this.Count; index++)
        {
            newArray[index] = this.elements[index];
        }

        this.elements = newArray;
    }

}