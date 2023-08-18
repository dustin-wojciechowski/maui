﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using WImage = Microsoft.UI.Xaml.Controls.Image;
using WImageSource = Microsoft.UI.Xaml.Media.ImageSource;

namespace Microsoft.Maui.Platform
{
	internal static class ImageSourcePartExtensions
	{
		public static async Task<IImageSourceServiceResult<WImageSource>?> UpdateSourceAsync(
			this IImageSourcePart image,
			FrameworkElement destinationContext,
			IMauiContext? mauiContext,
			Action<WImageSource?> setImage,
			CancellationToken cancellationToken = default)
		{
			image.UpdateIsLoading(false);

			var imageSource = image.Source;
			if (imageSource == null)
				return null;

			if (mauiContext == null)
				return null;

			var events = image as IImageSourcePartEvents;

			events?.LoadingStarted();
			image.UpdateIsLoading(true);

			try
			{
				var imageSourceServiceProvider = mauiContext.Services.GetRequiredService<IImageSourceServiceProvider>();
				var imageSourceService = imageSourceServiceProvider.GetRequiredImageSourceService(imageSource);

				var scale = destinationContext.XamlRoot?.RasterizationScale ?? 1;
				var result = await imageSourceService.GetImageSourceAsync(imageSource, (float)scale, cancellationToken);
				var uiImage = result?.Value;

				var applied = !cancellationToken.IsCancellationRequested && imageSource == image.Source;

				// only set the image if we are still on the same one
				if (applied)
				{
					setImage(uiImage);
					if (destinationContext is WImage imageView)
						imageView.UpdateIsAnimationPlaying(image);
				}

				events?.LoadingCompleted(applied);

				return result;
			}
			catch (OperationCanceledException)
			{
				// no-op
				events?.LoadingCompleted(false);
			}
			catch (Exception ex)
			{
				setImage?.Invoke(null);
				events?.LoadingFailed(ex);
			}
			finally
			{
				// only mark as finished if we are still working on the same image
				if (imageSource == image.Source)
				{
					image.UpdateIsLoading(false);
				}
			}

			return null;
		}
	}
}