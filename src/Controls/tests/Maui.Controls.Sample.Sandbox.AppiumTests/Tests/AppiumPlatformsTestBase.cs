﻿using NUnit.Framework;
using Microsoft.Maui.Appium;
using TestUtils.Appium.UITests;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium;

namespace Maui.Controls.Sample.Sandbox.AppiumTests
{
#if ANDROID
	[TestFixture(TestDevice.Android)]
#elif IOSUITEST
	[TestFixture(TestDevice.iOS)]
#elif MACUITEST
	[TestFixture(TestDevice.Mac)]
#elif WINTEST
	[TestFixture(TestDevice.Windows)]
#endif
	public class AppiumPlatformsTestBase : AppiumUITestBase
	{
		TestDevice _testDevice;
		public AppiumPlatformsTestBase(TestDevice device)
		{
			_testDevice = device;
		}

		[TearDown]
		public void TearDown()
		{
			//this crashes on Android
			if(!IsAndroid && !IsWindows)
				Driver?.ResetApp();
		}


		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			InitialSetup();
		}

		[OneTimeTearDown()]
		public void OneTimeTearDown()
		{
			Teardown();
		}

		public override TestConfig GetTestConfig()
		{
			var testConfig = new TestConfig(_testDevice, "com.microsoft.maui.sandbox")
			{
				BundleId = "com.microsoft.maui.sandbox",
			};
			switch (_testDevice)
			{
				case TestDevice.Android:
					//_appiumOptions.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AppPackage, "com.microsoft.maui.sandbox");
					// activity { com.microsoft.maui.sandbox / crc64fa090d87c1ce7f0b.MainActivity}
					//_appiumOptions.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AppActivity, "MainActivity");
					break;
				case TestDevice.iOS:
					testConfig.DeviceName = "iPhone X";
					testConfig.PlatformVersion = Environment.GetEnvironmentVariable("IOS_PLATFORM_VERSION") ?? "14.4";
					testConfig.Udid = Environment.GetEnvironmentVariable("IOS_SIMULATOR_UDID") ?? "";
					break;
				case TestDevice.Mac:

					break;
				case TestDevice.Windows:
					testConfig.DeviceName = "WindowsPC";
					testConfig.AppPath = Environment.GetEnvironmentVariable("WINDOWS_APP_PATH") ?? "";
					break;
			}

			return testConfig;
		}
	}
}
