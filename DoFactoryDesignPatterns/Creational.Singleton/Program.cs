/*
 * Ensure a class has only one instance and provide a global point of access to it.
 */
namespace Creational.Singleton
{
	using System;

	class Program
	{
		//static void Main(string[] args)
		//{
		//	Singleton s1 = Singleton.Instance();
		//	Singleton s2 = Singleton.Instance();

		//	if (s1 == s2)
		//	{
		//		Console.WriteLine("Objects are the same instance");
		//	}

		//	Console.ReadKey();
		//}
	}

	/// <summary>
	/// Singleton (LoadBalancer)
	/// 1. defines an Instance operation that lets clients access its unique instance. Instance is a class operation.
	/// 2. responsible for creating and maintaining its own unique instance.
	/// </summary>
	public class Singleton
	{
		private static Singleton _instance;

		protected Singleton()
		{
		}

		public static Singleton Instance()
		{
			// Uses lazy initialization
			// Note: this is not thread safe.
			if (Singleton._instance == null)
			{
				Singleton._instance = new Singleton();
			}
			return Singleton._instance;
		}
	}
}
