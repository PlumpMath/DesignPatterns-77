using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural.Facade
{
	class Program
	{
		//static void Main(string[] args)
		//{
		//	Facade facade = new Facade();
		//	facade.MethodA();
		//	facade.MethodB();

		//	Console.ReadKey();
		//}
	}

	/// <summary>
	/// Subsystem classes   (Bank, Credit, Loan)
	/// 1. implement subsystem functionality.
	/// 2. handle work assigned by the Facade object.
	/// 3. have no knowledge of the facade and keep no reference to it. 
	/// </summary>
	public class SubSystemOne
	{
		public void MethodOne()
		{
			Console.WriteLine(" SubSystemOne Method.");
		}
	}

	public class SubSystemTwo
	{
		public void MeothodTwo()
		{
			Console.WriteLine(" SubSystemTwo Method.");
		}
	}

	public class SubSystemThree
	{
		public void MethodThree()
		{
			Console.WriteLine(" SubSystemThree Method.");
		}
	}

	public class SubSystemFour
	{
		public void MethodFour()
		{
			Console.WriteLine(" SubSystemFour Method.");
		}
	}

	/// <summary>
	/// Facade   (MortgageApplication)
	/// 1. knows which subsystem classes are responsible for a request.
	/// 2. delegates client requests to appropriate subsystem objects.
	/// </summary>
	public class Facade
	{
		private SubSystemOne _one;
		private SubSystemTwo _two;
		private SubSystemThree _three;
		private SubSystemFour _four;

		public Facade()
		{
			_one = new SubSystemOne();
			_two = new SubSystemTwo();
			_three = new SubSystemThree();
			_four = new SubSystemFour();
		}

		public void MethodA()
		{
			Console.WriteLine("\nMethodA() ---- ");
			_one.MethodOne();
			_two.MeothodTwo();
			_four.MethodFour();
		}

		public void MethodB()
		{
			Console.WriteLine("\nMethodB() ---- ");
			_two.MeothodTwo();
			_three.MethodThree();
		}
	}
}
