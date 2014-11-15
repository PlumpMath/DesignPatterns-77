/*
 * Define an interface for creating an object, but let subclasses decide which class to instatiate.
 * Factory Method lets a class defer instantiation to subclasses.
 */
namespace Creational.FactoryMethod
{
	using System;

	//class Program
	//{
	//	static void Main(string[] args)
	//	{
	//		Creator[] creators = new Creator[2];

	//		creators[0] = new ConcreteCreatorA();
	//		creators[1] = new ConcreteCreatorB();

	//		foreach (Creator creator in creators)
	//		{
	//			Product product = creator.FactoryMethod();
	//			Console.WriteLine("Created {0}", product.GetType().Name);
	//		}

	//		Console.ReadKey();
	//	}
	//}

	/// <summary>
	/// Product (Page)
	/// 1. defines the interface of objects the factory method creates.
	/// </summary>
	public abstract class Product
	{
	}

	/// <summary>
	/// ConcreteProduct (SkillsPage, EducationPage, ExperiencePage)
	/// 1. implements the Product interface.
	/// </summary>
	public class ConcreteProductA : Product
	{
	}

	public class ConcreteProductB : Product
	{
	}

	/// <summary>
	/// Creator (Document)
	/// 1. declares the factory method, which returns an object of type Product. Creator may also
	///		define a default implementation of the factory method that returns a default ConcreteProduct
	///		object.
	/// </summary>
	public abstract class Creator
	{
		public abstract Product FactoryMethod();
	}

	/// <summary>
	/// ConcreteCreator (Report, Resume)]
	/// 1. overrides the factory method to return an instance of a ConcreteProduct.
	/// </summary>
	public class ConcreteCreatorA : Creator
	{
		public override Product FactoryMethod()
		{
			return new ConcreteProductA();
		}
	}

	public class ConcreteCreatorB : Creator
	{
		public override Product FactoryMethod()
		{
			return new ConcreteProductB();
		}
	}

}
