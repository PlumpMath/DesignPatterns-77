/*
 * Allow an object to alter its behavior when its internal state chagnes. The object will appear 
 * to change its class.
 */
namespace Behavioral.State
{
	using System;

	/*class Program
	{
		static void Main(string[] args)
		{
			Context c = new Context(new ConcreteStateA());

			c.Request();
			c.Request();
			c.Request();
			c.Request();

			Console.ReadKey();
		}
	}

	/// <summary>
	/// State (State)
	/// 1. defines an interface for encapsulating the behavior associated with a particular state of 
	///		state.
	/// </summary>
	public abstract class State
	{
		public abstract void Handle(Context context);
	}

	/// <summary>
	/// Context (Account)
	/// 1. defines the interface of interest to clients.
	/// 2. maintains an instance of a ConcreteState subclass that defines the current state.
	/// </summary>
	public class Context
	{
		private State _state;
		public State State
		{
			get { return _state; }
			set
			{
				_state = value;
				Console.WriteLine("State: " + this._state.GetType().Name);
			}
		}

		public Context(State state)
		{
			this.State = state;
		}

		public void Request()
		{
			this.State.Handle(this);
		}
	}

	/// <summary>
	/// Concrete State (RedState, SilverState, GoldState)
	/// 1. each subclass implements a behavior associated with a state of Context.
	/// </summary>
	public class ConcreteStateA : State
	{
		public override void Handle(Context context)
		{
			context.State = new ConcreteStateB();
		}
	}

	public class ConcreteStateB : State
	{
		public override void Handle(Context context)
		{
			context.State = new ConcreteStateA();
		}
	}*/
}
