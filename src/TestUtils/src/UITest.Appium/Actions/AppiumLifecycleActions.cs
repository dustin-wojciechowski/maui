﻿using UITest.Core;

namespace UITest.Appium
{
	public class AppiumLifecycleActions : ICommandExecutionGroup
	{
		const string LaunchAppCommand = "launchApp";
		const string BackgroundAppCommand = "backgroundApp";
		const string ResetAppCommand = "resetApp";
		const string CloseAppCommand = "closeApp";
		const string BackCommand = "back";

		protected readonly AppiumApp _app;

		readonly List<string> _commands = new()
		{
			LaunchAppCommand,
			BackgroundAppCommand,
			ResetAppCommand,
			CloseAppCommand,
			BackCommand
		};

		public AppiumLifecycleActions(AppiumApp app)
		{
			_app = app;
		}

		public bool IsCommandSupported(string commandName)
		{
			return _commands.Contains(commandName, StringComparer.OrdinalIgnoreCase);
		}

		public CommandResponse Execute(string commandName, IDictionary<string, object> parameters)
		{
			return commandName switch
			{
				LaunchAppCommand => LaunchApp(parameters),
				BackgroundAppCommand => BackgroundApp(parameters),
				ResetAppCommand => ResetApp(parameters),
				CloseAppCommand => CloseApp(parameters),
				BackCommand => Back(parameters),
				_ => CommandResponse.FailedEmptyResponse,
			};
		}

		CommandResponse LaunchApp(IDictionary<string, object> parameters)
		{
			if (_app?.Driver is null)
				return CommandResponse.FailedEmptyResponse;

#pragma warning disable CS0618 // Type or member is obsolete
			_app.Driver.LaunchApp();
#pragma warning restore CS0618 // Type or member is obsolete

			return CommandResponse.SuccessEmptyResponse;
		}

		CommandResponse BackgroundApp(IDictionary<string, object> parameters)
		{
			if (_app?.Driver is null)
				return CommandResponse.FailedEmptyResponse;

			_app.Driver.BackgroundApp();

			return CommandResponse.SuccessEmptyResponse;
		}

		CommandResponse ResetApp(IDictionary<string, object> parameters)
		{
			if (_app?.Driver is null)
				return CommandResponse.FailedEmptyResponse;

			_app.Driver.TerminateApp(_app.GetAppId());
			_app.Driver.ActivateApp(_app.GetAppId());

			return CommandResponse.SuccessEmptyResponse;
		}

		CommandResponse CloseApp(IDictionary<string, object> parameters)
		{
			if (_app?.Driver is null)
				return CommandResponse.FailedEmptyResponse;

#pragma warning disable CS0618 // Type or member is obsolete
			_app.Driver.CloseApp();
#pragma warning restore CS0618 // Type or member is obsolete

			return CommandResponse.SuccessEmptyResponse;
		}

		CommandResponse Back(IDictionary<string, object> parameters)
		{
			if (_app?.Driver is null)
				return CommandResponse.FailedEmptyResponse;

			// Navigate backwards in the history, if possible.
			_app.Driver.Navigate().Back();

			return CommandResponse.SuccessEmptyResponse;
		}
	}
}