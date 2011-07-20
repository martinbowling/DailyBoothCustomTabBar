using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace DailyBoothCustomTabBar
{
	public class UIRaisedCenterButtonTabBar  : UITabBarController 
	{
		UIButton centerButton;
		UIImage normalState;
		UIImage highlightedState;
		
		public event NSAction Tapped;
		
		public UIRaisedCenterButtonTabBar (UIImage normal, UIImage highlighted, NSAction tapped) : base ()
		{
			normalState = normal;
			highlightedState = highlighted;
			if (tapped != null)
				Tapped += tapped;
		}
			
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			if (centerButton == null){
				
				centerButton = UIButton.FromType(UIButtonType.Custom);
				centerButton.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleTopMargin;
				centerButton.SetImage(normalState, UIControlState.Normal);
				centerButton.SetImage(highlightedState, UIControlState.Highlighted);
				centerButton.Frame = new RectangleF(0,0,normalState.Size.Width, normalState.Size.Height);
				float heightDiff = normalState.Size.Height - TabBar.Frame.Size.Height;
				PointF center = TabBar.Center;
				if (heightDiff < 0 ) {
					centerButton.Center = center;
				}
				else {
					center.Y = center.Y - heightDiff /2.0f;
					centerButton.Center = center;
				}
			
				if (Tapped != null){
					centerButton.TouchUpInside += delegate(object sender, EventArgs e) {
						 Tapped();
					};
				}
				this.View.AddSubview(centerButton);
				this.View.BringSubviewToFront(centerButton);
			}
		}
		
		public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate (fromInterfaceOrientation);
			
			if (centerButton != null){
				this.View.BringSubviewToFront(centerButton);
			}
		}
		
	}
}



