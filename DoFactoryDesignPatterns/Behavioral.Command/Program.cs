using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Command
{
	//class Program
	//{
	//	/// <summary>
	//	/// Client (CommandApp)
	//	/// 1. creates a ConcreteCommand object and sets its reciever.
	//	/// </summary>
	//	static void Main(string[] args)
	//	{
	//		Receiver receiver = new Receiver();
	//		Command command = new ConcreteCommand(receiver);
	//		Invoker invoker = new Invoker();

	//		invoker.SetCommand(command);
	//		invoker.ExecuteCommand();

	//		Console.ReadKey();
	//	}
	//}

	///// <summary>
	///// Command (Command)
	///// 1. declares an interface for executing an operation.
	///// </summary>
	//public abstract class Command
	//{
	//	protected Receiver receiver;

	//	public Command(Receiver receiver)
	//	{
	//		this.receiver = receiver;
	//	}

	//	public abstract void Execute();
	//}

	///// <summary>
	///// ConcreteCommand (CalculatorCommand)
	///// 1. defines a binding between a Reciever object and an action.
	///// 2. implements Execute by invoking the corresponding operation(s) on Reciever.
	///// </summary>
	//public class ConcreteCommand : Command
	//{
	//	public ConcreteCommand(Receiver receiver)
	//		: base(receiver)
	//	{
	//	}

	//	public override void Execute()
	//	{
	//		receiver.Action();
	//	}
	//}

	///// <summary>
	///// Receiver (Calculator)
	///// 1. knows how to perform the operations associated with carrying out the request.
	///// </summary>
	//public class Receiver
	//{
	//	public void Action()
	//	{
	//		Console.WriteLine("Called Receiver.Action");
	//	}
	//}

	///// <summary>
	///// Invoker (User)
	///// 1. asks the command to carry out the request.
	///// </summary>
	//public class Invoker
	//{
	//	private Command _command;

	//	public void SetCommand(Command command)
	//	{
	//		this._command = command;
	//	}

	//	public void ExecuteCommand()
	//	{
	//		_command.Execute();
	//	}
	//}
}
