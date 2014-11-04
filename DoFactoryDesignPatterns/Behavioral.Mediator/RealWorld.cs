using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Mediator
{
	class RealWorld
	{
		static void Main()
		{
			Chatroom chatroom = new Chatroom();

			Participant George = new Beatle("George");
			Participant Paul = new Beatle("Paul");
			Participant Ringo = new Beatle("Ringo");
			Participant John = new Beatle("John");
			Participant Yoko = new NonBeatle("Yoko");

			chatroom.Register(George);
			chatroom.Register(Paul);
			chatroom.Register(Ringo);
			chatroom.Register(John);
			chatroom.Register(Yoko);

			Yoko.Send("John", "Hi John!");
			Paul.Send("Ringo", "All you need is love");
			Ringo.Send("George", "My sweet Lord");
			Paul.Send("John", "Can't buy me love");
			John.Send("Yoko", "My sweet love");

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Mediator' abstract class.
	/// </summary>
	public abstract class AbstractChatroom
	{
		public abstract void Register(Participant participant);

		public abstract void Send(string from, string to, string message);
	}

	public class Chatroom : AbstractChatroom
	{
		private Dictionary<string, Participant> _participants = new Dictionary<string, Participant>();

		public override void Register(Participant participant)
		{
			if (!_participants.ContainsValue(participant))
			{
				_participants[participant.Name] = participant;
			}
			participant.Chatroom = this;
		}

		public override void Send(string from, string to, string message)
		{
			Participant participant = _participants[to];
			if (participant != null)
			{
				participant.Receive(from, message);
			}
		}
	}

	/// <summary>
	/// The 'AbstractColleague' class.
	/// </summary>
	public class Participant
	{
		public string Name { get; private set; }

		private AbstractChatroom _chatroom;

		public AbstractChatroom Chatroom
		{
			get { return _chatroom; }
			set { _chatroom = value; }
		}

		public Participant(string name)
		{
			this.Name = name;
		}

		public void Send(string to, string message)
		{
			this.Chatroom.Send(this.Name, to, message);
		}

		public virtual void Receive(string from, string message)
		{
			Console.WriteLine("{0} to {1}: '{2}'", from, this.Name, message);
		}
	}

	/// <summary>
	/// A 'ConcreteColleague' class.
	/// </summary>
	public class Beatle : Participant
	{
		public Beatle(string name)
			: base(name)
		{
		}

		public override void Receive(string from, string message)
		{
			Console.Write("To a Beatle: \t");
			base.Receive(from, message);
		}
	}

	public class NonBeatle : Participant
	{
		public NonBeatle(string name)
			: base(name)
		{
		}

		public override void Receive(string from, string message)
		{
			Console.Write("To a non-Beatle: \t");
			base.Receive(from, message);
		}
	}
}
