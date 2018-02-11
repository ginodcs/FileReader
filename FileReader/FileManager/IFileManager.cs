﻿using System;
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
        /// <param name="pathFile">Source path of file</param>
        /// <param name="encrypt">True to encrypt the text</param>
        /// <returns>The file as string</returns>
        string ReadFile(string pathFile, bool encrypt = false);

        /// <summary>
        /// Read a text file or xml file
        /// </summary>
        /// <param name="pathFile">Source path of file</param>
        /// <param name="typeFile">Type of file: TXT or XML</param>
        /// <param name="role"></param>
        /// <returns>The file as string</returns>
        string ReadFile(string pathFile, string typeFile, Roles role = Roles.Viewer);
    }

}
