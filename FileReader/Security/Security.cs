using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    /// <summary>
    /// Implementación de la clase Security
    /// Entidad Security
    /// </summary>
    public static class Security
    {
        /// <summary>
        /// Encrypt a text
        /// </summary>
        /// <param name="sourceText"></param>
        /// <returns>the strind encrypted</returns>
        public static string Encrypt(string sourceText)
        {
            return Reverse(sourceText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceText"></param>
        /// <returns></returns>
        public static string Decrypt(string sourceText)
        {
            return Reverse(sourceText);
        }

        #region Private methods

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        #endregion
    }
}