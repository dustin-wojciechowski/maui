using Microsoft.Maui.Appium;
using NUnit.Framework;

namespace Microsoft.Maui.AppiumTests.Issues
{
	public class Issue16320 : _IssuesUITest
	{
		public Issue16320(TestDevice device) : base(device)
		{
		}

		public override string Issue => "CollectionView crashes on second item added";

		[Test]
		public void Issue16320Test()
		{
			App.Tap("Add");

			var collectionView = App.WaitForElement("collectionView").FirstOrDefault();
			
			//Assert.Equals(collectionView?.it)
		}
	}
}
