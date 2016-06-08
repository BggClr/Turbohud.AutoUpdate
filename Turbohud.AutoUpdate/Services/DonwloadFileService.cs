using System;
using System.IO;
using System.Net;

namespace Turbohud.AutoUpdate.Services
{
	public class DonwloadFileService
	{
		public string Download(Uri uri)
		{
			var path = Path.GetTempFileName();

			var webClient = new WebClient();
			webClient.DownloadFile(uri, path);

			return path;
		}
	}
}