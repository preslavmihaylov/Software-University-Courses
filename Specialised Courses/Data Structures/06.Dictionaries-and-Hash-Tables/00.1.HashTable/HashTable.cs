using System;
using System.Collections;
using System.Collections.Generic;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>> where TKey : IComparable<TKey>
{
    private const int InitialCapacity = 16;
    private const float LoadFactor = 0.7f;

    private LinkedList<KeyValue<TKey, TValue>>[] slots;
    private int count;

    public int Count { get; private set; }

    public int Capacity
    {
        get { return this.slots.Length; }
    }

    public HashTable()
        : this(InitialCapacity)
    {
    }

    public HashTable(int capacity)
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
    }

    public void Add(TKey key, TValue value)
    {
        if ((float)(this.Count + 1) / this.Capacity > LoadFactor)
        {
            this.Grow();
        }

        int slotIndex = this.FindSlot(key);

        if (this.slots[slotIndex] == null)
        {
            this.slots[slotIndex] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in this.slots[slotIndex])
        {
            if (element.Key.Equals(key))
            {
                throw new ArgumentException("Key already exists " + key);
            }
        }

        this.slots[slotIndex].AddLast(new KeyValue<TKey, TValue>(key, value));
        this.Count++;
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        var element = this.Find(key);

        if (element != null)
        {
            element.Value = value;
            return true;
        }
        else
        {
            this.Add(key, value);
            return false;
        }
    }

    public TValue Get(TKey key)
    {
        KeyValue<TKey, TValue> element = Find(key);

        if (element != null)
        {
            return element.Value;
        }
        else
        {
            throw new KeyNotFoundException("The specified key was not found.");
        }
    }

    public TValue this[TKey key]
    {
        get
        {
            var element = this.Find(key);
            if (element == null)
            {
                throw new KeyNotFoundException("The specified key was not found");
            }

            return element.Value;
        }
        set
        {
            this.AddOrReplace(key, value);
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        KeyValue<TKey, TValue> element = Find(key);

        if (element == null)
        {
            value = default(TValue);
            return false;
        }
        else
        {
            value = element.Value;
            return true;
        }
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        int slotIndex = this.FindSlot(key);

        if (this.slots[slotIndex] != null)
        {
            foreach (var element in this.slots[slotIndex])
            {
                if (element.Key.Equals(key))
                {
                    return element;
                }
            }
        }

        return null;
    }

    public bool ContainsKey(TKey key)
    {
        KeyValue<TKey, TValue> element = Find(key);
        return element != null;
    }

    public bool Remove(TKey key)
    {
        int slotIndex = this.FindSlot(key);

        if (this.slots[slotIndex] != null)
        {
            foreach (var element in this.slots[slotIndex])
            {
                if (element.Key.Equals(key))
                {
                    this.slots[slotIndex].Remove(element);
                    this.Count--;
                    return true;
                }
            }
        }

        return false;
    }

    public void Clear()
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[this.Capacity];
        this.Count = 0;
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            foreach (var linkedList in this.slots)
            {
                if (linkedList != null)
                {
                    foreach (var element in linkedList)
                    {
                        yield return element.Key;
                    }
                }
            }
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            foreach (var linkedList in this.slots)
            {
                if (linkedList != null)
                {
                    foreach (var element in linkedList)
                    {
                        yield return element.Value;
                    }
                }
            }
        }
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var linkedList in this.slots)
        {
            if (linkedList != null)
            {
                foreach (var element in linkedList)
                {
                    yield return element;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void Grow()
    {
        var newHashTable = new HashTable<TKey, TValue>(this.Capacity * 2);
        foreach (var element in this)
        {
            newHashTable.Add(element.Key, element.Value);
        }

        this.slots = newHashTable.slots;
        this.Count = newHashTable.Count;
    }

    private int FindSlot(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % this.Capacity;
    }
}
