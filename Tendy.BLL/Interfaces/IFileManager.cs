using System;
using System.Threading.Tasks;

namespace Tendy.BLL.Interfaces
{
	public interface IFileManager
	{
		string UploadFile(byte[] data, string extension, DateTime dateOfCreation);
		Task<string> UploadFileAsunc(byte[] data, string extension, DateTime dateOfCreation);
	}
}
