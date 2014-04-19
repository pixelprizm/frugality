using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace shopping_compare
{
	public partial class App : Application
	{
		/// <summary>
		/// Provides easy access to the root frame of the Phone Application.
		/// </summary>
		/// <returns>The root frame of the Phone Application.</returns>
		public PhoneApplicationFrame RootFrame { get; private set; }

		/// <summary>
		/// Constructor for the Application object.
		/// </summary>
		public App()
		{
			// Global handler for uncaught exceptions. 
			UnhandledException += Application_UnhandledException;

			// Standard Silverlight initialization
			InitializeComponent();

			// Phone-specific initialization
			InitializePhoneApplication();

			// Show graphics profiling information while debugging.
			if (System.Diagnostics.Debugger.IsAttached)
			{
				// Display the current frame rate counters.
				Application.Current.Host.Settings.EnableFrameRateCounter = false;

				// Show the areas of the app that are being redrawn in each frame.
				//Application.Current.Host.Settings.EnableRedrawRegions = true;

				// Enable non-production analysis visualization mode, 
				// which shows areas of a page that are handed off to GPU with a colored overlay.
				//Application.Current.Host.Settings.EnableCacheVisualization = true;

				// Disable the application idle detection by setting the UserIdleDetectionMode property of the
				// application's PhoneApplicationService object to Disabled.
				// Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
				// and consume battery power when the user is not using the phone.
				PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
			}

			// Uncomment to get the title's letters' colors in the debug log (must also uncomment the "Uncomment to enable output of color values as decimal" section in ColorConverter.cs)
			//ColorConverter cc = new ColorConverter();
			//System.Diagnostics.Debugger.Log(0, "", "Letter colors:\n");
			//System.Diagnostics.Debugger.Log(0, "", "  $: " + cc.Convert(cc.DOLLAR_COLORINDEX, typeof(string), "decimal", null) + "\n");
			//System.Diagnostics.Debugger.Log(0, "", "  f: " + cc.Convert(cc.F_COLORINDEX, typeof(string), "decimal", null) + "\n");
			//System.Diagnostics.Debugger.Log(0, "", "  r: " + cc.Convert(cc.R_COLORINDEX, typeof(string), "decimal", null) + "\n");
			//System.Diagnostics.Debugger.Log(0, "", "  u: " + cc.Convert(cc.U_COLORINDEX, typeof(string), "decimal", null) + "\n");
			//System.Diagnostics.Debugger.Log(0, "", "  g: " + cc.Convert(cc.G_COLORINDEX, typeof(string), "decimal", null) + "\n");
			//System.Diagnostics.Debugger.Log(0, "", "  a: " + cc.Convert(cc.A_COLORINDEX, typeof(string), "decimal", null) + "\n");
			//System.Diagnostics.Debugger.Log(0, "", "  l: " + cc.Convert(cc.L_COLORINDEX, typeof(string), "decimal", null) + "\n");
			//System.Diagnostics.Debugger.Log(0, "", "  i: " + cc.Convert(cc.I_COLORINDEX, typeof(string), "decimal", null) + "\n");
			//System.Diagnostics.Debugger.Log(0, "", "  t: " + cc.Convert(cc.T_COLORINDEX, typeof(string), "decimal", null) + "\n");
			//System.Diagnostics.Debugger.Log(0, "", "  y: " + cc.Convert(cc.Y_COLORINDEX, typeof(string), "decimal", null) + "\n");
		}

		// Code to execute when the application is launching (eg, from Start)
		// This code will not execute when the application is reactivated
		private void Application_Launching(object sender, LaunchingEventArgs e)
		{
		}

		// Code to execute when the application is activated (brought to foreground)
		// This code will not execute when the application is first launched
		private void Application_Activated(object sender, ActivatedEventArgs e)
		{
		}

		// Code to execute when the application is deactivated (sent to background)
		// This code will not execute when the application is closing
		private void Application_Deactivated(object sender, DeactivatedEventArgs e)
		{
		}

		// Code to execute when the application is closing (eg, user hit Back)
		// This code will not execute when the application is deactivated
		private void Application_Closing(object sender, ClosingEventArgs e)
		{
		}

		// Code to execute if a navigation fails
		private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			if (System.Diagnostics.Debugger.IsAttached)
			{
				// A navigation has failed; break into the debugger
				System.Diagnostics.Debugger.Break();
			}
		}

		// Code to execute on Unhandled Exceptions
		private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
		{
			if (System.Diagnostics.Debugger.IsAttached)
			{
				// An unhandled exception has occurred; break into the debugger
				System.Diagnostics.Debugger.Break();
			}
		}

		#region Phone application initialization

		// Avoid double-initialization
		private bool phoneApplicationInitialized = false;

		// Do not add any additional code to this method
		private void InitializePhoneApplication()
		{
			if (phoneApplicationInitialized)
				return;

			// Create the frame but don't set it as RootVisual yet; this allows the splash
			// screen to remain active until the application is ready to render.
			RootFrame = new PhoneApplicationFrame();
			RootFrame.Navigated += CompleteInitializePhoneApplication;

			// Handle navigation failures
			RootFrame.NavigationFailed += RootFrame_NavigationFailed;

			// Ensure we don't initialize again
			phoneApplicationInitialized = true;
		}

		// Do not add any additional code to this method
		private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
		{
			// Set the root visual to allow the application to render
			if (RootVisual != RootFrame)
				RootVisual = RootFrame;

			// Remove this handler since it is no longer needed
			RootFrame.Navigated -= CompleteInitializePhoneApplication;
		}

		#endregion
	}
}