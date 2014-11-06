using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Memento
{
	/*class Program
	{
		static void Main(string[] args)
		{
			Originator o = new Originator();
			o.State = "On";

			Caretaker c = new Caretaker();
			c.Memento = o.CreateMemento();

			o.State = "Off";

			o.SetMemento(c.Memento);

			Console.ReadKey();
		}
	}

	/// <summary>
	/// Originator (SalesProspect)
	/// 1. creates a memento containing a snapshot of its current internal state.
	/// 2. uses the memento to restore its internal state.
	/// </summary>
	public class Originator
	{
		private string _state;
		public string State
		{
			get { return _state; }
			set
			{
				_state = value;
				Console.WriteLine("State = " + this._state);
			}
		}

		public Memento CreateMemento()
		{
			return new Memento(this.State);
		}

		public void SetMemento(Memento memento)
		{
			Console.WriteLine("Restoring state...");
			this.State = memento.State;
		}
	}

	/// <summary>
	/// Memento (Memento)
	/// 1. stores internal state of the Originator object. The memento may store as much or as little
	///		of the originator's internal state as necessary at its orignator's discretion.
	///	2. protect against access by objects of other than the originator. Mementos have effectively
	///		two interfaces. Caretaker sees a narrow interfaceto the Memento -- it can only pass the
	///		memento to the other objects. Originator, in contrast, sees a wide interface, one that lets
	///		it access all data necessary to restore itself to its previous state. Ideally, only the
	///		originator that produces the memento would be permitted to access the memento's internal state.
	/// </summary>
	public class Memento
	{
		private string _state;
		public string State
		{
			get { return _state; }
			private set { _state = value; }
		}

		public Memento(string state)
		{
			this.State = state;
		}
	}

	/// <summary>
	/// Caretaker (Caretaker)
	/// 1. is responsible for the memento's safekeeping.
	/// 2. never operates on or examines the contents of a memento.
	/// </summary>
	public class Caretaker
	{
		private Memento _memento;
		public Memento Memento
		{
			get { return _memento; }
			set { _memento = value; }
		}
	}*/
}
