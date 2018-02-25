using System;
using System.Threading.Tasks;

namespace Tendy.BLL.Interfaces
{
	public interface IFileManager
	{
		/// <summary>
		/// Upload file
		/// </summary>
		/// <param name="data">source</param>
		/// <param name="extension">file extension</param>
		/// <param name="dateOfCreation">date of creation</param>
		/// <returns>created file path</returns>
		string Upload(byte[] data, string extension, DateTime dateOfCreation);

		/// <summary>
		/// Upload file Asunc
		/// </summary>
		/// <param name="data">source</param>
		/// <param name="extension">file extension</param>
		/// <param name="dateOfCreation">date of creation</param>
		/// <returns>created file path</returns>
		Task<string> UploadAsunc(byte[] data, string extension, DateTime dateOfCreation);

		/// <summary>
		/// Delete file
		/// </summary>
		/// <param name="name">file name</param>
		void Delete(string name);

		/// <summary>
		/// Delete file asunc
		/// </summary>
		/// <param name="name">file name</param>
		/// <returns></returns>
		Task DeleteAsync(string name);

		/// <summary>
		/// Delete range of files
		/// </summary>
		/// <param name="names">names of files to delete</param>
		void DeleteRange(string[] names);
	}
}
