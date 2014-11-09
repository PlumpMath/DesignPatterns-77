/*
 * Represent an operation to be performed on the elements of an object structure. Visitor lets you
 * define a new operation without changing the classes of the elements on which it operates.
 */
namespace Behavioral.Visitor
{
	using System;
	using System.Collections.Generic;

	/*class Program
	{
		static void Main(string[] args)
		{
			ObjectStructure o = new ObjectStructure();
			o.Attach(new ConcreteElementA());
			o.Attach(new ConcreteElementB());

			ConcreteVisitor1 v1 = new ConcreteVisitor1();
			ConcreteVisitor2 v2 = new ConcreteVisitor2();

			o.Accept(v1);
			o.Accept(v2);

			Console.ReadKey();

		}
	}

	/// <summary>
	/// Visitor (Visitor)
	/// 1. declares a Visit operation for each class of ConcreteElement in the object structure. The
	///		operation's name and signature identifies the class that sends the Visit request to the
	///		visitor. That lets the visitor determine the concrete class of the elements being visited.
	///		Then the visitor can access the elements directly through its particular interface.
	/// </summary>
	public abstract class Visitor
	{
		public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);
		public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
	}

	/// <summary>
	/// ConcreteVisitor (IncomeVisitor, VacationVisitor)
	/// 1. implements each operation declared by Visitor. Each operation implements a fragment of the
	///		algorithm defined for the corresponding class or object in the structure. ConcreteVisitor
	///		provides the contextfor the algorithm and stores its local state. This state often accumulates
	///		results during the traversal of the structure.
	/// </summary>
	public class ConcreteVisitor1 : Visitor
	{
		public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
		{
			Console.WriteLine("{0} visited by {1}", concreteElementA.GetType().Name, this.GetType().Name);
		}

		public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
		{
			Console.WriteLine("{0} visited by {1}", concreteElementB.GetType().Name, this.GetType().Name);
		}
	}

	public class ConcreteVisitor2 : Visitor
	{
		public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
		{
			Console.WriteLine("{0} visited by {1}", concreteElementA.GetType().Name, this.GetType().Name);
		}

		public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
		{
			Console.WriteLine("{0} visited by {1}", concreteElementB.GetType().Name, this.GetType().Name);
		}
	}

	/// <summary>
	/// Element (Element)
	/// 1. defines an Accept operation that takes a visitor as an argument.
	/// </summary>
	public abstract class Elemenet
	{
		public abstract void Accept(Visitor visitor);
	}

	/// <summary>
	/// ConcreteElement (Employee)
	/// 1. implements an Accept operation that takes a visitor as an argument.
	/// </summary>
	public class ConcreteElementA : Elemenet
	{
		public override void Accept(Visitor visitor)
		{
			visitor.VisitConcreteElementA(this);
		}
		public void OperationA()
		{
		}
	}

	public class ConcreteElementB : Elemenet
	{
		public override void Accept(Visitor visitor)
		{
			visitor.VisitConcreteElementB(this);
		}

		public void OperationB()
		{
		}
	}

	/// <summary>
	/// ObjectStructure (Employees)
	/// 1. can enumerate its elements
	/// 2. may provide a high-level interface to allow the visitor to visit its elements.
	/// 3. may either be a Composite(pattern) or a collection such as a list or a set.
	/// </summary>
	public class ObjectStructure
	{
		private List<Elemenet> _elements = new List<Elemenet>();
		public void Attach(Elemenet element)
		{
			_elements.Add(element);
		}
		public void Detach(Elemenet element)
		{
			_elements.Remove(element);
		}

		public void Accept(Visitor visitor)
		{
			foreach (Elemenet element in _elements)
			{
				element.Accept(visitor);
			}
		}
	}*/
}