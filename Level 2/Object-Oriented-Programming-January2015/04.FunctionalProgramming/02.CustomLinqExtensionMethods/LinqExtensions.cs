using System;
using System.Collections.Generic;
using System.Linq;

static class LinqExtensions
{
    public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var excludedItems = collection.Select(p => p).Where(predicate);
        var result = collection.Select(p => p).Where(p => !excludedItems.Contains(p));
        return result;
    }

    public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
    {
        var result = collection.Select(d => d);
        for (int i = 1; i < count; i++)
        {
            result = result.Concat(collection);
        }

        return result;
    } 

    public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection, IEnumerable<string> suffixes)
    {
        var result = collection.Select(c => c).Where(delegate(string c)
        {
            foreach (var suffix in suffixes)
            {
                if (c.EndsWith(suffix))
                {
                    return true;
                }
            }
            return false;
        });

        return result;
    }
}