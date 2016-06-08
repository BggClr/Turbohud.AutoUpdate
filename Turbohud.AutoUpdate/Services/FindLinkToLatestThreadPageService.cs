using System;
using System.Threading.Tasks;
using AngleSharp.Extensions;

namespace Turbohud.AutoUpdate.Services
{
	public class FindLinkToLatestThreadPageService : FindLinkBaseService
	{
		public async Task<Uri> FindLink()
		{
			return await FindLink(Configuration.ReleasesPageUrl, "a.thread-link", p => p.Text().ToLowerInvariant().Contains("latest"));
		}
	}
}