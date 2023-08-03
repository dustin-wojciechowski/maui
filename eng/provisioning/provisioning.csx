if (IsMac)
{
	ForceJavaCleanup();
	MicrosoftOpenJdk ("11.0.13.8.1");
	Item ("Mono", "6.12.0.199");
	AppleCodesignIdentity("Apple Development: Jonathan Dick (FJL7285DY2)", "https://dl.internalx.com/qa/code-signing-entitlements/components-mac-ios-certificate.p12");
	AppleCodesignProfile("https://dl.internalx.com/qa/code-signing-entitlements/components-ios-provisioning.mobileprovision");
	AppleCodesignProfile("https://dl.internalx.com/qa/code-signing-entitlements/components-mac-provisioning.mobileprovision");
	AppleCodesignProfile("https://dl.internalx.com/qa/code-signing-entitlements/components-tvos-provisioning.mobileprovision");
}

string ANDROID_API_SDKS = Environment.GetEnvironmentVariable ("ANDROID_API_SDKS");

if(String.IsNullOrWhiteSpace(ANDROID_API_SDKS))
{
	AndroidSdk()
		.ApiLevel((AndroidApiLevel)21)
		.ApiLevel((AndroidApiLevel)22)
		.ApiLevel((AndroidApiLevel)23)
		.ApiLevel((AndroidApiLevel)24)
		.ApiLevel((AndroidApiLevel)28)
		.ApiLevel((AndroidApiLevel)29)
		.ApiLevel((AndroidApiLevel)30)
		.ApiLevel((AndroidApiLevel)31)
		.ApiLevel((AndroidApiLevel)32)
		.ApiLevel((AndroidApiLevel)33)
		.VirtualDevice("Android_x64_API23",   (AndroidApiLevel)23, AndroidSystemImageApi.Google,          AndroidSystemImageAbi.x86_64,    AndroidVirtualDevice.NEXUS_5X)
		.VirtualDevice("Android_x64_API24",   (AndroidApiLevel)24, AndroidSystemImageApi.Google,          AndroidSystemImageAbi.x86_64,    AndroidVirtualDevice.NEXUS_5X)
		.VirtualDevice("Android_x64_API25",   (AndroidApiLevel)25, AndroidSystemImageApi.Google,          AndroidSystemImageAbi.x86_64,    AndroidVirtualDevice.NEXUS_5X)
		.VirtualDevice("Android_x64_API26",   (AndroidApiLevel)26, AndroidSystemImageApi.Google,          AndroidSystemImageAbi.x86_64,    AndroidVirtualDevice.NEXUS_5X)
		.VirtualDevice("Android_x64_API27",   (AndroidApiLevel)27, AndroidSystemImageApi.Default, /*!!*/  AndroidSystemImageAbi.x86_64,    AndroidVirtualDevice.NEXUS_5X)
		.VirtualDevice("Android_x64_API28",   (AndroidApiLevel)28, AndroidSystemImageApi.GooglePlayStore, AndroidSystemImageAbi.x86_64,    AndroidVirtualDevice.NEXUS_5X)
		.VirtualDevice("Android_x64_API29",   (AndroidApiLevel)29, AndroidSystemImageApi.GooglePlayStore, AndroidSystemImageAbi.x86_64,    AndroidVirtualDevice.NEXUS_5X)
		.VirtualDevice("Android_x64_API30",   (AndroidApiLevel)30, AndroidSystemImageApi.GooglePlayStore, AndroidSystemImageAbi.x86_64,    AndroidVirtualDevice.NEXUS_5X)
		.VirtualDevice("Android_x64_API31",   (AndroidApiLevel)31, AndroidSystemImageApi.GooglePlayStore, AndroidSystemImageAbi.x86_64,    AndroidVirtualDevice.NEXUS_5X)
		.VirtualDevice("Android_x64_API32",   (AndroidApiLevel)32, AndroidSystemImageApi.GooglePlayStore, AndroidSystemImageAbi.x86_64,    AndroidVirtualDevice.NEXUS_5X)
		.VirtualDevice("Android_x64_API33",   (AndroidApiLevel)33, AndroidSystemImageApi.GooglePlayStore, AndroidSystemImageAbi.x86_64,    AndroidVirtualDevice.NEXUS_5X);
		
		
	if (IsArm64)
	{
		AndroidSdk()
			.VirtualDevice("Android_arm64_API23", (AndroidApiLevel)23, AndroidSystemImageApi.Google,          AndroidSystemImageAbi.ARM64_v8a, AndroidVirtualDevice.NEXUS_5X)
			.VirtualDevice("Android_arm64_API24", (AndroidApiLevel)24, AndroidSystemImageApi.Google,          AndroidSystemImageAbi.ARM64_v8a, AndroidVirtualDevice.NEXUS_5X)
			.VirtualDevice("Android_arm64_API25", (AndroidApiLevel)25, AndroidSystemImageApi.Google,          AndroidSystemImageAbi.ARM64_v8a, AndroidVirtualDevice.NEXUS_5X)
			.VirtualDevice("Android_arm64_API26", (AndroidApiLevel)26, AndroidSystemImageApi.Google,          AndroidSystemImageAbi.ARM64_v8a, AndroidVirtualDevice.NEXUS_5X)
			.VirtualDevice("Android_arm64_API27", (AndroidApiLevel)27, AndroidSystemImageApi.Google,          AndroidSystemImageAbi.ARM64_v8a, AndroidVirtualDevice.NEXUS_5X)
			.VirtualDevice("Android_arm64_API28", (AndroidApiLevel)28, AndroidSystemImageApi.GooglePlayStore, AndroidSystemImageAbi.ARM64_v8a, AndroidVirtualDevice.NEXUS_5X)
			.VirtualDevice("Android_arm64_API29", (AndroidApiLevel)29, AndroidSystemImageApi.GooglePlayStore, AndroidSystemImageAbi.ARM64_v8a, AndroidVirtualDevice.NEXUS_5X)
			.VirtualDevice("Android_arm64_API30", (AndroidApiLevel)30, AndroidSystemImageApi.GooglePlayStore, AndroidSystemImageAbi.ARM64_v8a, AndroidVirtualDevice.NEXUS_5X)
			.VirtualDevice("Android_arm64_API31", (AndroidApiLevel)31, AndroidSystemImageApi.GooglePlayStore, AndroidSystemImageAbi.ARM64_v8a, AndroidVirtualDevice.NEXUS_5X)
			.VirtualDevice("Android_arm64_API32", (AndroidApiLevel)32, AndroidSystemImageApi.GooglePlayStore, AndroidSystemImageAbi.ARM64_v8a, AndroidVirtualDevice.NEXUS_5X)
			.VirtualDevice("Android_arm64_API33", (AndroidApiLevel)33, AndroidSystemImageApi.GooglePlayStore, AndroidSystemImageAbi.ARM64_v8a, AndroidVirtualDevice.NEXUS_5X);
	}

	AndroidSdk().SdkManagerPackage ("build-tools;33.0.0");
}
else
{

	var androidSDK = AndroidSdk();
	foreach(var sdk in ANDROID_API_SDKS.Split(','))
	{
		Console.WriteLine("Installing SDK: {0}", sdk);
		androidSDK = androidSDK.SdkManagerPackage (sdk);
	}
}
