using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomCollectionExample
{
    public class SimpleDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private List<KeyValuePair<TKey, TValue>> _list = new List<KeyValuePair<TKey, TValue>>();


        public TValue this[TKey key]
        {
            get
            {
                foreach (var kvp in _list)
                {
                    if (Equals(kvp.Key, key))
                    {
                        return kvp.Value;
                    }
                }
                throw new KeyNotFoundException($"The given key '{key}' was not present in the dictionary.");
            }
            set
            {
                bool found = false;
                for (int i = 0; i < _list.Count; i++)
                {
                    if (Equals(_list[i].Key, key))
                    {
                        _list[i] = new KeyValuePair<TKey, TValue>(key, value);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    _list.Add(new KeyValuePair<TKey, TValue>(key, value));
                }
            }
        }


        public ICollection<TKey> Keys => _list.ConvertAll(kvp => kvp.Key);


        public ICollection<TValue> Values => _list.ConvertAll(kvp => kvp.Value);


        public int Count => _list.Count;


        public bool IsReadOnly => false;


        public void Add(TKey key, TValue value)
        {
            foreach (var kvp in _list)
            {
                if (Equals(kvp.Key, key))
                {
                    throw new ArgumentException("An element with the same key already exists.");
                }
            }
            _list.Add(new KeyValuePair<TKey, TValue>(key, value));
        }


        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }


        public void Clear()
        {
            _list.Clear();
        }


        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _list.Contains(item);
        }


        public bool ContainsKey(TKey key)
        {
            foreach (var kvp in _list)
            {
                if (Equals(kvp.Key, key))
                {
                    return true;
                }
            }
            return false;
        }


        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }


        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _list.GetEnumerator();
        }


        public bool Remove(TKey key)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                if (Equals(_list[i].Key, key))
                {
                    _list.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }


        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return _list.Remove(item);
        }


        public bool TryGetValue(TKey key, out TValue value)
        {
            foreach (var kvp in _list)
            {
                if (Equals(kvp.Key, key))
                {
                    value = kvp.Value;
                    return true;
                }
            }
            value = default;
            return false;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }

    /// <summary>
    /// Implementing IDictionary by Array
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class SimpleArrDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private KeyValuePair<TKey, TValue>[] _array;
        private int _count;

        public SimpleArrDictionary()
        {
            _array = new KeyValuePair<TKey, TValue>[4]; // Initial capacity
            _count = 0;
        }

        public TValue this[TKey key]
        {
            get
            {
                for (int i = 0; i < _count; i++)
                {
                    if (Equals(_array[i].Key, key))
                    {
                        return _array[i].Value;
                    }
                }
                throw new KeyNotFoundException($"The given key '{key}' was not present in the dictionary.");
            }
            set
            {
                for (int i = 0; i < _count; i++)
                {
                    if (Equals(_array[i].Key, key))
                    {
                        _array[i] = new KeyValuePair<TKey, TValue>(key, value);
                        return;
                    }
                }
                // If key not found, add new item
                Add(key, value);
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                TKey[] keys = new TKey[_count];
                for (int i = 0; i < _count; i++)
                {
                    keys[i] = _array[i].Key;
                }
                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                TValue[] values = new TValue[_count];
                for (int i = 0; i < _count; i++)
                {
                    values[i] = _array[i].Value;
                }
                return values;
            }
        }

        public int Count => _count;

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                throw new ArgumentException("An element with the same key already exists.");
            }

            if (_count == _array.Length)
            {
                Array.Resize(ref _array, _array.Length * 2);
            }

            _array[_count++] = new KeyValuePair<TKey, TValue>(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _array = new KeyValuePair<TKey, TValue>[4]; // Reset to initial capacity
            _count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_array[i], item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_array[i].Key, key))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            if (array.Length - arrayIndex < _count)
            {
                throw new ArgumentException("The destination array has insufficient space to copy the elements.");
            }

            Array.Copy(_array, 0, array, arrayIndex, _count);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _array[i];
            }
        }

        public bool Remove(TKey key)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_array[i].Key, key))
                {
                    _count--;
                    _array[i] = _array[_count];
                    _array[_count] = default; // Clear the last element
                    return true;
                }
            }
            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_array[i], item))
                {
                    _count--;
                    _array[i] = _array[_count]; // we use this way for Time Complexity O(1) and Minimal Overhead and simplicity 
                    _array[_count] = default; // Clear the last element
                    return true;
                }
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_array[i].Key, key))
                {
                    value = _array[i].Value;
                    return true;
                }
            }
            value = default;
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of SimpleDictionary
            var myDictionary = new SimpleDictionary<int, string>();


            // Adding elements to the dictionary
            myDictionary.Add(1, "One");
            myDictionary.Add(2, "Two");
            myDictionary.Add(3, "Three");


            // Accessing an element by key
            Console.WriteLine($"Element with key 2: {myDictionary[2]}");


            // Updating an element by key
            myDictionary[2] = "Two Updated";
            Console.WriteLine($"Updated element with key 2: {myDictionary[2]}");


            // Iterating over the dictionary
            Console.WriteLine("\nIterating over the dictionary:");
            foreach (var kvp in myDictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }


            // Demonstrate the ContainsKey and Remove functionality
            if (myDictionary.ContainsKey(3))
            {
                Console.WriteLine("\nContains key 3, removing...");
                myDictionary.Remove(3);
            }

            // Display the dictionary after removal
            Console.WriteLine("\nDictionary after removing key 3:");
            foreach (var kvp in myDictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            Console.WriteLine("\n\n====== IDictionary using Array: ======\n");
            // Create an instance of SimpleDictionary
            SimpleArrDictionary<int, string> myArrDictionary = new SimpleArrDictionary<int, string>();

            // Adding elements to the dictionary
            myArrDictionary.Add(1, "One");
            myArrDictionary.Add(2, "Two");
            myArrDictionary.Add(3, "Three");

            // Accessing an element by key
            Console.WriteLine($"Element with key 2: {myArrDictionary[2]}");

            // Updating an element by key
            myArrDictionary[2] = "Two Updated";
            Console.WriteLine($"Updated element with key 2: {myArrDictionary[2]}");

            // Iterating over the dictionary
            Console.WriteLine("\nIterating over the dictionary:");
            foreach (var kvp in myArrDictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            // Demonstrate the ContainsKey and Remove functionality
            if (myArrDictionary.ContainsKey(3))
            {
                Console.WriteLine("\nContains key 3, removing...");
                myArrDictionary.Remove(3);
            }

            // Display the dictionary after removal
            Console.WriteLine("\nDictionary after removing key 3:");
            foreach (var kvp in myArrDictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }


            Console.ReadKey();

        }
    }
}
