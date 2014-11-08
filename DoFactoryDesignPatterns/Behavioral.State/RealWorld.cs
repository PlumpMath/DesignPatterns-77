using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.State
{
	class RealWorld
	{
		static void Main()
		{
			Account account = new Account("Jim Johnson");

			account.Deposit(500.0);
			account.Deposit(300.0);
			account.Deposit(550.0);
			account.PayInterest();
			account.Withdraw(2000.00);
			account.Withdraw(1100.00);

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'State' abstract class.
	/// </summary>
	public abstract class State
	{
		protected Account _account;
		public Account Account
		{
			get { return _account; }
			set { _account = value; }
		}

		protected double _balance;
		public double Balance
		{
			get { return _balance; }
			set { _balance = value; }
		}

		protected double interest;
		protected double lowerLimit;
		protected double upperLimit;

		public abstract void Deposit(double amount);
		public abstract void Withdraw(double amount);
		public abstract void PayInterest();
	}

	/// <summary>
	/// A 'ConcreteState' class
	/// </summary>
	public class RedState : State
	{
		private double _serviceFee;

		public RedState(State state)
		{
			this.Balance = state.Balance;
			this.Account = state.Account;
			this.Initialize();
		}

		private void Initialize()
		{
			this.interest = 0.0;
			this.lowerLimit = -100.0;
			this.upperLimit = 0.0;
			this._serviceFee = 15.00;
		}
		public override void Deposit(double amount)
		{
			this.Balance += amount;
			this.StateChangeCheck();
		}

		public override void Withdraw(double amount)
		{
			amount = amount - this._serviceFee;
			Console.WriteLine("No funds available for withdrawal!");
		}

		public override void PayInterest()
		{
			throw new NotImplementedException();
		}

		private void StateChangeCheck()
		{
			if (this.Balance > this.upperLimit)
			{
				this.Account.State = new SilverState(this);
			}
		}
	}

	public class SilverState : State
	{
		public SilverState(State state)
			: this(state.Balance, state.Account)
		{
		}
		public SilverState(double balance, Account account)
		{
			this.Balance = balance;
			this.Account = account;
			this.Initialize();
		}

		private void Initialize()
		{
			this.interest = 0.0;
			this.lowerLimit = 0.0;
			this.upperLimit = 1000.0;
		}

		public override void Deposit(double amount)
		{
			this.Balance += amount;
			this.StateChangeCheck();

		}

		public override void Withdraw(double amount)
		{
			this.Balance -= amount;
			this.StateChangeCheck();
		}

		public override void PayInterest()
		{
			this.Balance += this.interest * this.Balance;
			this.StateChangeCheck();
		}

		private void StateChangeCheck()
		{
			if (this.Balance < this.lowerLimit)
			{
				this.Account.State = new RedState(this);
			}
			else if (this.Balance > this.upperLimit)
			{
				this.Account.State = new GoldState(this);
			}
		}
	}

	public class GoldState : State
	{
		public GoldState(double balance, Account account)
		{
			this.Balance = balance;
			this.Account = account;
			this.Initialize();
		}

		public GoldState(State state)
			: this(state.Balance, state.Account)
		{
		}

		private void Initialize()
		{
			this.interest = 0.05;
			this.lowerLimit = 1000.0;
			this.upperLimit = 100000000.0;
		}

		public override void Deposit(double amount)
		{
			this.Balance += amount;
			this.StateChangeCheck();
		}

		public override void Withdraw(double amount)
		{
			this.Balance -= amount;
			this.StateChangeCheck();
		}

		public override void PayInterest()
		{
			this.Balance += this.interest * this.Balance;
			this.StateChangeCheck();
		}

		private void StateChangeCheck()
		{
			if (this.Balance < 0.0)
			{
				this.Account.State = new RedState(this);
			}
			else if (this.Balance < this.lowerLimit)
			{
				this.Account.State = new SilverState(this);
			}
		}
	}

	/// <summary>
	/// The 'Context' class.
	/// </summary>
	public class Account
	{
		private State _state;
		public State State
		{
			get { return _state; }
			set { _state = value; }
		}

		private string _owner;

		public double Balance
		{
			get { return this.State.Balance; }
		}

		public Account(string owner)
		{
			this._owner = owner;
			this.State = new SilverState(0.0, this);
		}

		public void Deposit(double amount)
		{
			this.State.Deposit(amount);
			Console.WriteLine("Deposited {0:C} --- ", amount);
			Console.WriteLine(" Balance = {0:C}", this.Balance);
			Console.WriteLine(" Status = {0}", this.State.GetType().Name);
		}

		public void Withdraw(double amount)
		{
			this.State.Withdraw(amount);
			Console.WriteLine("Withdraw {0:C} --- ", amount);
			Console.WriteLine(" Balance = {0:C}", this.Balance);
			Console.WriteLine(" Status = {0}\n", this.State.GetType().Name);
		}

		public void PayInterest()
		{
			this.State.PayInterest();
			Console.WriteLine("Interest Paid --- ");
			Console.WriteLine(" Balance = {0:C}", this.Balance);
			Console.WriteLine(" Status = {0}\n", this.State.GetType().Name);
		}
	}
}
