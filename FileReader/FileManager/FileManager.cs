﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileReader
{
    public class FileManager : IFileManager
    {
        public const string TXTFILE = "TXT";
        public const string XMLFILE = "XML";
        private const string FILENOTSUPPORTED = "Cannot read this type of file. The files supported are TXT and XML.";
        private const string NOTMACH = "The type of file chosen does not match whith the file extension";
        private const string NOTPERMISSION = "Don't have enough permissions";

        #region Publics methods

        /// <summary>
        /// Read a text file
        /// </summary>
        /// <param name="pathFile">Source path of file</param>
        /// <param name="encrypt">True to encrypt the text</param>
        /// <returns>The file as string</returns>
        public string ReadFile(string pathFile, bool encrypt = false, Roles role = Roles.Viewer)
        {
           return  this.ReadTextFile(pathFile, encrypt, role);
        }

        /// <summary>
        /// Read a text file or xml file
        /// </summary>
        /// <param name="pathFile">Source path of file</param>
        /// <param name="typeFile">Type of file: TXT or XML</param>
        /// <param name="encrypt">True to encrypt the text</param>
        /// <param name="role">Only active for XML files</param>
        /// <returns>The file as string</returns>
        public string ReadFile(string pathFile, string typeFile, bool encrypt = false, Roles role = Roles.Viewer)
        {
            string text = string.Empty;

            switch(typeFile)
            {
                case TXTFILE:
                    text = this.ReadTextFile(pathFile, encrypt, role);
                    break;
                case XMLFILE:
                    text = this.ReadXMLFile(pathFile, encrypt, role);
                    break;
                default:
                    text = FILENOTSUPPORTED;
                    break;
            }

            return text;
        }

        #endregion

        #region Private methods

        private string ReadTextFile(string pathFile, bool encrypt, Roles role)
        {
            string text = string.Empty;
            string extension = Path.GetExtension(pathFile);

            if (Authorize.HasPermission(role, Permissions.ReadXMLFile))
            {
                if (extension.IndexOf(TXTFILE, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var fileStream = new FileStream(pathFile, FileMode.Open, FileAccess.Read);

                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        text = streamReader.ReadToEnd();

                        if (encrypt)
                        {
                            text = Security.Encrypt(text);
                        }
                    }
                }
                else
                {
                    text = NOTMACH;
                }
            }
            else
            {
                text = NOTPERMISSION;
            }

            return text;
        }

        private string ReadXMLFile(string pathFile, bool encrypt, Roles role)
        {
            string text = string.Empty;

            if (Authorize.HasPermission(role, Permissions.ReadXMLFile))
            {
                string extension = Path.GetExtension(pathFile);

                if (extension.IndexOf(XMLFILE, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var xml = XDocument.Load(pathFile);

                    text = xml.ToString();

                    if (encrypt)
                    {
                        text = Security.Encrypt(text);
                    }
                }
                else
                {
                    text = NOTMACH;
                }
            }
            else
            {
                text = NOTPERMISSION;
            }

            return text;
        }

        #endregion


    }
}
