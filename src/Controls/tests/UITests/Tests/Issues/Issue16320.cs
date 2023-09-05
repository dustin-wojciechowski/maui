﻿using Microsoft.Maui.Appium;
using NUnit.Framework;

namespace Microsoft.Maui.AppiumTests.Issues
{
	public class Issue16320 : _IssuesUITest
	{
		public Issue16320(TestDevice device)
			: base(device)
		{ }

		public override string Issue => "Adding an item to a CollectionView with linear layout crashes";

		[Test]
		public void Issue16320Test()
		{
			// TODO: It looks like this test has never passed on Android, failing with 
			// "System.TimeoutException : Timed out waiting for element". We (e.g. ema) should
			// investigate and properly fix, but we'll ignore for now.
			UITestContext.IgnoreIfPlatforms(new[]
			{
				TestDevice.Android
			});

			App.Tap("Add");

			Assert.NotNull(App.WaitForElement("item: 1"));
		}
	}
}
