using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Tendy.BLL.Interfaces;
using System.Threading.Tasks;

namespace Tendy.BLL.Services
{
	public class FileUploader : IFileManager
	{
		const string path = @"C:\Project\FileStorage";

		public string UploadFile(byte[] data, string extension, DateTime dateOfCreation)
		{
			Directory.CreateDirectory(path);

			var name = $"{path}\\{Guid.NewGuid().ToString()}-{dateOfCreation.Date}.{extension}";
			var f = File.Create(name);

			f.Write(data, 0, data.Length);

			return name;
		}

		public async Task<string> UploadFileAsunc(byte[] data, string extension, DateTime dateOfCreation)
		{
			Directory.CreateDirectory(path);

			var name = $"{path}\\{Guid.NewGuid().ToString()}-{dateOfCreation.Date}.{extension}";
			var f = File.Create(name);

			await f.WriteAsync(data, 0, data.Length);

			return name;
		}
	}
}
