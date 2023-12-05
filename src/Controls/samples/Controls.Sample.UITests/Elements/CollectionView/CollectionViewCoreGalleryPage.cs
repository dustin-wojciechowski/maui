using Controls.Sample.UITests;
using Maui.Controls.Sample.CollectionViewGalleries.AlternateLayoutGalleries;
using Maui.Controls.Sample.CollectionViewGalleries.EmptyViewGalleries;
using Maui.Controls.Sample.CollectionViewGalleries.GroupingGalleries;
using Maui.Controls.Sample.CollectionViewGalleries.HeaderFooterGalleries;
using Maui.Controls.Sample.CollectionViewGalleries.ItemSizeGalleries;
using Maui.Controls.Sample.CollectionViewGalleries.ReorderingGalleries;
using Maui.Controls.Sample.CollectionViewGalleries.ScrollModeGalleries;
using Maui.Controls.Sample.CollectionViewGalleries.SelectionGalleries;
using Maui.Controls.Sample.CollectionViewGalleries.SpacingGalleries;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.CollectionViewGalleries
{

	public class CollectionViewGalleryNavigation : NavigationPage
	{
		public CollectionViewGalleryNavigation()
		{
			PushAsync(new TemplateCodeCollectionViewGallery(LinearItemsLayout.Vertical));
		}

	}

	public class CollectionViewCoreGalleryPage : ContentPage
	{
		public CollectionViewCoreGalleryPage()
		{
			Content = new ScrollView
			{
				Content = new StackLayout
				{
					Spacing = 5,
					Children =
					{
						// VisitAndUpdateItemsSource (src\Compatibility\ControlGallery\src\UITests.Shared\Tests\CollectionViewUITests.cs)
						TestBuilder.NavButton("Default Text Galleries", () => new DefaultTextGallery(), Navigation),
						TestBuilder.NavButton("DataTemplate Galleries", () => new DataTemplateGallery(), Navigation),
						TestBuilder.NavButton("Observable Collection Galleries", () => new ObservableCollectionGallery(), Navigation),
						// SelectionShouldUpdateBinding (src\Compatibility\ControlGallery\src\Issues.Shared\CollectionViewBoundSingleSelection.cs)
						// ItemsFromViewModelShouldBeSelected (src\Compatibility\ControlGallery\src\Issues.Shared\CollectionViewBoundMultiSelection.cs)
						TestBuilder.NavButton("Selection Galleries", () => new SelectionGallery(), Navigation),			
						// EmptyViewShouldNotCrash (src\Compatibility\ControlGallery\src\Issues.Shared\Issue9196.xaml.cs)
						TestBuilder.NavButton("EmptyView Galleries", () => new EmptyViewGallery(), Navigation),
						// ClearingGroupedCollectionViewShouldNotCrash (src\Compatibility\ControlGallery\src\Issues.Shared\Issue8899.cs)
						TestBuilder.NavButton("Grouping Galleries", () => new GroupingGallery(), Navigation),
						// CollectionViewBindingErrorsShouldBeZero (src\Compatibility\ControlGallery\src\Issues.Shared\CollectionViewBindingErrors.xaml.cs)
						TestBuilder.NavButton("CollectionView Binding Errors", () => new CollectionViewBindingErrors(), Navigation),
						// AddingGroupToUnviewedGroupedCollectionViewShouldNotCrash (src\Compatibility\ControlGallery\src\Issues.Shared\Issue7700.cs)
						TestBuilder.NavButton("CollectionView Inside TabbedPage", () => new CollectionViewTabbedPage(), Navigation),	
						// CollectionViewShouldSourceShouldUpdateWhileInvisible (src\Compatibility\ControlGallery\src\Issues.Shared\Issue13126.cs)
						TestBuilder.NavButton("CollectionView Dynamically Load", () => new CollectionViewDynamicallyLoad(), Navigation),
					}
				}
			};
		}
	}
}