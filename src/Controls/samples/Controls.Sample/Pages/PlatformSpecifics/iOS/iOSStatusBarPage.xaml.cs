using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Maui.Controls.Sample.Pages
{
	public partial class iOSStatusBarPage : ContentPage
	{
		public iOSStatusBarPage()
		{
			InitializeComponent();
		}

		void NavigationPage_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new iOSStatusBarPageNavigationPageDemo());
		}

		void TabbedPage_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new iOSTabbedPageFlyoutPageDemo());
		}

		void FlyoutPage_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new iOSStatusBarPageFlyoutPageDemo());
		}

		void Shell_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new iOSShellDemo());
		}
	}

	public class iOSStatusBarPageNavigationPageDemo : ContentPage
	{
		public iOSStatusBarPageNavigationPageDemo()
		{
			Content = new StackLayout()
			{
				Margin = new Microsoft.Maui.Thickness(20),
				Children = {
					new Button()
					{
						Text = "Toggle Home Indicator",
						Command = new Command(() => On<iOS>().SetPrefersHomeIndicatorAutoHidden(!On<iOS>().PrefersHomeIndicatorAutoHidden()))
					},
					new Button()
					{
						Text = "Navigate back",
						Command = new Command(() => Navigation.PopAsync())
					}
				}
			};
		}
	}

	public class iOSStatusBarPageFlyoutPageDemo : Microsoft.Maui.Controls.FlyoutPage
	{
		public iOSStatusBarPageFlyoutPageDemo()
		{
			Flyout = new ContentPage()
			{
				Title = "Detail",
				Content = new StackLayout()
				{
					Children = {
						new Button()
						{
							Text = "Open page 1",
							Command = new Command(() => Detail = OpenPage("Page 1"))
						},
						new Button()
						{
							Text = "Open page 2",
							Command = new Command(() => Detail = OpenPage("Page 2"))
						}
					}
				}
			};

			Detail = new ContentPage()
			{
				Content = new StackLayout()
				{
					Margin = new Microsoft.Maui.Thickness(20),
					Children = {
						new Button()
						{
							Text = "Click to open the flyout",
							Command = new Command(() => IsPresented = true)
						},
						new Button()
						{
							Text = "Navigate back",
							Command = new Command(() => Navigation.PopAsync())
						}
					}
				}
			};
		}

		public ContentPage OpenPage(string title)
		{
			return new ContentPage()
			{
				Title = title,
				Content = new StackLayout()
				{
					Margin = new Microsoft.Maui.Thickness(20),
					Children = {
						new Button
						{
							Text = "Toggle Home Indicator",
							Command = new Command(() => On<iOS>().SetPrefersHomeIndicatorAutoHidden(!On<iOS>().PrefersHomeIndicatorAutoHidden()))
						},
						new Button()
						{
							Text = "Click to open the flyout",
							Command = new Command(() => IsPresented = true)
						},
						new Button
						{
							VerticalOptions = LayoutOptions.End,
							Text = "Back",
							Command = new Command(() => Navigation.PopAsync())
						}
					}
				}
			};
		}
	}

	public class iOSTabbedPageFlyoutPageDemo : Microsoft.Maui.Controls.TabbedPage
	{
		public iOSTabbedPageFlyoutPageDemo()
		{

			Children.Add
			(
				new ContentPage()
				{
					Title = "Tab 1",
					Content = new StackLayout()
						{
							Margin = new Microsoft.Maui.Thickness(20),
							Children =
							{
								new Button()
								{
									Text = "Toggle Home Indicator",
									Command = new Command(() => On<iOS>().SetPrefersHomeIndicatorAutoHidden(!On<iOS>().PrefersHomeIndicatorAutoHidden()))
								},
								new Button()
								{
									Text = "Navigate back",
									Command = new Command(() => Navigation.PopAsync())
								}
							}
						}
				}
			);

			Children.Add
			(
				new ContentPage()
				{
					Title = "Tab 2",
					Content = new StackLayout()
					{
						Margin = new Microsoft.Maui.Thickness(20),
						Children =
						{
							new Button()
							{
								Text = "Toggle Home Indicator",
								Command = new Command(() => On<iOS>().SetPrefersHomeIndicatorAutoHidden(!On<iOS>().PrefersHomeIndicatorAutoHidden()))
							},
							new Button()
							{
								Text = "Navigate back",
								Command = new Command(() => Navigation.PopAsync())
							}
						}
					}
				}
			);

		}
	}

	public class iOSShellDemo : Shell
	{
		public iOSShellDemo()
		{
			TabBar tabBar = new TabBar();

			var toggleHomeIndicatorButton1 = new Button()
			{
				Text = "Toggle Home Indicator",
				Command = new Command(() => On<iOS>().SetPrefersHomeIndicatorAutoHidden(!On<iOS>().PrefersHomeIndicatorAutoHidden()))
			};

			var contentPage1 = new ContentPage
			{
				Title = "Shell Tab 1",
				Content = new StackLayout()
				{
					Margin = new Microsoft.Maui.Thickness(20),
					Children =
					{
						toggleHomeIndicatorButton1,
						new Button()
						{
							Text = "Navigate back",
							Command = new Command(() => Navigation.PopAsync())
						}
					}
				}
			};

			toggleHomeIndicatorButton1.Command = new Command(() => contentPage1.On<iOS>().SetPrefersHomeIndicatorAutoHidden(!On<iOS>().PrefersHomeIndicatorAutoHidden()));

			tabBar.Items.Add
			(
				new Tab
				{
					Title = "Shell Tab 1",
					Items = {
						new ShellContent
						{
							Content = contentPage1,
							Title = "Shell Tab 1",
						}
					}
				}
			);

			var toggleHomeIndicatorButton2 = new Button()
			{
				Text = "Toggle Home Indicator",
				Command = new Command(() => On<iOS>().SetPrefersHomeIndicatorAutoHidden(!On<iOS>().PrefersHomeIndicatorAutoHidden()))
			};

			var contentPage2 = new ContentPage
			{
				Title = "Shell Tab 2",
				Content = new StackLayout()
				{
					Margin = new Microsoft.Maui.Thickness(20),
					Children =
					{
						toggleHomeIndicatorButton2,
						new Button()
						{
							Text = "Navigate back",
							Command = new Command(() => Navigation.PopAsync())
						}
					}
				}
			};

			toggleHomeIndicatorButton2.Command = new Command(() => contentPage2.On<iOS>().SetPrefersHomeIndicatorAutoHidden(!On<iOS>().PrefersHomeIndicatorAutoHidden()));

			tabBar.Items.Add
			(
				new Tab
				{
					Title = "Shell Tab 2",
					Items = {
						new ShellContent
						{
							Content = contentPage2,
							Title = "Shell Tab 2",
						}
					}
				}
			);

			Items.Add(tabBar);
		}
	}
}
