/*
 * (c) Abel Dieterich - HotkeyCode Inc.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Windows
{
	public static class ResourceLoader
	{
		private static string resourcePath = Application.StartupPath + "/resources";

		public static Image loadImage(string filename)
		{
			return Image.FromFile(resourcePath + "/" + filename + ".resource");
		}

		public static Icon loadIcon (string filename)
		{
			return Icon.ExtractAssociatedIcon(resourcePath + "/" + filename + ".resource");
		}
	}
}
