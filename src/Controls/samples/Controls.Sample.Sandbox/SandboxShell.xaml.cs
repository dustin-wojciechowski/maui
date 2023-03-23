﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample
{
	public partial class SandboxShell : Shell
	{
		public SandboxShell()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnNavigated(ShellNavigatedEventArgs args)
		{
			base.OnNavigated(args);
			System.Diagnostics.Debug.WriteLine($"OnNavigated {args}");
		}
	}
}