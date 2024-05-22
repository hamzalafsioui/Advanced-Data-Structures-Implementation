using System;
using System.Collections;
using System.Collections.Generic;


namespace CustomCollectionExample
{
    public class SimpleList<T> : IList<T>
    {
        private List<T> _items = new List<T>();


        public T this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }


        public int Count => _items.Count;
        public bool IsReadOnly => false;


        public void Add(T item) => _items.Add(item);
        public void Clear() => _items.Clear();
        public bool Contains(T item) => _items.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);
        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
        public int IndexOf(T item) => _items.IndexOf(item);
        public void Insert(int index, T item) => _items.Insert(index, item);
        public bool Remove(T item) => _items.Remove(item);
        public void RemoveAt(int index) => _items.RemoveAt(index);


        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
    }

    /// <summary>
    /// Implementing IList by Using Array
    /// </summary>
    public class SimpleArray<T> : IList<T>
    {
        private T[] _Items;
        private int _Count;

        public SimpleArray(int size)
        {
            _Items = new T[size];
            _Count = 0;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _Count)
                    throw new ArgumentOutOfRangeException("index");
                return _Items[index];

            }
            set
            {
                if (index < 0 || index >= _Count)
                    throw new ArgumentOutOfRangeException("index");
                _Items[index] = value;
            }
        }

        public int Count => _Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (_Count >= _Items.Length)
            {
                throw new InvalidOperationException("Collection is full");
            }

            _Items[_Count++] = item;
        }

        public void Clear()
        {
            for (int i = 0; i < _Count; i++)
            {
                _Items[i] = default(T);
            };
            _Count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _Count; i++)
            {
                if (_Items[i].Equals(item))
                    return true;
            };
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null");
            if (array.Length - arrayIndex < _Count)
                throw new ArgumentOutOfRangeException("array is not enough");
            for (int i = 0; i < _Count; i++)
            {
                array[arrayIndex + i] = _Items[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _Count; i++)
            {
                yield return _Items[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _Count; i++)
            {
                if (_Items[i].Equals(item))
                    return i;
            };
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (_Count == _Items.Length)
            {
                Array.Resize(ref _Items, _Items.Length * 2);
            }

            if (index < _Count)
            {
                Array.Copy(_Items, index, _Items, index + 1, _Count - index);
            }

            _Items[index] = item;
            _Count++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < _Count; i++)
            {
                if (_Items[i].Equals(item))
                {
                    for (int j = i; j < _Count - 1; j++)
                    {
                        _Items[j] = _Items[j + 1];
                    }
                    _Items[_Count - 1] = default(T);
                    _Count--;
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _Count)
                throw new ArgumentOutOfRangeException("index");
            T Item = _Items[index];
            Remove(Item);

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
            SimpleList<string> myList1 = new SimpleList<string>();
            myList1.Add("First");
            myList1.Add("Second");
            myList1.Insert(1, "Inserted");


            Console.WriteLine("List after adding and inserting:");
            foreach (var item in myList1)
            {
                Console.WriteLine(item);
            }


            myList1.RemoveAt(1); // Removes "Inserted"
            myList1[0] = "Updated First"; // Update the first item


            Console.WriteLine("\nList after removing and updating:");
            foreach (var item in myList1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n\n===== Implementing IList by Array: =====\n");
            SimpleArray<string> myList2 = new SimpleArray<string>(5); // Initial size of the array
            myList2.Add("First");
            myList2.Add("Second");
            myList2.Insert(1, "Inserted");


            Console.WriteLine("List after adding and inserting:");
            foreach (var item in myList2)
            {
                Console.WriteLine(item);
            }


            myList2.RemoveAt(1); // Removes "Inserted"
            myList2[0] = "Updated First"; // Update the first item


            Console.WriteLine("\nList after removing and updating:");
            foreach (var item in myList2)
            {
                Console.WriteLine(item);
            }



            Console.ReadLine();
        }
    }
}
