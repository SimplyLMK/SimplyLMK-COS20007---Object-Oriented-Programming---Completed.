using System;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
	public static class ExtensionMethods
	{
		public static int ReadInteger(this StreamReader sr)
		{
			return Convert.ToInt32(sr.ReadLine());
		}

		public static float ReadSingle(this StreamReader sr)
		{
			return Convert.ToSingle(sr.ReadLine());
		}

		public static Color ReadColor(this StreamReader sr)
		{
			return Color.RGBColor(sr.ReadSingle(), sr.ReadSingle(), sr.ReadSingle());
		}

        public static void WriteColor(this StreamWriter sw, Color clr)
        {
            sw.WriteLine("{0}\n{1}\n{2}", clr.R, clr.G, clr.B);
        }

    }
}

