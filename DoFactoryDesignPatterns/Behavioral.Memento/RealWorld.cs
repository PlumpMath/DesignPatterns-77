using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Memento
{
	class RealWorld
	{
		static void Main()
		{
			SalesProspect s = new SalesProspect();
			s.Name = "Noel van Halen";
			s.Phone = "(412) 256-0990";
			s.Budget = 25000.0;

			ProspectMemory m = new ProspectMemory() { Memento = s.SaveMemento() };

			s.Name = "Leo Welch";
			s.Phone = "(310) 209-7111";
			s.Budget = 1000000.0;

			s.RestoreMemento(m.Memento);

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Originator' class.
	/// </summary>
	public class SalesProspect
	{
		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				Console.WriteLine("Name: " + this._name);
			}
		}

		private string _phone;
		public string Phone
		{
			get { return _phone; }
			set
			{
				_phone = value;
				Console.WriteLine("Phone: " + this._phone);
			}
		}

		private double _budget;
		public double Budget
		{
			get { return _budget; }
			set
			{
				_budget = value;
				Console.WriteLine("Budget: " + this._budget);
			}
		}

		public Memento SaveMemento()
		{
			Console.WriteLine("\nSaving state --\n");
			return new Memento(this.Name, this.Phone, this.Budget);
		}

		public void RestoreMemento(Memento memento)
		{
			Console.WriteLine("\nRestoring state --\n");
			this.Name = memento.Name;
			this.Phone = memento.Phone;
			this.Budget = memento.Budget;
		}
	}

	/// <summary>
	/// The 'Memento' class.
	/// </summary>
	public class Memento
	{
		private string _name;
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _phone;
		public string Phone
		{
			get { return _phone; }
			set { _phone = value; }
		}

		private double _budget;
		public double Budget
		{
			get { return _budget; }
			set { _budget = value; }
		}

		public Memento(string name, string phone, double budget)
		{
			this.Name = name;
			this.Phone = phone;
			this.Budget = budget;
		}
	}

	/// <summary>
	/// The 'Caretaker' class.
	/// </summary>
	public class ProspectMemory
	{
		private Memento _memento;

		public Memento Memento
		{
			get { return _memento; }
			set { _memento = value; }
		}
	}
}
