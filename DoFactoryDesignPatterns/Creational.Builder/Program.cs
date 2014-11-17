/*
 * Separate the construction of a complex object from its representation so that the same construction
 * process can create different representations.
 */
namespace Creational.Builder
{
	using System;
	using System.Collections.Generic;
	class Program
	{
		//static void Main(string[] args)
		//{
		//	Director director = new Director();

		//	Builder b1 = new ConcreteBuilder1();
		//	Builder b2 = new ConcreteBuilder2();

		//	director.Construct(b1);
		//	Product p1 = b1.GetResult();
		//	p1.Show();

		//	director.Construct(b2);
		//	Product p2 = b2.GetResult();
		//	p2.Show();

		//	Console.ReadKey();
		//}
	}

	/// <summary>
	/// Director (Shop)
	/// 1. constructs an object using the Builder interface.
	/// </summary>
	public class Director
	{
		public void Construct(Builder builder)
		{
			builder.BuildPartA();
			builder.BuildPartB();
		}
	}

	/// <summary>
	/// Builder (VehicleBuilder)
	/// 1. specifies an abstract interface for creating parts of a Product object.
	/// </summary>
	public abstract class Builder
	{
		public abstract void BuildPartA();
		public abstract void BuildPartB();
		public abstract Product GetResult();
	}

	/// <summary>
	/// ConcreteBuilder (MotorCycleBuilder, CarBuilder, ScooterBuilder)
	/// 1. constructs and assembles parts of the product by implementing the Builder interface.
	/// 2. defines and keeps track of the representation it creates
	/// 3. provides an interface for retrieving the product.
	/// </summary>
	public class ConcreteBuilder1 : Builder
	{
		private Product _product = new Product();

		public override void BuildPartA()
		{
			_product.Add("PartA");
		}

		public override void BuildPartB()
		{
			_product.Add("PartB");
		}

		public override Product GetResult()
		{
			return this._product;
		}
	}

	public class ConcreteBuilder2 : Builder
	{
		private Product _product = new Product();

		public override void BuildPartA()
		{
			this._product.Add("PartX");
		}

		public override void BuildPartB()
		{
			this._product.Add("PartY");
		}

		public override Product GetResult()
		{
			return this._product;
		}
	}

	/// <summary>
	/// Product (Vehicle)
	/// 1. represents the complex object under construction. ConcreteBuilder builds the product's
	///		internal representation and defines the process by which it's assembled.
	///	2. includes classes that define the constituent parts, including interfaces for assembling
	///		parts into the final result.
	/// </summary>
	public class Product
	{
		private List<string> _parts = new List<string>();

		public void Add(string part)
		{
			_parts.Add(part);
		}

		public void Show()
		{
			Console.WriteLine("\nProduct Parts --------");
			foreach (string part in _parts)
			{
				Console.WriteLine(part);
			}
		}
	}
}
