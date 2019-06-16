using System;

namespace Source.Runtime.Core
{
	/// <summary>
	/// Define a button in the Unity Inspector
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public sealed class ButtonAttribute : Attribute
	{
		public string ButtonName { get; private set; }
		public int PixelSpacing { get; private set; }

		/// <summary>
		/// Constructor
		/// <param name="buttonName">Visual name of the button, if null or empty, then the method name will be used</param>
		/// <param name="pixelSpacing">Pixel space from the previous GUILayout control</param>
		/// </summary>
		public ButtonAttribute(string buttonName = null, int pixelSpacing = 0)
		{
			ButtonName = buttonName;
			PixelSpacing = pixelSpacing;
		}
	}
}