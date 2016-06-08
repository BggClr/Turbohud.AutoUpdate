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
						if (!Directory.Exists(Path.GetDirectoryName(filePath)))
						{
							Directory.CreateDirectory(Path.GetDirectoryName(filePath));
						}
						file.ExtractToFile(filePath, true);
					}
				}
			}
		}
	}
}