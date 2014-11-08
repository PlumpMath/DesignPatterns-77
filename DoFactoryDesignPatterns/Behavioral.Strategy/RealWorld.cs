using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.Strategy
{
	class RealWorld
	{
		static void Main()
		{
			// Two contexts following different strategies
			SortedList studentRecords = new SortedList();

			studentRecords.Add("Samual");
			studentRecords.Add("Jimmy");
			studentRecords.Add("Sandra");
			studentRecords.Add("Vivek");
			studentRecords.Add("Anna");

			studentRecords.SetSortStrategy(new QuickSort());
			studentRecords.Sort();

			studentRecords.SetSortStrategy(new ShellSort());
			studentRecords.Sort();

			studentRecords.SetSortStrategy(new MergeSort());
			studentRecords.Sort();

			// Wait for user
			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Strategy' abstract class.
	/// </summary>
	public abstract class SortStrategy
	{
		public abstract void Sort(List<string> list);
	}

	/// <summary>
	/// A 'ConcreteStrategy' class.
	/// </summary>
	public class QuickSort : SortStrategy
	{
		public override void Sort(List<string> list)
		{
			list.Sort(); // Default is QuickSort.
			Console.WriteLine("QuickSorted list.");
		}
	}

	public class ShellSort : SortStrategy
	{
		public override void Sort(List<string> list)
		{
			// list.ShellSort(); not-implemented.
			Console.WriteLine("ShellSorted list.");
		}
	}

	public class MergeSort : SortStrategy
	{
		public override void Sort(List<string> list)
		{
			// list.MergeSort(); not-implemented.
			Console.WriteLine("MergeSorted list.");
		}
	}

	/// <summary>
	/// The 'Context' class.
	/// </summary>
	public class SortedList
	{
		private List<string> _list = new List<string>();
		private SortStrategy _sortStrategy;

		public void SetSortStrategy(SortStrategy sortStrategy)
		{
			this._sortStrategy = sortStrategy;
		}

		public void Add(string name)
		{
			this._list.Add(name);
		}

		public void Sort()
		{
			this._sortStrategy.Sort(this._list);

			foreach (string name in this._list)
			{
				Console.WriteLine(" " + name);
			}
			Console.WriteLine();
		}
	}
}
