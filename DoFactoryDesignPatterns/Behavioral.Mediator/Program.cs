using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Mediator
{
	class Program
	{
		//static void Main(string[] args)
		//{
		//	ConcreteMediator m = new ConcreteMediator();

		//	ConcreteColleague1 c1 = new ConcreteColleague1(m);
		//	ConcreteColleague2 c2 = new ConcreteColleague2(m);

		//	m.Colleague1 = c1;
		//	m.Colleague2 = c2;

		//	c1.Send("How are you?");
		//	c2.Send("Fine, thank you.");

		//	Console.ReadKey();
		//}
	}

	/// <summary>
	/// Mediator (IChatroom)
	/// 1. defines an interface for communicating with Colleague objects.
	/// </summary>
	public abstract class Mediator
	{
		public abstract void Send(string message, Colleague colleague);
	}

	/// <summary>
	/// ConcreteMediator (Chatroom)
	/// 1. implements cooperative behavior by coordinating Colleague objects.
	/// 2. knows and maintains its colleagues.
	/// </summary>
	public class ConcreteMediator : Mediator
	{
		private ConcreteColleague1 _colleague1;

		public ConcreteColleague1 Colleague1
		{
			get { return _colleague1; }
			set { _colleague1 = value; }
		}

		private ConcreteColleague2 _colleague2;

		public ConcreteColleague2 Colleague2
		{
			get { return _colleague2; }
			set { _colleague2 = value; }
		}

		public override void Send(string message, Colleague colleague)
		{
			if (colleague == this.Colleague1)
			{
				this.Colleague2.Notify(message);
			}
			else
			{
				this.Colleague1.Notify(message);
			}
		}
	}

	public abstract class Colleague
	{
		protected Mediator mediator;

		public Colleague(Mediator mediator)
		{
			this.mediator = mediator;
		}
	}

	/// <summary>
	/// Colleague classes (Participant)
	/// 1. each Colleague class knows its Mediator object.
	/// 2. each colleague communicates with its mediator whenever it would have otherwise communicated
	///		with another colleague.
	/// </summary>
	public class ConcreteColleague1 : Colleague
	{
		public ConcreteColleague1(Mediator mediator)
			: base(mediator)
		{
		}

		public void Send(string message)
		{
			mediator.Send(message, this);
		}

		public void Notify(string message)
		{
			Console.WriteLine("Colleague1 gets message: " + message);
		}
	}

	public class ConcreteColleague2 : Colleague
	{
		public ConcreteColleague2(Mediator mediator)
			: base(mediator)
		{
		}

		public void Send(string message)
		{
			mediator.Send(message, this);
		}

		public void Notify(string message)
		{
			Console.WriteLine("Colleague2 gets message: " + message);
		}
	}
}
