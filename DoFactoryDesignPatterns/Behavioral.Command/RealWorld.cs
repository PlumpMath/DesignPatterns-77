using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Command
{
	class RealWorld
	{
		static void Main()
		{
			User user = new User();
			user.Compute('+', 100);
			user.Compute('-', 50);
			user.Compute('*', 10);
			user.Compute('/', 2);

			user.Undo(4);

			user.Redo(3);

			Console.ReadKey();
		}

	}

	/// <summary>
	/// The 'Command' abstract class.
	/// </summary>
	public abstract class Command
	{
		public abstract void Execute();
		public abstract void Unexecute();
	}

	/// <summary>
	/// The 'ConcreteCommand' class.
	/// </summary>
	public class CalculatorCommand : Command
	{
		private char _operator;

		public char Operator
		{
			get { return _operator; }
			set { _operator = value; }
		}

		private int _operand;

		public int Operand
		{
			get { return _operand; }
			set { _operand = value; }
		}

		private Calculator _calculator;

		public Calculator Calculator
		{
			get { return _calculator; }
			set { _calculator = value; }
		}

		public CalculatorCommand(Calculator calculator, char @operator, int operand)
		{
			this.Calculator = calculator;
			this.Operator = @operator;
			this.Operand = operand;
		}

		public override void Execute()
		{
			this.Calculator.Operation(this.Operator, this.Operand);
		}

		public override void Unexecute()
		{
			this.Calculator.Operation(this.Undo(this.Operator), this.Operand);
		}

		private char Undo(char @operator)
		{
			switch (@operator)
			{
				case '+': return '-';
				case '-': return '+';
				case '*': return '/';
				case '/': return '*';
				default:
					throw new ArgumentException("@operator");
			}
		}
	}

	/// <summary>
	/// The 'Receiver' class.
	/// </summary>
	public class Calculator
	{
		private int _curr = 0;

		public void Operation(char @operator, int operand)
		{
			switch (@operator)
			{
				case '+': _curr += operand;
					break;
				case '-': _curr -= operand;
					break;
				case '*': _curr *= operand;
					break;
				case '/': _curr /= operand;
					break;
			}
			Console.WriteLine("Current value = {0,3} (following {1} {2})", _curr, @operator, operand);
		}
	}

	/// <summary>
	/// The 'Invoker' class.
	/// </summary>
	public class User
	{
		private Calculator _calculator = new Calculator();
		private List<Command> _commands = new List<Command>();

		private int _current = 0;

		public void Redo(int levels)
		{
			Console.WriteLine("\n ---- Redo {0} levels ", levels);

			for (int i = 0; i < levels; i++)
			{
				if (_current < _commands.Count - 1)
				{
					Command command = _commands[_current++];
					command.Execute();
				}
			}
		}

		public void Undo(int levels)
		{
			Console.WriteLine("\n ---- Undo {0} levels", levels);

			for (int i = 0; i < levels; i++)
			{
				if (_current > 0)
				{
					Command command = _commands[--_current] as Command;
					command.Unexecute();
				}
			}
		}

		public void Compute(char @operator, int operand)
		{
			Command command = new CalculatorCommand(_calculator, @operator, operand);
			command.Execute();

			_commands.Add(command);
			_current++;
		}
	}
}
