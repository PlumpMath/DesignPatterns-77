using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Visitor
{
	class RealWorld
	{
		static void Main()
		{
			Employees e = new Employees();
			e.Attach(new Clerk());
			e.Attach(new Director());
			e.Attach(new President());

			e.Accept(new IncomeVisitor());
			e.Accept(new VacationVisitor());

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Visitor' interface
	/// </summary>
	public interface IVisitor
	{
		void Visit(Element element);
	}

	/// <summary>
	/// A 'ConcreteVisitor' class.
	/// </summary>
	public class IncomeVisitor : IVisitor
	{
		public void Visit(Element element)
		{
			Employee employee = element as Employee;

			employee.Income *= 1.10;
			Console.WriteLine("{0} {1}'s new income: {2:C}", employee.GetType().Name, employee.Name,
				employee.Income);
		}
	}

	public class VacationVisitor : IVisitor
	{
		public void Visit(Element element)
		{
			Employee employee = element as Employee;

			Console.WriteLine("{0} {1}'s new vacation days: {2}", employee.GetType().Name, employee.Name,
				employee.VacationDays);

		}
	}

	/// <summary>
	/// The 'Element' abstract class.
	/// </summary>
	public abstract class Element
	{
		public abstract void Accept(IVisitor visitor);
	}

	/// <summary>
	/// The 'ConcreteElement' class.
	/// </summary>
	public class Employee : Element
	{
		public string Name { get; set; }
		public double Income { get; set; }
		public int VacationDays { get; set; }

		public Employee(string name, double income, int vacationDays)
		{
			this.Name = name;
			this.Income = income;
			this.VacationDays = vacationDays;
		}

		public override void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}
	}

	/// <summary>
	/// The 'ObjectStructure' class.
	/// </summary>
	public class Employees
	{
		private List<Employee> _employees = new List<Employee>();

		public void Attach(Employee employee)
		{
			this._employees.Add(employee);
		}
		public void Detach(Employee employee)
		{
			this._employees.Remove(employee);
		}

		public void Accept(IVisitor visitor)
		{
			foreach (Employee e in this._employees)
			{
				e.Accept(visitor);
			}
			Console.WriteLine();
		}
	}

	// Three employee types.
	public class Clerk : Employee
	{
		public Clerk()
			: base("Hank", 25000.0, 14)
		{
		}
	}

	public class Director : Employee
	{
		public Director()
			: base("Elly", 35000.0, 16)
		{
		}
	}

	public class President : Employee
	{
		public President()
			: base("Dick", 45000.0, 21)
		{
		}
	}
}