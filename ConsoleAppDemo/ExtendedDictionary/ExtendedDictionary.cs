using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo.ExtendedDictionary
{
    public class ExtendedDictionary<T, U, V> : IEnumerable
    {
        public ExtendedDictionaryElement<T, U, V>[] extendedDictionary;

        public ExtendedDictionary()
        {
            extendedDictionary = new ExtendedDictionaryElement<T, U, V>[0];
        }

        public ExtendedDictionaryElement<T, U, V> this[T key]
        {
            get
            { 
                if (ContainsKey(key))
                    return extendedDictionary
                    .Where(elem => EqualityComparer<T>.Default.Equals(elem.Key, key))
                    .First();

                throw new ArgumentException($"There is no item with such key. Key: { key }");
            }
            set
            {
                if (!ContainsKey(key))
                    throw new ArgumentException($"There is no item with such key. Key: { key }");

                for (int i = 0; i < extendedDictionary.Length; i++)
                {
                        if (EqualityComparer<T>.Default.Equals(extendedDictionary[i].Key, key))
                            extendedDictionary[i] = value;
                }                    
            }
        }

        public int Amount 
        {
            get { return extendedDictionary.Length; }
        }

        public void Add(ExtendedDictionaryElement<T, U, V> elem)
        {
            if (ContainsKey(elem.Key))            
                throw new ArgumentException($"An item with the same key has already been added. Key: {elem.Key}");

            int index = extendedDictionary.Length;
            Array.Resize(ref extendedDictionary, index + 1);
            extendedDictionary[index] = elem;
        }

        public bool ContainsKey(T key)
        {
            var elem = extendedDictionary
                .Where(elem => EqualityComparer<T>.Default.Equals(elem.Key, key))
                .FirstOrDefault()!;
            return elem != null;
        }

        public void Remove(T key)
        {
            if (ContainsKey(key))
                extendedDictionary = extendedDictionary.Where(elem => 
                Comparer<T>.Default.Compare(elem.Key, key) != 0).ToArray();
            else
                throw new ArgumentException($"There is no item with such key. Key: {key}");
        }

        public bool ContainsValues(U value1, V value2)
        {
            var elem = extendedDictionary
                .Where(elem => EqualityComparer<U>.Default.Equals(elem.Value1, value1) && 
                EqualityComparer<V>.Default.Equals(elem.Value2, value2)).FirstOrDefault()!;
            return elem != null;
        }

        public IEnumerator GetEnumerator()
        {
            return extendedDictionary.GetEnumerator();
        }

        public override string ToString()
        {
            string str = "";
            foreach (var elem in extendedDictionary)
                str += $"{elem.Key} - {elem.Value1}, {elem.Value2}\n";

            return str;
        }
    }
}   
