using System;
using System.IO;
using Tendy.BLL.Interfaces;
using System.Threading.Tasks;

namespace Tendy.BLL.Services
{
	public class FileUploader : IFileManager
	{
		const string path = @"C:\Project\FileStorage";

		public void Delete(string name)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}

		public Task DeleteAsync(string path)
		{
			return Task.Run(() =>
			{
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			});
		}

		public void DeleteRange(string[] names)
		{
			foreach (var item in names)
			{
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}
		}

		public string Upload(byte[] data, string extension, DateTime dateOfCreation)
		{
			Directory.CreateDirectory(path);

			var name = $"{path}\\{Guid.NewGuid().ToString()}-{dateOfCreation.Date}.{extension}";
			var f = File.Create(name);
			f.Write(data, 0, data.Length);

			return name;
		}

		public async Task<string> UploadAsunc(byte[] data, string extension, DateTime dateOfCreation)
		{
			Directory.CreateDirectory(path);

			var name = $"{path}\\{Guid.NewGuid().ToString()}-{dateOfCreation.Date}.{extension}";
			var f = File.Create(name);

			await f.WriteAsync(data, 0, data.Length);

			return name;
		}
	}
}
