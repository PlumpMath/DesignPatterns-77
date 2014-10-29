using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural.Bridge
{
	class RealWorld
	{
		static void Main(string[] args)
		{
			Customers customers = new Customers("Chicago");

			customers.DataObject = new CustomersData();

			customers.Show();
			customers.Next();
			customers.Show();
			customers.Next();
			customers.Show();
			customers.Add("Henry Velasquez");

			customers.ShowAll();

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Abstraction' class
	/// **could be an abstract class if it is inherited.
	/// </summary>
	public class CustomersBase
	{
		private DataObject _dataObject;

		public DataObject DataObject
		{
			get { return _dataObject; }
			set { _dataObject = value; }
		}

		protected string group;

		public CustomersBase(string group)
		{
			this.group = group;
		}

		public virtual void Next()
		{
			_dataObject.NextRecord();
		}

		public virtual void Prior()
		{
			_dataObject.PriorRecord();
		}

		public virtual void Add(string customer)
		{
			_dataObject.AddRecord(customer);
		}

		public virtual void Delete(string customer)
		{
			_dataObject.DeleteRecord(customer);
		}

		public virtual void Show()
		{
			_dataObject.ShowRecord();
		}

		public virtual void ShowAll()
		{
			Console.WriteLine("Customer Group: " + this.group);
			_dataObject.ShowAllRecord();
		}
	}

	/// <summary>
	/// The 'RefinedAbstraction' class
	/// </summary>
	public class Customers : CustomersBase
	{
		public Customers(string group)
			: base(group)
		{
		}

		public override void ShowAll()
		{
			Console.WriteLine();
			Console.WriteLine("-------------------");
			base.ShowAll();
			Console.WriteLine("-------------------");
		}
	}
	/// <summary>
	/// The 'Implememtor' abstract class.
	/// </summary>
	public abstract class DataObject
	{
		public abstract void NextRecord();
		public abstract void PriorRecord();
		public abstract void AddRecord(string name);
		public abstract void DeleteRecord(string name);
		public abstract void ShowRecord();
		public abstract void ShowAllRecord();
	}

	public class CustomersData : DataObject
	{
		private List<string> _customers = new List<string>();
		private int _current = 0;

		public CustomersData()
		{
			_customers.Add("Jim Jones");
			_customers.Add("Samual Jackson");
			_customers.Add("Allen Good");
			_customers.Add("Ann Stills");
			_customers.Add("Lisa Giolani");
		}

		public override void NextRecord()
		{
			if (_current <= _customers.Count() - 1)
			{
				_current++;
			}
		}

		public override void PriorRecord()
		{
			if (_current > 0)
			{
				_current--;
			}
		}

		public override void AddRecord(string customer)
		{
			_customers.Add(customer);
		}

		public override void DeleteRecord(string customer)
		{
			_customers.Remove(customer);
		}

		public override void ShowRecord()
		{
			Console.WriteLine(_customers[_current]);
		}

		public override void ShowAllRecord()
		{
			foreach (string customer in _customers)
			{
				Console.WriteLine(" " + customer);
			}
		}
	}
}
