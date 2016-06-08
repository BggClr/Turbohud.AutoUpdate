using System;
using System.Threading.Tasks;

namespace Turbohud.AutoUpdate.Services
{
	public class FindLinkToFileService : FindLinkBaseService
	{
		public async Task<Uri> FindLink(Uri uri)
		{
			return await FindLink(uri, "a#dlbutton", p => true);
		}
	}
}