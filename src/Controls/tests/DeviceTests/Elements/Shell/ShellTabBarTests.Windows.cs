﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Platform;
using Xunit;
using NavigationView = Microsoft.UI.Xaml.Controls.NavigationView;
using WFrameworkElement = Microsoft.UI.Xaml.FrameworkElement;
using WNavigationViewItem = Microsoft.UI.Xaml.Controls.NavigationViewItem;


namespace Microsoft.Maui.DeviceTests
{
	[Category(TestCategory.Shell)]
	public partial class ShellTests
	{
		List<WNavigationViewItem> GetTabBarItems(Shell shell)
		{
			var shellItemHandler = shell.CurrentItem.Handler as ShellItemHandler;
			var navView = shellItemHandler.PlatformView as MauiNavigationView;

			return navView.TopNavArea.GetChildren<WNavigationViewItem>().ToList();
		}

		async Task ValidateTabBarItemColor(ShellSection item, Color expectedColor, bool hasColor)
		{
			var items = GetTabBarItems(item.FindParentOfType<Shell>());
			var platformItem =
				items.FirstOrDefault(x => x.Content.ToString().Equals(item.Title, StringComparison.OrdinalIgnoreCase));

			if (hasColor)
				await AssertionExtensions.AssertContainsColor(platformItem, expectedColor, item.FindMauiContext());
			else
				await AssertionExtensions.AssertDoesNotContainColor(platformItem, expectedColor, item.FindMauiContext());
		}
	}
}
