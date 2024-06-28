using System;
using System.Collections.Generic;

namespace IComparable
{
	class Person : IComparable<Person>
	{
		public string Name { get; set; }
		public int Age { get; set; }

		// Constructor for easier initialization
		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}
		// Implementing the CompareTo method for Person class
		public int CompareTo(Person other)
		{
			// If other is not a valid object reference, this instance is greater.
			if (other == null) return 1;
			// Use the Age property to determine the order of Person instances.
			return (this.Age.CompareTo(other.Age));
		}

		// Override ToString to make (Object) output easier to read
		public override string ToString()
		{
			return $"{Name}, {Age} Years Old";
		}


		//  Using Equals and GetHashCode + Operator == and !=  to compare 2 Instances
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			var other = obj as Person;
			if (other == null) return false;
			return (this.Name == other.Name) && (this.Age == other.Age);
		}

		public override int GetHashCode()
		{
			var hash = 13;
			hash = hash * 23 + Name.GetHashCode();
			hash = hash * 23 + Age.GetHashCode();
			return hash;
		}

		public static bool operator ==(Person x, Person y)
		{
			if (object.ReferenceEquals(x, y))
				return true;

			if (x is null || y is null)
				return false;

			return x.Equals(y);
		}
		public static bool operator !=(Person x, Person y)
		{

			return !(x == y);
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			// Creating a list of Person instances
			List<Person> people = new List<Person>
		{
			new Person("Hamza", 30),
			new Person("Ahmed", 25),
			new Person("Ali", 28),
			new Person("Hamza", 28),
			new Person("Hamza", 30),
		};


			// Sorting the list using IComparable implementation
			people.Sort();


			// Printing the sorted list
			Console.WriteLine("People sorted by age:");
			foreach (Person person in people)
			{
				Console.WriteLine(person.ToString());
			}
            Console.WriteLine("\n");


			// compare Person by Name and Age ( equal HashCode and Operator ==)
			// if two instances have the same reference or the same values are equals 
			if (people[3] == people[4])
				Console.WriteLine($"{people[3]} Are equal {people[4]}");
			else
				Console.WriteLine($"{people[3]} Are Not Equal {people[4]}");

			if (people[2] == people[3])
				Console.WriteLine($"{people[2]} Are equal {people[3]}");
			else
				Console.WriteLine($"{people[2]} Are Not Equal {people[3]}");



			Console.ReadKey();
		}
	}
}
