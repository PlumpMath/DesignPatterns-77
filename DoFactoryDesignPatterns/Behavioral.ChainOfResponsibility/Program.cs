using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.ChainOfResponsibility
{
	class Program
	{
		//static void Main(string[] args)
		//{
		//	Handler h1 = new ConcreteHandlerA();
		//	Handler h2 = new ConcreteHandlerB();
		//	Handler h3 = new ConcreteHandlerC();
		//	h1.SetSuccessor(h2);
		//	h2.SetSuccessor(h3);

		//	int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

		//	foreach (int request in requests)
		//	{
		//		h1.HandleRequest(request);
		//	}
		//	Console.ReadKey();
		//}
	}

	/// <summary>
	/// Handler (Approver)
	/// 1. defines an interface for handling the requests.
	/// 2. (optional)implements the successor link.
	/// </summary>
	public abstract class Handler
	{
		protected Handler successor;

		public void SetSuccessor(Handler successor)
		{
			this.successor = successor;
		}

		public abstract void HandleRequest(int request);
	}

	/// <summary>
	/// ConcreteHandler (Director, VicePresident, President)
	/// 1. handles requests it is responsible for
	/// 2. can access its successor
	/// 3. if the ConcreteHandler can handle the request, it does so; otherwise if forwards the request
	///		to its successor.
	/// </summary>
	public class ConcreteHandlerA : Handler
	{
		public override void HandleRequest(int request)
		{
			if (request >= 0 && request < 10)
			{
				Console.WriteLine("{0} handle request {1}", this.GetType().Name, request);
			}
			else if (successor != null)
			{
				successor.HandleRequest(request);
			}
		}
	}

	public class ConcreteHandlerB : Handler
	{
		public override void HandleRequest(int request)
		{
			if (request >= 10 && request < 20)
			{
				Console.WriteLine("{0} handle request {1}", this.GetType().Name, request);
			}
			else if (successor != null)
			{
				successor.HandleRequest(request);
			}
		}
	}

	public class ConcreteHandlerC : Handler
	{
		public override void HandleRequest(int request)
		{
			if (request >= 20 && request < 30)
			{
				Console.WriteLine("{0} handle request {1}", this.GetType().Name, request);
			}
			else if (successor != null)
			{
				successor.HandleRequest(request);
			}
		}
	}
}
