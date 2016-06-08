using System;
using System.IO;
using System.IO.Compression;

namespace Turbohud.AutoUpdate.Services
{
	public class ExtractFileToCurrentDirectoryService
	{
		public void ExtractFile(string path)
		{
			var directory = Directory.GetCurrentDirectory();
			using (var zip = ZipFile.OpenRead(path))
			{
				foreach (var file in zip.Entries)
				{
					var filePath = Path.Combine(directory, file.FullName);
					if (string.IsNullOrEmpty(file.Name))
					{
						Directory.CreateDirectory(filePath);
					}
					else
					{
						var directoryName = Path.GetDirectoryName(filePath);
						if (!Directory.Exists(directoryName))
						{
							Directory.CreateDirectory(directoryName);
						}
						file.ExtractToFile(filePath, true);
					}
				}
			}
		}
	}
}