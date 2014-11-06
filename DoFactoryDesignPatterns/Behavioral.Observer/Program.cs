using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Observer
{
	class Program
	{
		//static void Main(string[] args)
		//{
		//	ConcreteSubject cs = new ConcreteSubject();

		//	cs.Attach(new ConcreteObserver(cs, "X"));
		//	cs.Attach(new ConcreteObserver(cs, "Y"));
		//	cs.Attach(new ConcreteObserver(cs, "Z"));

		//	cs.SubjectState = "ABC";
		//	cs.Notify();

		//	Console.ReadKey();
		//}
	}

	/// <summary>
	/// Subject (Stock)
	/// 1. knows its observers. Any number of Oberver objects may oberve a subject.
	/// 2. provides an interface for attaching and detaching Observer objects.
	/// </summary>
	public abstract class Subject
	{
		private IList<Observer> _observers = new List<Observer>();
		public void Attach(Observer observer)
		{
			_observers.Add(observer);
		}

		public void Detach(Observer observer)
		{
			_observers.Remove(observer);
		}

		public void Notify()
		{
			foreach (Observer o in this._observers)
			{
				o.Update();
			}
		}
	}

	/// <summary>
	/// ConcreteSubject (IBM)
	/// 1. stores state of interest to ConcreteObserver
	/// 2. sends a notification to its observers when its state changes.
	/// </summary>
	public class ConcreteSubject : Subject
	{
		private string _subjectState;

		public string SubjectState
		{
			get { return _subjectState; }
			set { _subjectState = value; }
		}
	}

	/// <summary>
	/// Observer (IInvestor)
	/// 1. defines an updating interface for objects that should be notified of changes in a subject.
	/// </summary>
	public abstract class Observer
	{
		public abstract void Update();
	}

	/// <summary>
	/// ConcreteObserver (Investor)
	/// 1. maintains a reference to a ConcreteSubject object
	/// 2. stores state that should stay consistent with the subject's.
	/// 3. implements the Observer updating interface to keep its state consistent with the subject's.
	/// </summary>
	public class ConcreteObserver : Observer
	{
		public string Name { get; set; }
		public string ObserverState { get; set; }

		private ConcreteSubject _subject;
		public ConcreteSubject Subject
		{
			get { return _subject; }
			set { _subject = value; }
		}

		public ConcreteObserver(ConcreteSubject subject, string name)
		{
			this.Subject = subject;
			this.Name = name;
		}

		public override void Update()
		{
			this.ObserverState = this.Subject.SubjectState;
			Console.WriteLine("Observer {0}'s new state is {1}", this.Name, this.ObserverState);
		}
	}
}
