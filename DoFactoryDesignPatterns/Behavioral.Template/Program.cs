namespace Behavioral.Template
{
	using System;
	class Program
	{
		//static void Main(string[] args)
		//{
		//	AbstractClass aA = new ConcreteClassA();
		//	aA.TemplateMethod();

		//	AbstractClass aB = new ConcreteClassB();
		//	aB.TemplateMethod();

		//	Console.ReadKey();
		//}
	}

	/// <summary>
	/// AbstractClass (DataObject)
	/// 1. defines abstract primitive operations that concrete subclasses define to implement steps of
	///		an algorithm.
	///	2. implements a template method defining the skeleton of an algorithm. The template method calls
	///		primitive operations as well as operations defined in AbstractClass or those of other object.
	/// </summary>
	public abstract class AbstractClass
	{
		public abstract void PrimitiveOperation1();
		public abstract void PrimitiveOperation2();

		public void TemplateMethod()
		{
			this.PrimitiveOperation1();
			this.PrimitiveOperation2();
			Console.WriteLine("");
		}
	}

	/// <summary>
	/// ConcreteClass (CustomerDataObject)
	/// 1. implements the primitive operations to carry out subclass-specific steps of the algorithm.
	/// </summary>
	public class ConcreteClassA : AbstractClass
	{
		public override void PrimitiveOperation1()
		{
			Console.WriteLine("ConcreteClassA.PrimitiveOperation1");
		}

		public override void PrimitiveOperation2()
		{
			Console.WriteLine("ConcreteClassA.PrimitiveOperation2");
		}
	}

	public class ConcreteClassB : AbstractClass
	{
		public override void PrimitiveOperation1()
		{
			Console.WriteLine("ConcreteClassB.PrimitiveOperation1");
		}

		public override void PrimitiveOperation2()
		{
			Console.WriteLine("ConcreteClassB.PrimitiveOperation2");
		}
	}
}
