using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural.Composite
{
	/// <summary>
	/// Client  (CompositeApp)
	/// 1. manipulates objects in the composition through the Component interface.
	/// </summary>
	class Program
	{
		//static void Main(string[] args)
		//{
		//	Composite root = new Composite("root");
		//	root.Add(new Leaf("Leaf A"));
		//	root.Add(new Leaf("Leaf B"));

		//	Composite comp = new Composite("Composite X");
		//	comp.Add(new Leaf("Leaf XA"));
		//	comp.Add(new Leaf("Leaf XB"));

		//	root.Add(comp);
		//	root.Add(new Leaf("Leaf C"));

		//	Leaf leaf = new Leaf("Leaf D");
		//	root.Add(leaf);

		//	root.Display(1);

		//	Console.WriteLine("------Romved Leaf D------");
		//	root.Remove(leaf);
		//	root.Display(1);

		//	Console.ReadKey();
		//}
	}

	/// <summary>
	/// Component   (DrawingElement)
	/// 1. declares the interface for objects(leaf and composite) in the composition
	/// 2. implements default behavior for the interface common to all classes, as appropriate.
	/// 3. declares an interface for accessing and manaaging its child components.
	/// 4. (optional) defines an interface for accessing a component's parent in the recursive structure, and implements it if that's appropriate.
	/// </summary>
	public abstract class Component
	{
		protected string name;

		public Component(string name)
		{
			this.name = name;
		}

		public abstract void Add(Component component);
		public abstract void Remove(Component componenet);
		public abstract void Display(int depth);
	}

	/// <summary>
	/// Composite   (CompositeElement)
	/// 1. defines behavior for components having children.
	/// 2. stores child components.
	/// 3. implements child-related operations in the Component interface.
	/// </summary>
	public class Composite : Component
	{
		private List<Component> _children = new List<Component>();

		public Composite(string name)
			: base(name)
		{
		}

		public override void Add(Component component)
		{
			_children.Add(component);
		}

		public override void Remove(Component component)
		{
			_children.Remove(component);
		}

		public override void Display(int depth)
		{
			Console.WriteLine(new String('-', depth) + name);
			foreach (Component item in _children)
			{
				item.Display(depth + 2);
			}
		}
	}

	/// <summary>
	/// Leaf   (PrimitiveElement)
	/// 1. represents leaf objects in the composition. A leaf has no children.
	/// 2. defines behavior for primitive objects in the composition.
	/// </summary>
	public class Leaf : Component
	{
		public Leaf(string name)
			: base(name)
		{
		}

		public override void Add(Component component)
		{
			Console.WriteLine("Can't be added to a leaf.");
		}

		public override void Remove(Component componenet)
		{
			Console.WriteLine("Can't be romved from a leaf.");
		}

		public override void Display(int depth)
		{
			Console.WriteLine(new String('-', depth) + name);
		}
	}
}
