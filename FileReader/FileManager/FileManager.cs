using System;
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
        public const string JSONFILE = "JSON";
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
            return ReadFile(pathFile, TXTFILE, encrypt, role);
        }

        /// <summary>
        /// Read a text file or xml file
        /// </summary>
        /// <param name="pathFile">Source path of file</param>
        /// <param name="typeFile">Type of file: TXT,  XML or JSON</param>
        /// <param name="encrypt">True to encrypt the text</param>
        /// <param name="role"></param>
        /// <returns>The file as string</returns>
        public string ReadFile(string pathFile, string typeFile, bool encrypt = false, Roles role = Roles.Viewer)
        {
            string text = string.Empty;
            string extension = Path.GetExtension(pathFile);

            if (extension.IndexOf(typeFile, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                switch (typeFile)
                {
                    case TXTFILE:
                        text = this.ReadFile(pathFile, encrypt, role, Permissions.ReadTextFile);
                        break;
                    case XMLFILE:
                        text = this.ReadFile(pathFile, encrypt, role, Permissions.ReadXMLFile);
                        break;
                    case JSONFILE:
                        text = this.ReadFile(pathFile, encrypt, role, Permissions.ReadJSONFile);
                        break;
                    default:
                        text = FILENOTSUPPORTED;
                        break;
                }
            }
            else
            {
                text = NOTPERMISSION;
            }

            return text;
        }

        #endregion

        #region Private methods

        private string ReadFile(string pathFile, bool encrypt, Roles role, Permissions permission)
        {
            string text = string.Empty;

            if (Authorize.HasPermission(role, permission))
            {
                text = text = File.ReadAllText(pathFile);

                if (encrypt)
                {
                    text = Security.Encrypt(text);
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
