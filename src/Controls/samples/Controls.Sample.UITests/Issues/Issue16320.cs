using Microsoft.Maui.Controls;
using Microsoft.Maui;
using System.Collections.ObjectModel;

namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Github, 16320, "CollectionView throws an exception after adding a second item", PlatformAffected.UWP)]
	public class Issue16320 : TestContentPage
	{
		protected override void Init()
		{
			var label = new Label() { Text = "A Label under the CollectionView" };

			var items = new ObservableCollection<string> { "Item: 1" };
			var collectionView = new CollectionView { AutomationId = "collectionView" };
			collectionView.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal);
			collectionView.ItemsSource = items;
			
			var innerGrid = new Grid();
			innerGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
			innerGrid.RowDefinitions.Add(new RowDefinition(GridLength.Star));
			innerGrid.Add(collectionView);
			innerGrid.Add(label, row: 1);

			var addButton = new Button { Text = "Add", AutomationId = "Add" };
			addButton.Clicked += (s, e) => { items.Add($"Item: {items.Count}"); };
		
			var mainGrid = new Grid();
			mainGrid.RowDefinitions.Add(new RowDefinition(GridLength.Star));
			mainGrid.RowDefinitions.Add(new RowDefinition(GridLength.Star));
			mainGrid.Add(innerGrid);
			mainGrid.Add(addButton);

			Content = mainGrid;
		}
	}
}
