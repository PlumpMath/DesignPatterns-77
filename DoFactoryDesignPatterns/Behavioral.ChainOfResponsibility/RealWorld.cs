using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.ChainOfResponsibility
{
	class RealWorld
	{
		static void Main()
		{
			Approver larry = new Director();
			Approver sam = new VicePresident();
			Approver tammy = new President();

			larry.SetSuccessor(sam);
			sam.SetSuccessor(tammy);

			Purchase p = new Purchase(2034, 350.00, "Assets");
			larry.ProcessRequest(p);

			p = new Purchase(2035, 32590.00, "Project X");
			larry.ProcessRequest(p);

			p = new Purchase(2036, 122100.00, "Project Y");
			larry.ProcessRequest(p);

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Handler' abstract class.
	/// </summary>
	public abstract class Approver
	{
		protected Approver successor;

		public void SetSuccessor(Approver successor)
		{
			this.successor = successor;
		}
		public abstract void ProcessRequest(Purchase purchase);
	}

	/// <summary>
	/// The 'ConcreteHandler' class.
	/// </summary>
	public class Director : Approver
	{
		public override void ProcessRequest(Purchase purchase)
		{
			if (purchase.Amount < 1000.0)
			{
				Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
			}
			else if (successor != null)
			{
				successor.ProcessRequest(purchase);
			}
		}
	}

	public class VicePresident : Approver
	{
		public override void ProcessRequest(Purchase purchase)
		{
			if (purchase.Amount < 25000.0)
			{
				Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
			}
			else if (successor != null)
			{
				successor.ProcessRequest(purchase);
			}
		}
	}

	public class President : Approver
	{
		public override void ProcessRequest(Purchase purchase)
		{
			if (purchase.Amount < 100000.0)
			{
				Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
			}
			else
			{
				Console.WriteLine("Request# {0} requires an executive meeting!", purchase.Number);
			}
		}
	}

	/// <summary>
	/// Class holding request details.
	/// </summary>
	public class Purchase
	{
		private int _number;

		public int Number
		{
			get { return _number; }
			set { _number = value; }
		}

		private double _amount;

		public double Amount
		{
			get { return _amount; }
			set { _amount = value; }
		}

		private string _purpose;

		public string Purpose
		{
			get { return _purpose; }
			set { _purpose = value; }
		}

		public Purchase(int number, double amount, string purpose)
		{
			this.Number = number;
			this.Amount = amount;
			this.Purpose = purpose;
		}
	}
}
