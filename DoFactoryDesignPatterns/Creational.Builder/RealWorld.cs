using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational.Builder
{
	class RealWorld
	{
		static void Main()
		{
			VehicleBuilder builder;
			Shop shop = new Shop();

			builder = new ScooterBuilder();
			shop.Construct(builder);
			builder.Vehicle.Show();

			builder = new CarBuilder();
			shop.Construct(builder);
			builder.Vehicle.Show();

			builder = new MotorCycleBuilder();
			shop.Construct(builder);
			builder.Vehicle.Show();

			Console.ReadKey();
		}

	}

	public class Shop
	{
		public void Construct(VehicleBuilder vehicleBuilder)
		{
			vehicleBuilder.BuildFrame();
			vehicleBuilder.BuildEngine();
			vehicleBuilder.BuildWheels();
			vehicleBuilder.BuildDoors();
		}
	}

	/// <summary>
	/// The 'Builder' abstract class.
	/// </summary>
	public abstract class VehicleBuilder
	{
		protected Vehicle vehicle;
		public Vehicle Vehicle
		{
			get { return vehicle; }
		}

		public abstract void BuildFrame();
		public abstract void BuildEngine();
		public abstract void BuildWheels();
		public abstract void BuildDoors();
	}

	/// <summary>
	/// The 'ConcreteBuilder' class.
	/// </summary>
	public class MotorCycleBuilder : VehicleBuilder
	{
		public MotorCycleBuilder()
		{
			this.vehicle = new Vehicle("MotorCycle");
		}

		public override void BuildFrame()
		{
			vehicle["frame"] = "MotorCycle Frame";
		}

		public override void BuildEngine()
		{
			vehicle["engine"] = "500 cc";
		}

		public override void BuildWheels()
		{
			vehicle["wheels"] = "2";
		}

		public override void BuildDoors()
		{
			vehicle["doors"] = "0";
		}
	}

	public class CarBuilder : VehicleBuilder
	{
		public CarBuilder()
		{
			vehicle = new Vehicle("Car");
		}

		public override void BuildFrame()
		{
			vehicle["frame"] = "Car Frame";
		}

		public override void BuildEngine()
		{
			vehicle["engine"] = "2500 cc";
		}

		public override void BuildWheels()
		{
			vehicle["wheels"] = "4";
		}

		public override void BuildDoors()
		{
			vehicle["doors"] = "4";
		}
	}

	public class ScooterBuilder : VehicleBuilder
	{
		public ScooterBuilder()
		{
			vehicle = new Vehicle("Scooter");
		}

		public override void BuildFrame()
		{
			vehicle["frame"] = "Scooter Frame";
		}

		public override void BuildEngine()
		{
			vehicle["engine"] = "50 cc";
		}

		public override void BuildWheels()
		{
			vehicle["wheels"] = "2";
		}

		public override void BuildDoors()
		{
			vehicle["doors"] = "0";
		}
	}

	/// <summary>
	/// The 'Product' class.
	/// </summary>
	public class Vehicle
	{
		private string _vehicleType;
		private Dictionary<string, string> _parts = new Dictionary<string, string>();

		public Vehicle(string vehicleType)
		{
			this._vehicleType = vehicleType;
		}

		public string this[string index]
		{
			get { return _parts[index]; }
			set { _parts[index] = value; }
		}

		public void Show()
		{
			Console.WriteLine("\n---------------------------------------");
			Console.WriteLine("Vehicle Type: {0}", _vehicleType);
			Console.WriteLine(" Frame: {0}", _parts["frame"]);
			Console.WriteLine(" Engine: {0}", _parts["engine"]);
			Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);
			Console.WriteLine(" #Doors: {0}", _parts["doors"]);
		}
	}
}
