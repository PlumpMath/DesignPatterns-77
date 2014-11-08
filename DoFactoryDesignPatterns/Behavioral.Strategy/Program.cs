/*
 * Define a family of algorithms, encapsulate each one, and make them interchangeable.
 * Strategy lets the algorithm vary independently from clients that use it.
 */
namespace Behavioral.Strategy
{
	using System;
	class Program
	{
		//static void Main(string[] args)
		//{
		//	Context context;

		//	context = new Context(new ConcreteStrategyA());
		//	context.ContextInterface();

		//	context = new Context(new ConcreteStrategyB());
		//	context.ContextInterface();

		//	context = new Context(new ConcreteStrategyC());
		//	context.ContextInterface();

		//	Console.ReadKey();
		//}
	}

	/// <summary>
	/// Strategy (SortStrategy)
	/// 1. declares an interface common to all supported algorithms. Context uses this interface to call
	///		this algorithm defined by a ConcreteStrategy.
	/// </summary>
	public abstract class Strategy
	{
		public abstract void AlgorithmInterface();
	}

	/// <summary>
	/// ConcreteStrategy (QuickSort, ShellSort, MergeSort)
	/// 1. implements the algorithm using the Strategy interface.
	/// </summary>
	public class ConcreteStrategyA : Strategy
	{
		public override void AlgorithmInterface()
		{
			Console.WriteLine("Called ConcreteStrategyA.AlgorithmInterface.");
		}
	}

	public class ConcreteStrategyB : Strategy
	{
		public override void AlgorithmInterface()
		{
			Console.WriteLine("Called ConcreteStrategyB.AlgorithmInterface.");
		}
	}

	public class ConcreteStrategyC : Strategy
	{
		public override void AlgorithmInterface()
		{
			Console.WriteLine("Called ConcreteStrategyC.AlgorithmInterface.");
		}
	}

	/// <summary>
	/// Context (SortedList)
	/// 1. is configured with a ConcreteStrategy object.
	/// 2. maintains a reference to a Strategy object.
	/// 3. may define an interface that lets Strategy access its data.
	/// </summary>
	public class Context
	{
		private Strategy _strategy;

		public Context(Strategy strategy)
		{
			this._strategy = strategy;
		}

		public void ContextInterface()
		{
			this._strategy.AlgorithmInterface();
		}
	}


}
