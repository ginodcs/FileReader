using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public interface IFileManager
    {
        /// <summary>
        /// Read a text file
        /// </summary>
        /// <param name="pathFile">return the file as string</param>
        /// <returns></returns>
        string ReadFile(string pathFile);
    }
}
