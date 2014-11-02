using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural.Facade
{
	class RealWorld
	{
		public static void Main()
		{
			Mortgage mortgage = new Mortgage();
			Customer customer = new Customer("Ann Mckinsey");
			bool eligible = mortgage.IsEligible(customer, 12500);

			Console.WriteLine("\n" + customer.Name + " has been " + (eligible ? "Approved" : "Rejected"));

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'SubSystem ClassA' class.
	/// </summary>
	public class Bank
	{
		public bool HasSufficientSavings(Customer customer, int amount)
		{
			Console.WriteLine("Check bank for " + customer.Name);
			return true;
		}
	}

	/// <summary>
	/// The 'SubSystem ClassB' class.
	/// </summary>
	public class Credit
	{
		public bool HasGoodCredit(Customer customer)
		{
			Console.WriteLine("Check credit for " + customer.Name);
			return true;
		}
	}

	/// <summary>
	/// The 'SubSystem ClassC' class.
	/// </summary>
	public class Loan
	{
		public bool HasNoBadLoans(Customer customer)
		{
			Console.WriteLine("Check loan for " + customer.Name);
			return true;
		}
	}

	/// <summary>
	/// Customer class.
	/// </summary>
	public class Customer
	{
		public string Name { get; private set; }

		public Customer(string name)
		{
			this.Name = name;
		}
	}

	/// <summary>
	/// The 'Facade' class.
	/// </summary>
	public class Mortgage
	{
		private Bank _bank = new Bank();
		private Credit _credit = new Credit();
		private Loan _loan = new Loan();

		public bool IsEligible(Customer customer, int amount)
		{
			Console.WriteLine("{0} applies for {1:C} loan\n", customer.Name, amount);

			return (!_bank.HasSufficientSavings(customer, amount)
				|| !_loan.HasNoBadLoans(customer) ||
				!_credit.HasGoodCredit(customer))
				? false : true;
		}
	}
}
