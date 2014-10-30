using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural.Composite
{
	class RealWorld
	{
		static void Main(string[] args)
		{
			// Create a tree structure

			CompositeElement root = new CompositeElement("Picture");
			root.Add(new PrimitiveElement("Red Line"));
			root.Add(new PrimitiveElement("Blue Circle"));
			root.Add(new PrimitiveElement("Green Box"));

			// Create a branch
			CompositeElement comp = new CompositeElement("Two Circles");
			comp.Add(new PrimitiveElement("Black Circle"));
			comp.Add(new PrimitiveElement("White Circle"));
			root.Add(comp);

			// Add and remove a PrimitiveElement
			PrimitiveElement pe = new PrimitiveElement("Yellow Line");
			root.Add(pe);
			root.Remove(pe);

			// Recursively display nodes
			root.Display(1);

			// Wait for user
			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Component' Treenode.
	/// </summary>
	public abstract class DrawingElement
	{
		protected string _name;

		public DrawingElement(string name)
		{
			this._name = name;
		}

		public abstract void Add(DrawingElement de);
		public abstract void Remove(DrawingElement de);
		public abstract void Display(int indent);
	}

	/// <summary>
	/// The 'Composite' class.
	/// </summary>
	public class CompositeElement : DrawingElement
	{
		private List<DrawingElement> childElements = new List<DrawingElement>();

		public CompositeElement(string name)
			: base(name)
		{
		}

		public override void Add(DrawingElement de)
		{
			childElements.Add(de);
		}

		public override void Remove(DrawingElement de)
		{
			childElements.Remove(de);
		}

		public override void Display(int indent)
		{
			Console.WriteLine(new String('-', indent) + "+" + _name);

			foreach (DrawingElement item in childElements)
			{
				item.Display(indent + 2);
			}
		}
	}

	/// <summary>
	/// The 'Leaf' class.
	/// </summary>
	public class PrimitiveElement : DrawingElement
	{
		public PrimitiveElement(string name)
			: base(name)
		{
		}

		public override void Add(DrawingElement de)
		{
			throw new NotImplementedException("Can't be added to a PrimitiveElement.");
		}

		public override void Remove(DrawingElement de)
		{
			throw new NotImplementedException("Can't be removed from a PrimitiveElement");
		}

		public override void Display(int indent)
		{
			Console.WriteLine(new String('-', indent) + this._name);
		}
	}
}
