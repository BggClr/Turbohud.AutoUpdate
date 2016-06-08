using System;
using System.Threading.Tasks;

namespace Turbohud.AutoUpdate.Services
{
	public class FindLinkToDownloadFilePageService : FindLinkBaseService
	{
		public async Task<Uri> FindLink(Uri uri)
		{
			var directXVersionText = $"directx {Configuration.DirectxVersion} build";
			return await FindLink(uri, "a", p => p.InnerHtml.ToLowerInvariant().Contains(directXVersionText));
		}
	}
}