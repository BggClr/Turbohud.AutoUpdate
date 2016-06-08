using System.Threading.Tasks;
using Turbohud.AutoUpdate.Services;

namespace Turbohud.AutoUpdate
{
	class Program
	{
		static void Main(string[] args)
		{
			Run().Wait();
		}

		static async Task Run()
		{
			var findLinkToLatestThreadService = new FindLinkToLatestThreadPageService();
			var latestReleasePageLink = await findLinkToLatestThreadService.FindLink();
			var findLinkToDownloadFilePageService = new FindLinkToDownloadFilePageService();
			var downloadFilePageLink = await findLinkToDownloadFilePageService.FindLink(latestReleasePageLink);
			var findLinkToFileService = new FindLinkToFileService();
			var downloadFileLink = await findLinkToFileService.FindLink(downloadFilePageLink);

			var donwloadFileService = new DonwloadFileService();
			var filePath = donwloadFileService.Download(downloadFileLink);
			var extractFileService = new ExtractFileToCurrentDirectoryService();
			extractFileService.ExtractFile(filePath);
		}
	}
}
