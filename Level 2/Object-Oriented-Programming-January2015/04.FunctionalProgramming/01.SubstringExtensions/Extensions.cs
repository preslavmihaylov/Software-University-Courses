using System;
using System.Collections.Generic;
using System.Text;

static class Extensions
{
    public static string Substring(this StringBuilder str, int startIndex, int length)
    {
        if (startIndex + length > str.Length || startIndex < 0)
	    {
            throw new ArgumentOutOfRangeException();
	    }

        string output = "";

        for (int index = startIndex; index < startIndex + length; index++)
        {
            output += str[index];
        }

        return output;
    }

    public static void RemoveText(this StringBuilder str, string value) 
    {
        str.Replace(value, "");
    }

    public static void AppendAll<T>(this StringBuilder str, IEnumerable<T> collection)
    {
        foreach (var element in collection)
        {
            str.Append(element.ToString());
        }
    }

}