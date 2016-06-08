using System;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using Turbohud.AutoUpdate.Exceptions;

namespace Turbohud.AutoUpdate.Services
{
	public abstract class FindLinkBaseService
	{
		protected async Task<Uri> FindLink(Uri uri, string selector, Func<IElement, bool> predicate)
		{
			var config = AngleSharp.Configuration.Default.WithDefaultLoader().WithJavaScript();

			var page = await BrowsingContext.New(config).OpenAsync(uri.ToString());

			var latestPageLink = page.QuerySelectorAll(selector).FirstOrDefault(predicate);

			var relativeUriText = latestPageLink?.Attributes["href"]?.Value;

			if (string.IsNullOrEmpty(relativeUriText))
			{
				throw new UriNotFoundException();
			}

			return new Uri(relativeUriText, UriKind.RelativeOrAbsolute).ToAbsoluteUri(uri);
		}
	}
}