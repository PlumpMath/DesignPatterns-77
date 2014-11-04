using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Interpreter
{
	///// <summary>
	///// Client (InterpreterApp)
	///// 1. builds (or is given) an abstract syntax tree representing a particular sentence in 
	/////		the language that the grammar defines. The abstract syntax tree is assembled from
	/////		instances of the NonterminalExpression and TerminalExpression classes.
	/////	2. invokes the Interpret operation.
	///// </summary>
	//class Program
	//{
	//	static void Main(string[] args)
	//	{
	//		Context context = new Context();

	//		ArrayList list = new ArrayList();

	//		list.Add(new TerminalExpression());
	//		list.Add(new NonterminalExpression());
	//		list.Add(new TerminalExpression());
	//		list.Add(new TerminalExpression());

	//		foreach (AbstractExpression expression in list)
	//		{
	//			expression.Interpret(context);
	//		}

	//		Console.ReadKey();
	//	}
	//}

	///// <summary>
	///// Context (Context)
	///// 1. contains information that is global to the interpreter.
	///// </summary>
	//public class Context
	//{
	//}

	///// <summary>
	///// AbstractExpression (Expression)
	///// 1. declares an interface for executing an operation.
	///// </summary>
	//public abstract class AbstractExpression
	//{
	//	public abstract void Interpret(Context context);
	//}

	///// <summary>
	///// TerminalExpression (ThousandExpreesion, HundredExprssion, TenExpression, OneExprssion)
	///// 1. implements an interpret operation associated with terminal symbols in the grammar.
	///// 2. an instance is required for every terminal symbol in the sentence.
	///// </summary>
	//public class TerminalExpression : AbstractExpression
	//{
	//	public override void Interpret(Context context)
	//	{
	//		Console.WriteLine("Called Terminal.Interpret.");
	//	}
	//}

	///// <summary>
	///// NonterminalExpression
	///// 1. one such class is required for every rule R::=R1R2...Rn in the grammar.
	///// 2. maintains instance variables of type AbstractExpression for each of the symbols R1 through Rn.
	///// 3. implements an Interpret operation for nonterminal symbols in the grammar. Interpret typically
	/////		calls itself recursively on the variables representing R1 through Rn.
	///// </summary>
	//public class NonterminalExpression : AbstractExpression
	//{
	//	public override void Interpret(Context context)
	//	{
	//		Console.WriteLine("Called Nonterminal.Interpret");
	//	}
	//}
}
