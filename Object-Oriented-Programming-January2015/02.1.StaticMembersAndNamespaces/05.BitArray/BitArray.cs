using System;
using System.Numerics;

class BitArray
{
    private byte[] bitArray;
    private int count;

    public int Count
    {
        get
        {
            return this.count;
        }
        private set
        {
            if (value > 100000 || value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.count = value;
            this.bitArray = new byte[value];
        }
    }

    public byte this[int index]
    {
        get
        {
            return this.bitArray[index];
        }

        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (value < 0 || value > 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.bitArray[index] = value;
        }
    }

    public BitArray(int count)
    {
        this.Count = count;
    }

    public override string ToString()
    {
        BigInteger output = 0;
        for (int index = 0; index < this.Count; index++)
        {
            if (this.bitArray[index] == 1)
            {
                BigInteger value = 1;
                for (int bitIndex = 0; bitIndex < index; bitIndex++)
                {
                    value *= 2;
                }
                output += value;
            }
        }

        return output.ToString();
    }
}
