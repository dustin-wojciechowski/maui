using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidX.CoordinatorLayout.Widget;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Xunit;

namespace Microsoft.Maui.DeviceTests
{
	[Category(TestCategory.TabbedPage)]
	public partial class TabbedPageTests : ControlsHandlerTestBase
	{
		[Fact]
		public async Task ChangingBottomTabAttributesDoesntRecreateBottomTabs()
		{
			SetupBuilder();

			var tabbedPage = CreateBasicTabbedPage(true, pages: new[]
			{
				new ContentPage() { Title = "Tab 1", IconImageSource = "red.png" },
				new ContentPage() { Title = "Tab 2", IconImageSource = "red.png" }
			});

			await CreateHandlerAndAddToWindow<TabbedViewHandler>(tabbedPage, async (handler) =>
			{
				var menu = GetBottomNavigationView(handler).Menu;
				var menuItem1 = menu.GetItem(0);
				var menuItem2 = menu.GetItem(1);
				var icon1 = menuItem1.Icon;
				var icon2 = menuItem2.Icon;
				var title1 = menuItem1.TitleFormatted;
				var title2 = menuItem2.TitleFormatted;

				tabbedPage.Children[0].Title = "new Title 1";
				tabbedPage.Children[0].IconImageSource = "blue.png";

				tabbedPage.Children[1].Title = "new Title 2";
				tabbedPage.Children[1].IconImageSource = "blue.png";

				// let the icon and title propagate
				await AssertionExtensions.Wait(() => menuItem1.Icon != icon1);

				menu = GetBottomNavigationView(handler).Menu;
				Assert.Equal(menuItem1, menu.GetItem(0));
				Assert.Equal(menuItem2, menu.GetItem(1));

				menuItem1.Icon.AssertColorAtCenter(Android.Graphics.Color.Blue);
				menuItem2.Icon.AssertColorAtCenter(Android.Graphics.Color.Blue);

				Assert.NotEqual(icon1, menuItem1.Icon);
				Assert.NotEqual(icon2, menuItem2.Icon);
				Assert.NotEqual(title1, menuItem1.TitleFormatted);
				Assert.NotEqual(title2, menuItem2.TitleFormatted);
			});
		}


		BottomNavigationView GetBottomNavigationView(TabbedViewHandler tabViewHandler)
		{
			var layout = (tabViewHandler.PlatformView as Android.Views.IViewParent).FindParent((view) => view is CoordinatorLayout)
				as CoordinatorLayout;

			return layout.GetFirstChildOfType<BottomNavigationView>();
		}
	}
}
