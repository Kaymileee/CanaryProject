using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DANTN.Utils.FileStorages
{
  public class FileStorageService
  {
    Task<string> SaveFile(IFormFile file);
    string GetFileUrl(string fileName);
    Task SaveFileAsync(Stream mediaBinaryStream, string fileName);
    Task DeleteFileAsync(string fileName);
  }
}