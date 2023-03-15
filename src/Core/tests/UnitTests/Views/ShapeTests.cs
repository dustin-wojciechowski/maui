﻿using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using Xunit;

namespace Microsoft.Maui.UnitTests.Views
{
	[Category(TestCategory.Core, TestCategory.View)]
	public class ShapeTests
	{
		[Fact]
		public void ShapeFillSubscribed()
		{
			var fill = new SolidColorBrush { Color = Colors.Red };
			var shape = new Rectangle { Fill = fill };

			bool fired = false;
			shape.PropertyChanged += (sender, e) =>
			{
				if (e.PropertyName == nameof(Shape.Fill))
					fired = true;
			};

			fill.Color = Colors.Green;
			Assert.True(fired, "PropertyChanged did not fire!");
		}

		[Fact]
		public async Task ShapeFillDoesNotLeak()
		{
			var fill = new SolidColorBrush(Colors.Red);	
			var reference = new WeakReference(new Rectangle { Fill = fill });

			await Task.Yield();
			GC.Collect();
			GC.WaitForPendingFinalizers();

			Assert.False(reference.IsAlive, "Shape should not be alive!");
		}

		[Fact]
		public void ShapeStrokeSubscribed()
		{
			var stroke = new SolidColorBrush { Color = Colors.Red };
			var shape = new Rectangle { Stroke = stroke };

			bool fired = false;
			shape.PropertyChanged += (sender, e) =>
			{
				if (e.PropertyName == nameof(Shape.Stroke))
					fired = true;
			};

			stroke.Color = Colors.Green;
			Assert.True(fired, "PropertyChanged did not fire!");
		}

		[Fact]
		public async Task ShapeStrokeDoesNotLeak()
		{
			var stroke = new SolidColorBrush(Colors.Red);
			var reference = new WeakReference(new Rectangle { Stroke = stroke });

			await Task.Yield();
			GC.Collect();
			GC.WaitForPendingFinalizers();

			Assert.False(reference.IsAlive, "Shape should not be alive!");
		}
	}
}