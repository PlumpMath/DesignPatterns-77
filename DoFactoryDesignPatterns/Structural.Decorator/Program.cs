using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Structural.Decorator
//{
//	class Program
//	{
//		static void Main(string[] args)
//		{
//			ConcreteComponent c = new ConcreteComponent();
//			ConcreteDecoratorA da = new ConcreteDecoratorA();
//			ConcreteDecoratorB db = new ConcreteDecoratorB();

//			da.SetComponent(c);
//			da.Operation();

//			Console.WriteLine("------------");
//			//db.SetComponent(da);
//			//db.Operation();

//			//da.SetComponent(db);
//			//da.Operation();

//			da.SetComponent(da);
//			da.Operation();
//			Console.ReadKey();
//		}
//	}

//	/// <summary>
//	/// Component   (LibraryItem)
//	/// 1. defines the interface for objects that can have responsibilities added to them dynamically. 
//	/// </summary>
//	public abstract class Component
//	{
//		public abstract void Operation();
//	}

//	/// <summary>
//	/// ConcreteComponent   (Book, Video)
//	/// 1. defines an object to which additional responsibilities can be attached. 
//	/// </summary>
//	public class ConcreteComponent : Component
//	{
//		public override void Operation()
//		{
//			Console.WriteLine("ConcreteComponent.Operation");
//		}
//	}

//	/// <summary>
//	/// Decorator   (Decorator)
//	/// 1. maintains a reference to a Component object and defines an interface that conforms to Component's interface. 
//	/// </summary>
//	public abstract class Decorator : Component
//	{
//		protected Component component;
//		public void SetComponent(Component component)
//		{
//			this.component = component;
//		}

//		public override void Operation()
//		{
//			if (this.component != null)
//			{
//				component.Operation();
//			}
//		}
//	}

//	/// <summary>
//	/// ConcreteDecorator   (Borrowable)
//	/// 1. adds responsibilities to the component. 
//	/// </summary>
//	public class ConcreteDecoratorA : Decorator
//	{
//		public override void Operation()
//		{
//			base.Operation();
//			Console.WriteLine("ConcreteDecoratorA.Operation");
//		}
//	}

//	public class ConcreteDecoratorB : Decorator
//	{
//		public override void Operation()
//		{
//			base.Operation();
//			Console.WriteLine("ConcreteDecoratorB.Operation");
//		}
//	}
//}
