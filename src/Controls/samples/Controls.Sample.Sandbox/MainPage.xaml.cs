﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Maui.Controls.Sample
{
	public partial class MainPage : ContentPage
	{
		//public MainPage()
		//{
		//	InitializeComponent();
		//}

		private ObservableCollection<string> items = new();
		
		public MainPage()
		{
			InitializeComponent();

			this.items.Add("item: " + this.items.Count);

			this.cv1.ItemsSource = this.items;
		}

		private void ButtonAdd_Clicked(object sender, System.EventArgs e)
		{
			double collectionViewHeight = this.cv1.DesiredSize.Height;

			this.items.Add("item: " + this.items.Count);
		}
	}
}