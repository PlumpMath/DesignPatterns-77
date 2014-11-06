using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Observer
{
	class RealWorld
	{
		static void Main()
		{
			IBM ibm = new IBM("IBM", 120.00);
			ibm.Attach(new Investor("Sorros"));
			ibm.Attach(new Investor("Berkshire"));

			ibm.Price = 120.10;
			ibm.Price = 121.00;
			ibm.Price = 120.50;
			ibm.Price = 120.75;
			ibm.Price = 120.75;

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Subject' abstract class.
	/// </summary>
	public abstract class Stock
	{
		public string Symbol { get; private set; }
		private double _price;
		public double Price
		{
			get { return _price; }
			set
			{
				if (_price != value)
				{
					this._price = value;
					this.Notify();
				}
			}
		}

		private IList<IInvestor> _investors = new List<IInvestor>();
		public Stock(string symbol, double price)
		{
			this.Symbol = symbol;
			this.Price = price;
		}

		public void Attach(IInvestor investor)
		{
			this._investors.Add(investor);
		}

		public void Detach(IInvestor investor)
		{
			this._investors.Remove(investor);
		}

		public void Notify()
		{
			foreach (IInvestor investor in this._investors)
			{
				investor.Update(this);
			}
		}
	}

	/// <summary>
	/// The 'ConcreteSubject' class.
	/// </summary>
	public class IBM : Stock
	{
		public IBM(string symbol, double price)
			: base(symbol, price)
		{
		}
	}

	/// <summary>
	/// The 'Observer' interface.
	/// </summary>
	public interface IInvestor
	{
		void Update(Stock stock);
	}

	/// <summary>
	/// The 'ConcreteObserver' class.
	/// </summary>
	public class Investor : IInvestor
	{
		public string Name { get; set; }

		public Investor(string name)
		{
			this.Name = name;
		}

		public void Update(Stock stock)
		{
			Console.WriteLine("Notified {0} of {1}'s change to {2:C}", this.Name, stock.Symbol, stock.Price);
		}
	}
}
