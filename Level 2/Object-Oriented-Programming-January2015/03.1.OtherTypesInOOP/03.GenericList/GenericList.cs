using System;
using System.Collections;
using System.Linq;

[Version(2, 11)]
class GenericList<T> : IEnumerable where T : IComparable
{
    private T[] elements;
    private int capacity = 16;
    private int count;

    public int Capacity
    {
        get
        {
            return this.capacity;
        }

        private set 
        {
            this.capacity = value;
        }
    }

    public int Count
    {
        get
        {
            return this.count;
        }

        private set
        {
            this.count = value;
        }
    }

    public T this[int index]
    {
        get 
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            return this.elements[index];
        }
        set 
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            this.elements[index] = value;
        }
    }

    public GenericList()
    {
        this.elements = new T[this.capacity];
    }

    public void Add(T element)
    {
        if (this.Count >= this.Capacity)
        {
            this.Capacity = this.Capacity * 2;
            T[] newArray = new T[this.Capacity];
            for (int index = 0; index < this.Count; index++)
            {
                newArray[index] = this.elements[index];
            }

            this.elements = newArray;
        }

        this.elements[this.Count] = element;
        this.Count++;
    }

    public void Remove(int indexToRemove)
    {
        this.elements[indexToRemove] = default(T);
        for (int index = indexToRemove + 1; index < this.Count; index++)
        {
            this.elements[index - 1] = this.elements[index]; 
        }
        this.Count--;
    }

    public void Clear()
    {
        for (int index = 0; index < this.Count; index++)
        {
            this.elements[index] = default(T);
        }
        this.Count = 0;
    }

    public int Find(T value)
    {
        int foundIndex = -1;
        for (int index = 0; index < this.Count; index++)
        {
            if (this.elements[index].CompareTo(value) >= 0)
            {
                foundIndex = index;
                break;
            }
        }

        return foundIndex;
    }

    public void Insert(T value, int indexToInsert)
    {
        if (indexToInsert < 0 || indexToInsert >= this.Count)
        {
            throw new IndexOutOfRangeException();
        }

        this.Add(default(T));

        for (int index = this.Count - 1; index > indexToInsert; index--)
        {
            this.elements[index] = this.elements[index - 1];
        }

        this.elements[indexToInsert] = value;
    }

    public T Min()
    {
        if (this.Count == 0)
        {
            return default(T);
        }

        T minValue = this.elements[0];
        for (int index = 0; index < this.Count; index++)
        {
            if (this.elements[index].CompareTo(minValue) < 0)
            {
                minValue = this.elements[index];
            }
        }

        return minValue;
    }

    public T Max()
    {
        if (this.Count == 0)
        {
            return default(T);
        }

        T maxValue = this.elements[0];
        for (int index = 0; index < this.Count; index++)
        {
            if (this.elements[index].CompareTo(maxValue) > 0)
            {
                maxValue = this.elements[index];
            }
        }

        return maxValue;
    }

    public bool Contains(T value)
    {
        for (int index = 0; index < this.Count; index++)
        {
            if (this.elements[index].CompareTo(value) >= 0)
            {
                return true;
            }
        }

        return false;
    }

    public override string ToString()
    {
        string output = "{";
        for (int index = 0; index < this.Count; index++)
        {
            if (index != this.Count - 1)
            {
                output += this.elements[index] + ", ";
            }
            else 
            {
                output += this.elements[index];
            }
        }
        output += "}";
        return output;
    }

    public string Version()
    {
        Type type = typeof(GenericList<T>);
        object[] allAttributes = type.GetCustomAttributes(typeof(Version), true);
        foreach (Version attribute in allAttributes)
        {
            return attribute.VersionNumber;
        }

        return null;
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
