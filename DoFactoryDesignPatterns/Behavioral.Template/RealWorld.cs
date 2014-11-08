using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Template
{
	class RealWorld
	{
		static void Main()
		{
			DataAccessObject daoCategories = new Categories();
			daoCategories.Run();

			DataAccessObject daoProducts = new Products();
			daoProducts.Run();

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'AbstractClass' abstract class.
	/// </summary>
	public abstract class DataAccessObject
	{
		protected string connectionString;
		protected DataSet dataSet;

		public virtual void Connect()
		{
			this.connectionString = "provider=Micosoft.JET.OLEDB.4.0;data source=..\\..\\..\\db1.mdb";
		}

		public abstract void Select();
		public abstract void Process();

		public virtual void Disconnect()
		{
			this.connectionString = "";
		}

		// The 'Template Method'
		public void Run()
		{
			this.Connect();
			this.Select();
			this.Process();
			this.Disconnect();
		}
	}

	/// <summary>
	/// A 'ConcreteClass' class.
	/// </summary>
	public class Categories : DataAccessObject
	{
		public override void Select()
		{
			string sql = "select CategoryName from Categories";
			OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, connectionString);
			dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "Categories");
		}

		public override void Process()
		{
			Console.WriteLine("Categories --- ");
			DataTable dataTable = dataSet.Tables["Categories"];

			foreach (DataRow row in dataTable.Rows)
			{
				Console.WriteLine(row["CategoryName"]);
			}
			Console.WriteLine();
		}
	}

	public class Products : DataAccessObject
	{
		public override void Select()
		{
			string sql = "select ProductName from Products";
			OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, connectionString);
			dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "Products");
		}

		public override void Process()
		{
			Console.WriteLine("Products ---- ");
			DataTable dataTable = dataSet.Tables["Products"];
			foreach (DataRow row in dataTable.Rows)
			{
				Console.WriteLine(row["ProductName"]);
			}
			Console.WriteLine();
		}
	}
}
