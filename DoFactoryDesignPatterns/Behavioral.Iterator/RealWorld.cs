using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Iterator
{
	class RealWorld
	{
		static void Main()
		{
			Collection collection = new Collection();
			collection[0] = new Item("Item 0");
			collection[1] = new Item("Item 1");
			collection[2] = new Item("Item 2");
			collection[3] = new Item("Item 3");
			collection[4] = new Item("Item 4");
			collection[5] = new Item("Item 5");
			collection[6] = new Item("Item 6");
			collection[7] = new Item("Item 7");
			collection[8] = new Item("Item 8");

			Iterator iterator = new Iterator(collection);

			iterator.Step = 1;
			Console.WriteLine("Iterating over collection:");
			for (Item item = iterator.First(); !iterator.IsDone; item = iterator.Next())
			{
				Console.WriteLine(item.Name);
			}

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Aggregate' interface.
	/// </summary>
	interface IAbstractCollection
	{
		Iterator CreateIterator();
	}

	/// <summary>
	/// The 'ConcreteAggrate' class.
	/// </summary>
	public class Collection : IAbstractCollection
	{
		private ArrayList _items = new ArrayList();
		public Iterator CreateIterator()
		{
			return new Iterator(this);
		}

		public int Count { get { return _items.Count; } }

		public object this[int index]
		{
			get { return _items[index]; }
			set { _items.Add(value); }
		}
	}

	/// <summary>
	/// The 'Iterator' interface.
	/// </summary>
	interface IAbstractIterator
	{
		Item First();
		Item Next();
		bool IsDone { get; }
		Item CurrentItem { get; }
	}

	public class Iterator : IAbstractIterator
	{
		private Collection _collection;
		private int _current = 0;
		private int _step = 1;

		public int Step
		{
			get { return _step; }
			set { _step = value; }
		}

		public Iterator(Collection collection)
		{
			this._collection = collection;
		}

		public Item First()
		{
			_current = 0;
			return _collection[_current] as Item;
		}

		public Item Next()
		{
			_current += this.Step;
			if (!this.IsDone)
			{
				return _collection[_current] as Item;
			}
			else
			{
				return null;
			}
		}

		public bool IsDone
		{
			get { return _current >= _collection.Count; }
		}

		public Item CurrentItem
		{
			get { return _collection[_current] as Item; }
		}
	}

	/// <summary>
	/// A collection item.
	/// </summary>
	public class Item
	{
		public string Name { get; private set; }

		public Item(string name)
		{
			this.Name = name;
		}
	}
}
