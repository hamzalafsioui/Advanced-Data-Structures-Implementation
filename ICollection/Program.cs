using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomCollectionExample
{
	public class SimpleCollection<T> : ICollection<T>
	{
		private List<T> items = new List<T>();


		public int Count => items.Count;


		public bool IsReadOnly => false;


		public void Add(T item)
		{
			items.Add(item);
		}


		public void Clear()
		{
			items.Clear();
		}


		public bool Contains(T item)
		{
			return items.Contains(item);
		}


		public void CopyTo(T[] array, int arrayIndex)
		{
			items.CopyTo(array, arrayIndex);
		}


		public bool Remove(T item)
		{
			return items.Remove(item);
		}


		public IEnumerator<T> GetEnumerator()
		{
			return items.GetEnumerator();
		}


		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	/// <summary>
	/// Implementing ICollection using Array 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class MyArrCollection<T> : ICollection<T>
	{
		private T[] Items;
		private int _count;

		public MyArrCollection(int size)
		{
			Items = new T[size];
			_count = 0;
		}

		public int Count => _count;

		public bool IsReadOnly => false;

		public void Add(T item)
		{
			if (_count >= Items.Length)
				throw new InvalidOperationException("Collection is full");

			Items[_count++] = item;
		}

		public void Clear()
		{
			for (int i = 0; i < _count; i++)
			{
				Items[i] = default(T);
			}
			_count = 0;
		}

		public bool Contains(T item)
		{
			for (int i = 0; i < _count; i++)
			{
				if (Items[i].Equals(item))
					return true;
			}
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
				throw new ArgumentNullException(nameof(array));

			if (arrayIndex < 0)
				throw new ArgumentOutOfRangeException(nameof(arrayIndex));

			if (array.Length - arrayIndex < _count)
				throw new ArgumentException("Destination array is not large enough to hold the elements.");

			for (int i = 0; i < _count; i++)
			{
				array[arrayIndex + i] = Items[i];
			}
		}

		public bool Remove(T item)
		{
			for (int i = 0; i < _count; i++)
			{
				if (Items[i].Equals(item))
				{
					for (int j = i; j < _count - 1; j++)
					{
						Items[j] = Items[j + 1]; // this way have a time complexity o(n) but it keeps the order
					}
					Items[_count - 1] = default(T);
					_count--;
					return true;
				}
			}
			return false;
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < _count; i++)
			{
				yield return Items[i];
			}
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
			SimpleCollection<string> shoppingCart = new SimpleCollection<string>();
			shoppingCart.Add("Apple");
			shoppingCart.Add("Banana");
			shoppingCart.Add("Carrot");


			Console.WriteLine($"Items in cart: {shoppingCart.Count}");

			if (shoppingCart.Contains("Banana"))
			{
				shoppingCart.Remove("Banana");
				Console.WriteLine("Banana removed from the cart.");
			}


			Console.WriteLine("Final items in the cart:");
			foreach (var item in shoppingCart)
			{
				Console.WriteLine(item);
			}


			Console.WriteLine("\n\n===== Using myArrCollection: =====\n");
			MyArrCollection<string> FruitArray = new MyArrCollection<string>(5);
			FruitArray.Add("Apple");
			FruitArray.Add("Orange");
			FruitArray.Add("Banana");
			foreach (var item in FruitArray)
			{
				Console.WriteLine(item);
			}
			FruitArray.Remove("Orange");
			Console.WriteLine("FruitArray after removing Orange:");
			foreach (var item in FruitArray)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine($"Is array contains(Banana): {FruitArray.Contains("Banana")}");



			Console.ReadKey();
		}
	}
}
