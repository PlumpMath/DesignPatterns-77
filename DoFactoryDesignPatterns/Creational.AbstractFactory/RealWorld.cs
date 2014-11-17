using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational.AbstractFactory
{
	class RealWorld
	{
		static void Main()
		{
			ContinentFactory africa = new AfricaFactory();
			AnimalWorld world = new AnimalWorld(africa);
			world.RunFoodChain();

			ContinentFactory america = new AmericaFactory();
			world = new AnimalWorld(america);
			world.RunFoodChain();

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'AbstractFactory' abstract class.
	/// </summary>
	public abstract class ContinentFactory
	{
		public abstract Herbivore CreateHerbivore();
		public abstract Carnivore CreateCarnivore();
	}

	/// <summary>
	/// The 'ConcreteFactory1' class.
	/// </summary>
	public class AfricaFactory : ContinentFactory
	{
		public override Herbivore CreateHerbivore()
		{
			return new Wildebeest();
		}

		public override Carnivore CreateCarnivore()
		{
			return new Lion();
		}
	}

	/// <summary>
	/// The 'ConcreteFactory2' class. 
	/// </summary>
	public class AmericaFactory : ContinentFactory
	{
		public override Herbivore CreateHerbivore()
		{
			return new Bison();
		}

		public override Carnivore CreateCarnivore()
		{
			return new Wolf();
		}
	}

	/// <summary>
	/// The 'AbstractProductA' abstract class.
	/// </summary>
	public abstract class Herbivore
	{
	}

	/// <summary>
	/// The 'AbstractProductB' abstract class.
	/// </summary>
	public abstract class Carnivore
	{
		public abstract void Eat(Herbivore h);
	}

	/// <summary>
	/// The 'ProductA1' class.
	/// </summary>
	public class Wildebeest : Herbivore
	{
	}

	/// <summary>
	/// The 'ProductB1' class.
	/// </summary>
	public class Lion : Carnivore
	{
		public override void Eat(Herbivore h)
		{
			Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
		}
	}

	/// <summary>
	/// The 'ProductA2' class.
	/// </summary>
	public class Bison : Herbivore
	{
	}

	/// <summary>
	/// The 'ProductB2' class.
	/// </summary>
	public class Wolf : Carnivore
	{
		public override void Eat(Herbivore h)
		{
			Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
		}
	}

	/// <summary>
	/// The 'Client' class.
	/// </summary>
	public class AnimalWorld
	{
		private Herbivore _herbivore;
		private Carnivore _carnivore;

		public AnimalWorld(ContinentFactory factory)
		{
			_carnivore = factory.CreateCarnivore();
			_herbivore = factory.CreateHerbivore();
		}

		public void RunFoodChain()
		{
			_carnivore.Eat(_herbivore);
		}
	}
}
