using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural.Proxy
{
	class Program
	{
		//static void Main(string[] args)
		//{
		//	Proxy proxy = new Proxy();
		//	proxy.Request();

		//	Console.ReadKey();
		//}
	}

	/// <summary>
	/// Subject   (IMath)
	/// 1. defines the common interface for RealSubject and Proxy so that a Proxy can be used
	///		anywhere a RealSubject is expected.
	/// </summary>
	public abstract class Subject
	{
		public abstract void Request();
	}

	/// <summary>
	/// RealSubject (Math)
	/// 1. defines the real object that the proxy represents.
	/// </summary>
	public class RealSubject : Subject
	{
		public override void Request()
		{
			Console.WriteLine("Called RealSubject.Request");
		}
	}

	/// <summary>
	/// Proxy (MathProxy)
	/// 1. maintains a reference that lets the proxy access the real subject. Proxy may refer to a 
	///		Subject if the RealSubject and Subject interfaces are the same.
	///	2. provides an interface identical to Subject's so that a proxy can be subtituted for the
	///		real subject.
	///	3. controls access to the real subject and may be responsible for creating and deleting it.
	///	4. other reponsiblities depend on the kind of proxy:
	///		*remote proxies are reponsible for encoding a request and its arguments and for sending
	///			sending the encoded request to the real subject in a different address space.
	///		*virtual proxies may cache additional information about the real subject so that they can
	///			postpone accessing it. For example, the ImageProxy from the Motivation caches the real
	///			images' extent.
	///		*protection proxies check that the caller has the access permissions required to perform a
	///			request.
	/// </summary>
	public class Proxy : Subject
	{
		private RealSubject _realSubject;

		public override void Request()
		{
			// Use "lazy initalization"
			if (_realSubject == null)
			{
				_realSubject = new RealSubject();
			}
			_realSubject.Request();
		}
	}
}
