using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural.Adapter
{
	class Program
	{
		//static void Main(string[] args)
		//{
		//	//Create adapter and place a request
		//	Target target =new Adapter();
		//	target.Request();

		//	//Wait for user
		//	Console.ReadKey();
		//}
	}

	///<summary>
	///The 'Target' class
	///</summary>
	public class Target
	{
		public virtual void Request()
		{
			Console.WriteLine("Called Target Request()");
		}
	}

	///<summary>
	///The 'Adapter' class
	///</summary>
	public class Adapter:Target
	{
		private Adaptee _adaptee =new Adaptee();

		public override void Request()
		{
			//Possibly do some other work
			//and then call Specific Request
			_adaptee.SpecificRequest();
		}
	}

	///<summary>
	///The 'Adaptee' class
	///</summary>
	public class Adaptee
	{
		public void SpecificRequest()
		{
			Console.WriteLine("Called Specific Request()");
		}
	}
}