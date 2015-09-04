namespace _02.BiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;

    public class BiDictionary<TKey1, TKey2, TValue>
    {
        private Dictionary<TKey1, ICollection<TValue>> valuesByFirstKey;
        private Dictionary<TKey2, ICollection<TValue>> valuesBySecondKey;
        private Dictionary<Tuple<TKey1, TKey2>, ICollection<TValue>> valuesByBothKeys;

        public BiDictionary()
        {
            this.valuesByFirstKey = new Dictionary<TKey1, ICollection<TValue>>();
            this.valuesBySecondKey = new Dictionary<TKey2, ICollection<TValue>>();
            this.valuesByBothKeys = new Dictionary<Tuple<TKey1, TKey2>, ICollection<TValue>>();
        }

        public void Add(TKey1 firstKey, TKey2 secondKey, TValue value)
        {
            if (!this.valuesByFirstKey.ContainsKey(firstKey))
            {
                this.valuesByFirstKey[firstKey] = new List<TValue>();
            }

            if (!this.valuesBySecondKey.ContainsKey(secondKey))
            {
                this.valuesBySecondKey[secondKey] = new List<TValue>();
            }

            var bothKeys = new Tuple<TKey1, TKey2>(firstKey, secondKey);

            if (!this.valuesByBothKeys.ContainsKey(bothKeys))
            {
                this.valuesByBothKeys[bothKeys] = new List<TValue>();
            }

            this.valuesByFirstKey[firstKey].Add(value);
            this.valuesBySecondKey[secondKey].Add(value);
            this.valuesByBothKeys[bothKeys].Add(value);
        }

        public IEnumerable<TValue> FindByKey1(TKey1 key)
        {
            if (this.valuesByFirstKey.ContainsKey(key))
            {
                return this.valuesByFirstKey[key];
            }
            else
            {
                return new TValue[0];
            }
        }

        public IEnumerable<TValue> FindByKey2(TKey2 key)
        {
            if (this.valuesBySecondKey.ContainsKey(key))
            {
                return this.valuesBySecondKey[key];
            }
            else
            {
                return new TValue[0];
            }
        }

        public IEnumerable<TValue> Find(TKey1 key1, TKey2 key2)
        {
            var bothKeys = new Tuple<TKey1, TKey2>(key1, key2);

            if (this.valuesByBothKeys.ContainsKey(bothKeys))
            {
                return this.valuesByBothKeys[bothKeys];
            }
            else
            {
                return new TValue[0];
            }
        }

        public bool Remove(TKey1 key1, TKey2 key2)
        {
            var bothKeys = new Tuple<TKey1, TKey2>(key1, key2);

            if (!this.valuesByBothKeys.ContainsKey(bothKeys))
            {
                return false;
            }

            var distances = this.valuesByBothKeys[bothKeys];

            foreach (var distance in distances)
            {
                this.valuesByFirstKey[key1].Remove(distance);
                this.valuesBySecondKey[key2].Remove(distance);
            }

            this.valuesByBothKeys.Remove(bothKeys);

            return true;
        }
    }
}
