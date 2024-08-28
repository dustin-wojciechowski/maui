﻿using System;
using System.Collections.Generic;
using System.Text;
using Controls.Sample.UITests;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.CollectionViewGalleries.ScrollModeGalleries
{
	internal class ScrollModeGallery : ContentPage
	{
		public ScrollModeGallery()
		{
			var descriptionLabel =
					new Label { Text = "Scroll Mode Galleries", Margin = new Thickness(2, 2, 2, 2) };

			Title = "Scroll Mode Galleries";

			Content = new ScrollView
			{
				Content = new StackLayout
				{
					Children =
					{
						descriptionLabel,
						TestBuilder.NavButton("Scroll Modes Testing", () =>
							new ScrollModeTestGallery(), Navigation),
						TestBuilder.NavButton("ItemsUpdatingScrollMode Gallery", () =>
							new ItemsUpdatingScrollModeGallery(), Navigation)
					}
				}
			};
		}
	}
}