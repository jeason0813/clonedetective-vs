using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CloneDetective.Package
{
	/// <summary>
	/// This class implements the Clone Results tool window exposed by this package.
	///
	/// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
	/// usually implemented by the package implementer.
	///
	/// This class derives from the ToolWindowPane class provided from the MPF in order to use its 
	/// implementation of the IVsWindowPane interface.
	/// </summary>
	[Guid("62f54566-24de-4571-992f-7969d50227c3")]
	public sealed class CloneResultsToolWindow : ServicedToolWindowPane
	{
		// This is the user control hosted by the tool window; it is exposed to the base class 
		// using the Window property. Note that, even if this class implements IDispose, we are
		// not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
		// the object returned by the Window property.
		private CloneResultsControl _control;

		/// <summary>
		/// Standard constructor for the tool window.
		/// </summary>
		public CloneResultsToolWindow()
			: base(null)
		{
			// Set the window title reading it from the resources.
			Caption = Res.CloneResultsToolWindowTitle;

			// Set the image that will appear on the tab of the window frame
			// when docked with an other window.
			// The resource ID corresponds to the one defined in the resx file
			// while the Index is the offset in the bitmap strip. Each image in
			// the strip being 16x16.
			BitmapResourceID = 301;
			BitmapIndex = 2;

			_control = new CloneResultsControl();
		}

		/// <summary>
		/// This property returns the handle to the user control that should
		/// be hosted in the Tool Window.
		/// </summary>
		public override IWin32Window Window
		{
			get { return _control; }
		}

		protected override string HelpKeyword
		{
			get { return "CloneDetective.UI.CloneResults"; }
		}
	}
}