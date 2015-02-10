using System;
using System.Collections;
using System.Text;

class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable
{
    private StringBuilder text = new StringBuilder();

    public StringDisperser(params string[] input)
    {
        foreach (var element in input)
        {
            this.Text.Append(element);
        }
    }

    private StringBuilder Text
    {
        get
        {
            return this.text;
        } 
    }

    public static bool operator ==(StringDisperser str1, StringDisperser str2)
    {
        return str1.Equals(str2);
    }

    public static bool operator !=(StringDisperser str1, StringDisperser str2)
    {
        return !str1.Equals(str2);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is StringDisperser))
        {
            return false;
        }

        StringDisperser disperser = (StringDisperser)obj;

        bool result = this.Text.ToString().CompareTo(disperser.ToString()) == 0;
        return result;
    }

    public override int GetHashCode()
    {
        return this.Text.GetHashCode() ^ this.GetHashCode();
    }

    public override string ToString()
    {
        return this.Text.ToString();
    }

    public object Clone()
    {
        return new StringDisperser(this.Text.ToString());
    }

    public int CompareTo(StringDisperser other)
    {
        return this.Text.ToString().CompareTo(other.Text.ToString());
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < this.Text.Length; i++)
        {
            yield return this.Text[i];
        }
    }
}
