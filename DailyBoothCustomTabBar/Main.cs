
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace DailyBoothCustomTabBar
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}
	
	
	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class AppDelegate : UIApplicationDelegate
	{
		UITabBarController tabBar;
		UINavigationController [] navigationRoots;
		
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
			
			UIImage normal = UIImage.FromBundle("Images/camera.png");
			UIImage highlight = UIImage.FromBundle("Images/cameraSelected.png");
			UIImage navBg = UIImage.FromBundle("Images/navigationBarBackgroundRetro.png");
			
			tabBar = new UIRaisedCenterButtonTabBar(normal, highlight, delegate { var alert = new UIAlertView("Center Button","That Big Ass Button Was Pushed", null, "Ok"); alert.Show(); });
			
			
			UIViewController vc = new UIViewController();
			
			
			navigationRoots = new UINavigationController [5] {
				new UINavigationController  (vc) {
					TabBarItem = new UITabBarItem ("Home", UIImage.FromBundle ("Images/tab_feed.png"), 0)
				},
				new UINavigationController  (vc) {
					TabBarItem = new UITabBarItem ("Live", UIImage.FromBundle ("Images/tab_live.png"), 1)
				},
				new UINavigationController  (vc) {
					TabBarItem = new UITabBarItem ("", null, 2)
				},
				new UINavigationController  (vc) {
					TabBarItem = new UITabBarItem ("Profile", UIImage.FromBundle ("Images/tab_feed_profile.png"), 3)
				},
				new UINavigationController  (vc) {
					TabBarItem = new UITabBarItem ("Messages", UIImage.FromBundle ("Images/tab_messages.png"), 4)
				}
			};
			
			

			tabBar.SetViewControllers (navigationRoots, false);
			
			window.Add(tabBar.View);
			window.MakeKeyAndVisible ();
			
			return true;
		}

		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
	}
}

