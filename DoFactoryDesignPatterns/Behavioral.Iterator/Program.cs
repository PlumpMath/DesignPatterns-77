using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Iterator
{
	//class Program
	//{
	//	static void Main(string[] args)
	//	{
	//		ConcrateAggregate a = new ConcrateAggregate();
	//		a[0] = "Item A";
	//		a[1] = "Item B";
	//		a[2] = "Item C";
	//		a[3] = "Item D";

	//		ConcreteIterator i = new ConcreteIterator(a);
	//		Console.WriteLine("Iterating over collection:");
	//		object item = i.First();
	//		while (!i.IsDone())
	//		{
	//			Console.WriteLine(item);
	//			item = i.Next();
	//		}

	//		Console.ReadKey();
	//	}
	//}

	///// <summary>
	///// Iterator (AbstractIterator)
	///// 1. difines an interface for accessing and traversing elements
	///// </summary>
	//public abstract class Iterator
	//{
	//	public abstract object First();
	//	public abstract object Next();
	//	public abstract bool IsDone();
	//	public abstract object CurrentItem();
	//}

	///// <summary>
	///// ConcreteIterator (Iterator)
	///// 1. implements the Iterator interface.
	///// 2. keeps track of the current position in the traversal of the aggregate.
	///// </summary>
	//public class ConcreteIterator : Iterator
	//{
	//	private ConcrateAggregate _aggregate;
	//	private int _current = 0;

	//	public ConcreteIterator(ConcrateAggregate aggregate)
	//	{
	//		this._aggregate = aggregate;
	//	}

	//	public override object First()
	//	{
	//		return _aggregate[0];
	//	}

	//	public override object Next()
	//	{
	//		object ret = null;
	//		if (_current < _aggregate.Count)
	//		{
	//			ret = _aggregate[++_current];
	//		}
	//		return ret;
	//	}

	//	public override bool IsDone()
	//	{
	//		return _current >= _aggregate.Count;
	//	}

	//	public override object CurrentItem()
	//	{
	//		return _aggregate[_current];
	//	}
	//}

	///// <summary>
	///// Aggregate (AbstractCollection)
	///// 1. defines an interface for creating an Iterator object.
	///// </summary>
	//public abstract class Aggregate
	//{
	//	public abstract Iterator CreateIterator();
	//}

	///// <summary>
	///// ConcreteAggregate (Collection)
	///// 1. implements the Iterator creation interface to return an instance fo the proper ConcreteIterator.
	///// </summary>
	//public class ConcrateAggregate : Aggregate
	//{
	//	private ArrayList _items = new ArrayList();
	//	public override Iterator CreateIterator()
	//	{
	//		throw new NotImplementedException();
	//	}

	//	public int Count
	//	{
	//		get
	//		{
	//			return _items.Count;
	//		}
	//	}

	//	/// <summary>
	//	/// Indexer
	//	/// </summary>
	//	public object this[int index]
	//	{
	//		get { return _items[index]; }
	//		set { _items.Insert(index, value); }
	//	}
	//}
}
