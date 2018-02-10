using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public class FileManager : IFileManager
    {
        public string ReadFile(string pathFile)
        {
            string text;

            var fileStream = new FileStream(pathFile, FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }

            return text;
        }
    }
}
