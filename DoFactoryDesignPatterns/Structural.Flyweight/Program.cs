using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural.Flyweight
{
	class Program
	{
		//static void Main(string[] args)
		//{
		//	int extrinsicState = 22;
		//	FlyweightFactory factory = new FlyweightFactory();

		//	Flyweight fx = factory.GetFlyweight("X");
		//	fx.Operation(--extrinsicState);

		//	Flyweight fy = factory.GetFlyweight("Y");
		//	fy.Operation(--extrinsicState);

		//	Flyweight fz = factory.GetFlyweight("Z");
		//	fz.Operation(--extrinsicState);

		//	UnsharedConcreteFlyweight fu = new UnsharedConcreteFlyweight();
		//	fu.Operation(--extrinsicState);

		//	Console.ReadKey();
		//}
	}

	/// <summary>
	/// FlyweightFactory (CharacterFactory)
	/// 1. creates and manages flyweight objects
	/// 2. ensures that flyweight are shared properly. When a client requests a flyweight,
	///		the FlyweightFactory objects assets an existing instance or creates one, if
	///		none exists.
	/// </summary>
	public class FlyweightFactory
	{
		private Dictionary<string, Flyweight> flyweights = new Dictionary<string, Flyweight>();

		public FlyweightFactory()
		{
			flyweights.Add("X", new ConcreteFlyweight());
			flyweights.Add("Y", new ConcreteFlyweight());
			flyweights.Add("Z", new ConcreteFlyweight());
		}

		public Flyweight GetFlyweight(string key)
		{
			return ((Flyweight)flyweights[key]);
		}
	}

	/// <summary>
	/// Flyweight (Character)
	/// 1. declares an interface through with flyweights can receive and act on extrinsic state.
	/// </summary>
	public abstract class Flyweight
	{
		public abstract void Operation(int extrinsicState);
	}

	/// <summary>
	/// ConcreteFlyweight (CharacterA, CharacterB,...,CharacterZ)
	/// 1. implements the Flyweight interface and adds storage for intrinsic state, if any. A ConcreteFlyweight
	///		object must be sharable. Any state it stores must be intrinsic, that is, it muse be independent of
	///		the ConcreteFlyweight object's context.
	/// </summary>
	public class ConcreteFlyweight : Flyweight
	{
		public override void Operation(int extrinsicState)
		{
			Console.WriteLine("ConcreteFlyweight: " + extrinsicState);
		}
	}

	/// <summary>
	/// UnsharedConcreteFlyweight (not used)
	/// 1. not all Flyweight subclasses need to be shared. The Flyweight interface *enables* sharing,
	///		but it doesn't enforce it. It is common for UnsharedConcreteFlyweight objects to have
	///		ConcreteFlyweight objects as children at some level in the flyweight object structure (as
	///		the Row and Column classes have).
	/// </summary>
	public class UnsharedConcreteFlyweight : Flyweight
	{
		public override void Operation(int extrinsicState)
		{
			Console.WriteLine("UnsharedConcreteFlyweight: " + extrinsicState);
		}
	}
}
