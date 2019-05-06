using System;
using System.IO;
using System.Security.Cryptography;

namespace wk.nOorm.lib.da.dBXml
{
    internal class eNcriptador
    {
        private byte[] Key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        private byte[] IV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

        internal string eNcriptar(string texto)
        {
            string _resultado = string.Empty;

            using (RijndaelManaged _rIjndaelManaged = new RijndaelManaged())
            {
                _rIjndaelManaged.Key = this.Key;
                _rIjndaelManaged.IV = this.IV;

                ICryptoTransform _iCryptoTransform = _rIjndaelManaged.CreateEncryptor(_rIjndaelManaged.Key, _rIjndaelManaged.IV);

                using (MemoryStream _memoryStream = new MemoryStream())
                {
                    using (CryptoStream _cryptoStream = new CryptoStream(_memoryStream, _iCryptoTransform, CryptoStreamMode.Write))
                    {
                        using (StreamWriter _streamWriter = new StreamWriter(_cryptoStream))
                        {
                            _streamWriter.Write(texto);
                        }
                        _resultado = Convert.ToBase64String(_memoryStream.ToArray());
                    }
                }
            }

            return _resultado;
        }

        internal string dEsEncriptar(string texto)
        {
            string _resultado = string.Empty;

            using (RijndaelManaged _rIjndaelManaged = new RijndaelManaged())
            {
                _rIjndaelManaged.Key = this.Key;
                _rIjndaelManaged.IV = this.IV;

                ICryptoTransform _iCryptoTransform = _rIjndaelManaged.CreateDecryptor(_rIjndaelManaged.Key, _rIjndaelManaged.IV);

                using (MemoryStream _memoryStream = new MemoryStream(Convert.FromBase64String(texto)))
                {
                    using (CryptoStream _cryptoStream = new CryptoStream(_memoryStream, _iCryptoTransform, CryptoStreamMode.Read))
                    {
                        using (StreamReader _streamWriter = new StreamReader(_cryptoStream))
                        {
                            _resultado = _streamWriter.ReadToEnd();
                        }
                    }
                }
            }

            return _resultado;
        }
    }
}
