using System;

namespace Turbohud.AutoUpdate.Services
{
	public static class UriExtensions
	{
		public static Uri ToAbsoluteUri(this Uri relativeUri, Uri baseUri)
		{
			if (relativeUri.IsAbsoluteUri)
			{
				return relativeUri;
			}
			return new UriBuilder(baseUri.Scheme, baseUri.Host, baseUri.Port, relativeUri.ToString()).Uri;
		}
	}
}