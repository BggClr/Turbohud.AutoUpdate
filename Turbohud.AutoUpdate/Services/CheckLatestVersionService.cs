using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;

namespace Turbohud.AutoUpdate.Services
{
	public class CheckLatestVersionService
	{
		public async Task<bool> IsLocalVersionMatchesLatest()
		{
			var config = AngleSharp.Configuration.Default.WithDefaultLoader().WithJavaScript();
			var page = await BrowsingContext.New(config).OpenAsync(Configuration.ReleasesPageUrl.ToString());
			var localVersion = GetLocalVersion();
			return !string.IsNullOrEmpty(localVersion) && page.QuerySelectorAll("a.thread-link").Any(p => p.InnerHtml.ToLowerInvariant().Contains(localVersion));
		}

		private string GetLocalVersion()
		{
			if (File.Exists(Configuration.TurbohudFilename))
			{
				return FileVersionInfo.GetVersionInfo(Configuration.TurbohudFilename).FileVersion;
			}
			return "";
		}
	}
}