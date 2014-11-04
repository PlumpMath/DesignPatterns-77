﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Interpreter
{
	class RealWorld
	{
		static void Main()
		{
			string roman = "MCMXXVIII";
			Context context = new Context(roman);

			List<Expression> tree = new List<Expression>()
			{
				new ThousandExpression(),
				new HundredExpression(),
				new TenExpression(),
				new OneExpression()
			};

			foreach (Expression expression in tree)
			{
				expression.Interpret(context);
			}

			Console.WriteLine("{0} = {1}", roman, context.Output);

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Context' class.
	/// </summary>
	public class Context
	{
		private string _input;

		public string Input
		{
			get { return _input; }
			set { _input = value; }
		}

		private int _output;

		public int Output
		{
			get { return _output; }
			set { _output = value; }
		}

		public Context(string input)
		{
			this.Input = input;
		}
	}

	/// <summary>
	/// The 'AbstractExpression' class.
	/// </summary>
	public abstract class Expression
	{
		public void Interpret(Context context)
		{
			if (context.Input.Length == 0)
			{
				return;
			}
			if (context.Input.StartsWith(Nine()))
			{
				context.Output += (9 * Multiplier());
				context.Input = context.Input.Substring(2);
			}
			else if (context.Input.StartsWith(Four()))
			{
				context.Output += (4 * Multiplier());
				context.Input = context.Input.Substring(2);
			}
			else if (context.Input.StartsWith(Five()))
			{
				context.Output += (5 * Multiplier());
				context.Input = context.Input.Substring(1);
			}

			while (context.Input.StartsWith(One()))
			{
				context.Output += (1 * Multiplier());
				context.Input = context.Input.Substring(1);
			}
		}

		public abstract string One();
		public abstract string Four();
		public abstract string Five();
		public abstract string Nine();
		public abstract int Multiplier();
	}

	/// <summary>
	/// A 'TerminalExpression' class.
	/// <remarks>
	///		Thousand checks for the Roman Numeral M.
	/// </remarks>
	/// </summary>
	public class ThousandExpression : Expression
	{
		public override string One()
		{
			return "M";
		}

		public override string Four()
		{
			return " ";
		}

		public override string Five()
		{
			return " ";
		}

		public override string Nine()
		{
			return " ";
		}

		public override int Multiplier()
		{
			return 1000;
		}
	}

	/// <summary>
	/// A 'TerminalExpression' class
	/// <remarks>
	///		Hundred checks C, CD, D or CM
	/// </remarks>
	/// </summary>
	public class HundredExpression : Expression
	{
		public override string One()
		{
			return "C";
		}

		public override string Four()
		{
			return "CD";
		}

		public override string Five()
		{
			return "D";
		}

		public override string Nine()
		{
			return "CM";
		}

		public override int Multiplier()
		{
			return 100;
		}
	}

	/// <summary>
	/// A 'TerminalExpression' class
	/// <remarks>
	///		Ten checks for X, XL, L and XC
	/// </remarks>
	/// </summary>
	public class TenExpression : Expression
	{
		public override string One()
		{
			return "X";
		}

		public override string Four()
		{
			return "XL";
		}

		public override string Five()
		{
			return "L";
		}

		public override string Nine()
		{
			return "XC";
		}

		public override int Multiplier()
		{
			return 10;
		}
	}

	/// <summary>
	/// A 'TerminalExpression' class.
	/// <remarks>
	///		one checks for I, II, III, IV, V, VI, VII, VIII, IX.
	/// </remarks>
	/// </summary>
	public class OneExpression : Expression
	{
		public override string One()
		{
			return "I";
		}

		public override string Four()
		{
			return "IV";
		}

		public override string Five()
		{
			return "V";
		}

		public override string Nine()
		{
			return "IX";
		}

		public override int Multiplier()
		{
			return 1;
		}
	}
}
