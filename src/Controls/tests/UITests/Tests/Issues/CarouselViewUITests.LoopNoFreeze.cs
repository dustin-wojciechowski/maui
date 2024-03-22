﻿using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.AppiumTests.Issues
{
	public class CarouselViewLoopNoFreeze : _IssuesUITest
	{
		readonly string _carouselAutomationId = "carouselView";
		readonly string _btnRemoveAutomationId = "btnRemove";
		readonly string _btnRemoveAllAutomationId = "btnRemoveAll";

		public CarouselViewLoopNoFreeze(TestDevice device)
			: base(device)
		{
		}

		public override string Issue => "CarouselView Loop=True default freezes iOS app";

		// Issue12574 (src\ControlGallery\src\Issues.Shared\Issue12574.cs
		[Test]
		public void Issue12574Test()
		{
			this.IgnoreIfPlatforms(new TestDevice[] { TestDevice.iOS },
				"Currently fails on iOS; see https://github.com/dotnet/maui/issues/19488");

			this.IgnoreIfPlatforms(new TestDevice[] { TestDevice.Android, TestDevice.Mac, TestDevice.Windows },
				"iOS specific Test");

			App.WaitForNoElement("0 item");

			var rect = App.FindElement(_carouselAutomationId).GetRect();
			var centerX = rect.CenterX();
			var rightX = rect.X - 5;
			App.DragCoordinates(centerX + 40, rect.CenterY(), rightX, rect.CenterY());

			App.WaitForNoElement("1 item");

			App.DragCoordinates(centerX + 40, rect.CenterY(), rightX, rect.CenterY());

			App.WaitForNoElement("2 item");

			App.Click(_btnRemoveAutomationId);

			App.WaitForNoElement("1 item");

			rightX = rect.X + rect.Width - 1;
			App.DragCoordinates(rect.X, rect.CenterY(), rightX, rect.CenterY());

			App.WaitForNoElement("0 item");
		}

		[Test]
		public void RemoveItemsQuickly()
		{
			this.IgnoreIfPlatforms(new TestDevice[] { TestDevice.iOS },
				"Currently fails on iOS; see https://github.com/dotnet/maui/issues/19488");

			this.IgnoreIfPlatforms(new TestDevice[] { TestDevice.Android, TestDevice.Mac, TestDevice.Windows },	
				"iOS specific Test");

			App.WaitForNoElement("0 item");
			App.Click(_btnRemoveAllAutomationId);

			// If we haven't crashed, then the other button should be here
			App.WaitForElement(_btnRemoveAutomationId);
		}
	}
}