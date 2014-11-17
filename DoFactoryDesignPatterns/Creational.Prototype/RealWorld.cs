using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational.Prototype
{
	class RealWorld
	{
		static void Main()
		{
			ColorManager colorManager = new ColorManager();

			colorManager["red"] = new Color(255, 0, 0);
			colorManager["green"] = new Color(0, 255, 0);
			colorManager["blue"] = new Color(0, 0, 255);

			colorManager["angry"] = new Color(255, 54, 0);
			colorManager["peace"] = new Color(128, 211, 128);
			colorManager["flame"] = new Color(211, 34, 20);

			Color color1 = colorManager["red"].Clone() as Color;
			Color color2 = colorManager["peace"].Clone() as Color;
			Color color3 = colorManager["flame"].Clone() as Color;

			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Prototype' abstract class.
	/// </summary>
	public abstract class ColorPrototype
	{
		public abstract ColorPrototype Clone();
	}

	/// <summary>
	/// The 'ConcretePrototype' class.
	/// </summary>
	public class Color : ColorPrototype
	{
		private int _red;
		private int _green;
		private int _blue;

		public Color(int red, int green, int blue)
		{
			this._red = red;
			this._green = green;
			this._blue = blue;
		}

		public override ColorPrototype Clone()
		{
			Console.WriteLine("Cloning color RGB: {0,3},{1,3},{2,3}", this._red, this._green, this._blue);
			return this.MemberwiseClone() as ColorPrototype;
		}
	}

	/// <summary>
	/// Prototype manager.
	/// </summary>
	public class ColorManager
	{
		private Dictionary<string, ColorPrototype> _colors = new Dictionary<string, ColorPrototype>();

		public ColorPrototype this[string index]
		{
			get { return _colors[index]; }
			set { _colors.Add(index, value); }
		}
	}
}
