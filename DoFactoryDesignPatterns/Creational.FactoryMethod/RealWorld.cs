using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational.FactoryMethod
{
	class RealWorld
	{
		static void Main()
		{
			// Note: constructors call Factory Method
			Document[] documents = new Document[2];

			documents[0] = new Resume();
			documents[1] = new Report();

			// Display document pages
			foreach (Document document in documents)
			{
				Console.WriteLine("\n" + document.GetType().Name + "--");
				foreach (Page page in document.Pages)
				{
					Console.WriteLine(" " + page.GetType().Name);
				}
			}

			// Wait for user
			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Product' abstract class.
	/// </summary>
	public abstract class Page
	{
	}

	/// <summary>
	/// A 'ConcreteProduct' class.
	/// </summary>
	public class SkillsPage : Page
	{
	}

	public class EducationPage : Page
	{
	}

	public class ExperiencePage : Page
	{
	}

	public class IntroductionPage : Page
	{
	}

	public class ResultsPage : Page
	{
	}

	public class ConclusionPage : Page
	{
	}

	public class SummaryPage : Page
	{
	}

	public class BibliographyPage : Page
	{
	}

	/// <summary>
	/// The 'Creator' abstract class.
	/// </summary>
	public abstract class Document
	{
		private List<Page> _pages = new List<Page>();
		public List<Page> Pages
		{
			get { return _pages; }
		}

		public Document()
		{
			this.CreatePages();
		}

		public abstract void CreatePages();
	}

	/// <summary>
	/// A 'ConcreteCreator' Page.
	/// </summary>
	public class Resume : Document
	{
		public override void CreatePages()
		{
			this.Pages.Add(new SkillsPage());
			this.Pages.Add(new EducationPage());
			this.Pages.Add(new ExperiencePage());
		}
	}

	public class Report : Document
	{
		public override void CreatePages()
		{
			this.Pages.Add(new IntroductionPage());
			this.Pages.Add(new ResultsPage());
			this.Pages.Add(new ConclusionPage());
			this.Pages.Add(new SummaryPage());
			this.Pages.Add(new BibliographyPage());
		}
	}

}
