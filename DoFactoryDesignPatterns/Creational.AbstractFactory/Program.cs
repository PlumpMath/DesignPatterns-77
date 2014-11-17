/*
 * Provide an interface for creating families of related or dependent objects without specifying
 * their concrete classes.
 */
namespace Creational.AbstractFactory
{
	using System;
	//class Program
	//{
	//	static void Main(string[] args)
	//	{
	//		AbstractFactory factory1 = new ConcreteFactory1();
	//		Client client1 = new Client(factory1);
	//		client1.Run();

	//		AbstractFactory factory2 = new ConcreteFactory2();
	//		Client client2 = new Client(factory2);
	//		client2.Run();

	//		Console.ReadKey();
	//	}
	//}

	/// <summary>
	/// AbstractFactory (ContinentFactory)
	/// 1. declares an interface for operations that create abstract products.
	/// </summary>
	public abstract class AbstractFactory
	{
		public abstract AbstractProductA CreateProductA();
		public abstract AbstractProductB CreateProductB();
	}

	/// <summary>
	/// ConcreteFactory (AfricaFactory, AmericaFactory)
	/// 1. implements the operations to create concrete product objects.
	/// </summary>
	public class ConcreteFactory1 : AbstractFactory
	{
		public override AbstractProductA CreateProductA()
		{
			return new ProductA1();
		}

		public override AbstractProductB CreateProductB()
		{
			return new ProductB1();
		}
	}

	public class ConcreteFactory2 : AbstractFactory
	{
		public override AbstractProductA CreateProductA()
		{
			return new ProductA2();
		}

		public override AbstractProductB CreateProductB()
		{
			return new ProductB2();
		}
	}

	/// <summary>
	/// AbstractProduct (Herbivore, Carnivore)
	/// 1. declares an interface for a type of product object.
	/// </summary>
	public abstract class AbstractProductA
	{
	}

	public abstract class AbstractProductB
	{
		public abstract void Interact(AbstractProductA a);
	}

	/// <summary>
	/// Product (Wildebeest, Lion, Bison, Wolf)
	/// 1. defines a product object to be created by the corresponding concrete factory.
	/// 2. implements the AbstractProduct interface
	/// </summary>
	public class ProductA1 : AbstractProductA
	{
	}

	public class ProductB1 : AbstractProductB
	{
		public override void Interact(AbstractProductA a)
		{
			Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
		}
	}

	public class ProductA2 : AbstractProductA
	{
	}

	public class ProductB2 : AbstractProductB
	{
		public override void Interact(AbstractProductA a)
		{
			Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
		}
	}

	/// <summary>
	/// Client (AnimalWorld)
	/// 1. uses interfaces declared by AbstractFactory and AbstractProduct classes.
	/// </summary>
	public class Client
	{
		private AbstractProductA _abstractProductA;
		private AbstractProductB _abstractProductB;

		public Client(AbstractFactory factory)
		{
			_abstractProductA = factory.CreateProductA();
			_abstractProductB = factory.CreateProductB();
		}

		public void Run()
		{
			_abstractProductB.Interact(_abstractProductA);
		}
	}
}
