using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.AppiumTests.Issues;

public class Issue20801 : _IssuesUITest
{
	public override string Issue => "[Android] ImageButton Border does not fit to CornerRadius";

	public Issue20801(TestDevice device)
		: base(device)
	{ }

    [Test]
	public void CornersShouldBeProperlyRounded()
	{
		this.IgnoreIfPlatforms(new TestDevice[] { TestDevice.iOS, TestDevice.Mac, TestDevice.Windows });

		_ = App.WaitForElement("imageButton");

		// The test passes if corners are properly rounded
		VerifyScreenshot();
	}
}
