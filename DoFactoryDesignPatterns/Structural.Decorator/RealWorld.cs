using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural.Decorator
{
	class RealWorld
	{
		public static void Main()
		{
			// Create book
			Book book = new Book("Worley", "Inside ASP.NET", 10);
			book.Display();

			// Create video
			Video video = new Video("Spielberg", "Jaws", 23, 92);
			video.Display();

			// Make video borrowable, then borrow and display
			Console.WriteLine("\nMaking video borrowable:");

			Borrowable borrowvideo = new Borrowable(video);
			borrowvideo.BorrowItem("Customer #1");
			borrowvideo.BorrowItem("Customer #2");
			
			borrowvideo.Display();
			
			// Wait for user
			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Component' abstract class.
	/// </summary>
	public abstract class LibraryItem
	{
		private int _numCopies;

		public int NumCopies
		{
			get { return _numCopies; }
			set { _numCopies = value; }
		}

		public abstract void Display();
	}

	/// <summary>
	/// The 'ConcreteComponent' class.
	/// </summary>
	public class Book : LibraryItem
	{
		public string Author { get; set; }
		public string Title { get; set; }

		public Book(string author, string title, int numCopies)
		{
			this.Author = author;
			this.Title = title;
			this.NumCopies = numCopies;
		}

		public override void Display()
		{
			Console.WriteLine("\nBook ------");
			Console.WriteLine(" Author: {0}", this.Author);
			Console.WriteLine(" Title: {0}", this.Title);
			Console.WriteLine(" # Copies: {0}", this.NumCopies);
		}
	}

	/// <summary>
	/// The 'ConcreteComponent' class
	/// </summary>
	public class Video : LibraryItem
	{
		public string Director { get; set; }
		public string Title { get; set; }
		public int PlayTime { get; set; }

		public Video(string director, string title, int numCopies, int playTime)
		{
			this.Director = director;
			this.Title = title;
			this.NumCopies = numCopies;
			this.PlayTime = playTime;
		}

		public override void Display()
		{
			Console.WriteLine("\nVideo ----- ");
			Console.WriteLine(" Director: {0}", this.Director);
			Console.WriteLine(" Title: {0}", this.Title);
			Console.WriteLine(" # Copies: {0}", this.NumCopies);
			Console.WriteLine(" Playtime: {0}\n", this.PlayTime);
		}
	}

	/// <summary>
	/// The 'Decorator' abstract class
	/// </summary>
	public abstract class Decorator : LibraryItem
	{
		protected LibraryItem LibraryItem { get; private set; }

		public Decorator(LibraryItem libraryItem)
		{
			this.LibraryItem = libraryItem;
		}

		public override void Display()
		{
			this.LibraryItem.Display();
		}
	}

	/// <summary>
	/// The 'ConcreteDecorator' class.
	/// </summary>
	public class Borrowable : Decorator
	{
		private List<string> borrowers = new List<string>();

		protected List<string> Borrowers
		{
			get { return borrowers; }
			set { borrowers = value; }
		}

		public Borrowable(LibraryItem libraryItem)
			: base(libraryItem)
		{
		}

		public void BorrowItem(string name)
		{
			this.Borrowers.Add(name);
			this.LibraryItem.NumCopies--;
		}

		public void ReturnItem(string name)
		{
			this.Borrowers.Remove(name);
			this.LibraryItem.NumCopies++;
		}

		public override void Display()
		{
			base.Display();
			foreach (string borrower in this.Borrowers)
			{
				Console.WriteLine(" Borrower: " + borrower);
			}
		}
	}
}
