/*
 * Definition: Decouple an abstraction from its implementation so that the two can vary independently. 
 */

namespace Structural.Bridge
{
	using System;

	class Program
	{
		//static void Main(string[] args)
		//{
		//	Abstraction abs = new RefinedAbstraction();
		//	Implementor impA = new ConcreteImplementorA();
		//	abs.Implementor = impA;
		//	abs.Operation();

		//	Implementor impB = new ConcreteImplementorB();
		//	abs.Implementor = impB;
		//	abs.Operation();

		//	Console.ReadKey();
		//}
	}

	/// <summary>
	/// Abstraction(BusinessObject)
	/// 1. defines the abstraction's interface.
	/// 2. maintains a reference to an object of type Implementor. 
	/// </summary>
	public abstract class Abstraction
	{
		protected Implementor implementor;

		public Implementor Implementor
		{
			//private get { return implementor; }
			set { implementor = value; }
		}

		public virtual void Operation()
		{
			implementor.Operation();
		}
	}

	/// <summary>
	/// RefinedAbstraction   (CustomersBusinessObject)
	/// 1. extends the interface defined by Abstraction. 
	/// </summary>
	public class RefinedAbstraction : Abstraction
	{
		public override void Operation()
		{
			base.Operation();
		}
	}

	/// <summary>
	/// Implementor   (DataObject)
	/// 1. defines the interface for implementation classes. This interface doesn't have to correspond exactly to Abstraction's interface;
	///		in fact the two interfaces can be quite different. Typically the Implementation interface provides only primitive operations,
	///		and Abstraction defines higher-level operations based on these primitives. 
	/// </summary>
	public abstract class Implementor
	{
		public abstract void Operation();
	}

	/// <summary>
	/// ConcreteImplementor   (CustomersDataObject)
	/// 1. implements the Implementor interface and defines its concrete implementation.
	/// </summary>
	public class ConcreteImplementorA : Implementor
	{
		public override void Operation()
		{
			Console.WriteLine("ConcreteImplementorA Operation");
		}
	}

	public class ConcreteImplementorB : Implementor
	{
		public override void Operation()
		{
			Console.WriteLine("ConcreteImplementorB Operation");
		}
	}
}
